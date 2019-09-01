#include "main.h"

// Using Statements
using std::thread;
using std::string;

// Functions
bool parseArgs(int argc, char* argv[]);

char* getTime();
char* getTime(time_t tm);

int stop();
int start();

void scanBeacon();
void enableBeacon();
void disableBeacon();
void respondSocket();

// Static Variables
Logger logger;
static char* command = NULL;
static int sock_recv;
static bool isScanning;

bool parseArgs(int argc, char* argv[])
{
	for (int i = 1; i < argc; ++i)
	{
		if (strcmp(argv[i], "-v") == STRING_MATCH)
		{
			logger.setLogLevel(LOG_LEVEL_VERBOSE);
		}
		else if (strncmp(argv[i], "--log-level", 11) == STRING_MATCH)
		{
			char* value = argv[i] + 12;
			if (strcasecmp(value, "debug") == STRING_MATCH || strcmp(value, "5") == STRING_MATCH)
			{
				logger.setLogLevel(LOG_LEVEL_DEBUG);
			}
			else if (strcasecmp(value, "verb") == STRING_MATCH || strcasecmp(value, "verbose") == STRING_MATCH || strcmp(value, "4") == STRING_MATCH)
			{
				logger.setLogLevel(LOG_LEVEL_VERBOSE);
			}
			else if (strcasecmp(value, "info") == STRING_MATCH || strcmp(value, "3") == STRING_MATCH)
			{
				logger.setLogLevel(LOG_LEVEL_INFO);
			}
			else if (strcasecmp(value, "warn") == STRING_MATCH || strcasecmp(value, "warning") == STRING_MATCH || strcmp(value, "2") == STRING_MATCH)
			{
				logger.setLogLevel(LOG_LEVEL_WARN);
			}
			else if (strcasecmp(value, "error") == STRING_MATCH || strcmp(value, "1") == STRING_MATCH)
			{
				logger.setLogLevel(LOG_LEVEL_ERROR);
			}
			else if (strcasecmp(value, "none") == STRING_MATCH || strcmp(value, "0") == STRING_MATCH)
			{
				logger.setLogLevel(LOG_LEVEL_NONE);
			}
		}
		else
		{
			if (i == argc - 1)
			{
				command = argv[i];
				return true;
			}
			return false;
		}
	}
	return true;
}

char* getTime()
{
	time_t now = time(NULL);
	char* t = ctime(&now);
	if (t[strlen(t) - 1] == '\n')
		t[strlen(t) - 1] = '\0';
	return t;
}

char* getTime(time_t tm)
{
	char* t = ctime(&tm);
	if (t[strlen(t) - 1] == '\n')
		t[strlen(t) - 1] = '\0';
	return t;
}

int main(int argc, char* argv[])
{
	logger = Logger();
	logger.enableColor();
	if (geteuid() != 0)
	{
		logger.Error("This Program Should run as root");
		exit(1);
		return 1;
	}

	if (!parseArgs(argc, argv))
	{
		logger.Error("Failed to Parse Arguments");
	}

	logger.Debug("Started Program at %s", getTime());
	logger.Debug("Arguments Parsed");
	logger.Debug("Logger Level : %d", logger.getLogLevel());
	logger.Debug("Command : %s", command);

	if (command == NULL)
	{
		logger.Error("No Command was given");
		exit(1);
		return 1;
	}

	if (strcasecmp(command, "stop") == STRING_MATCH)
	{
		return stop();
	}
	
	if (strcasecmp(command, "start") == STRING_MATCH) {
		return start();
	}
}

int start()
{
	logger.Debug("Command \"stop\" recognized");
	logger.Debug("Check PID File Exists");
	FILE* fp = fopen("pid.txt", "r");
	logger.Debug("pid.txt File Descriptor : %d", fp);
	if (fp != NULL)
	{
		pid_t pid;
		fscanf(fp, "%d", &pid);
		logger.Error("Existing Daemon is Running (PID %d)", pid);
		fclose(fp);
		exit(1);
		return 1;
	}

	logger.Debug("Fork Process");
	logger.Info("Forking Daemon Process");
	pid_t pid = fork();

	if (pid < 0)
	{
		logger.Error("Failed to Fork Process");
		exit(1);
		return 1;
	}

	if (pid > 0)
	{
		logger.Debug("Parent Process ID : %d", getpid());
		logger.Debug("Child Process ID : %d", pid);
		logger.Debug("Writing PID to pid.txt");
		logger.Debug("Opening pid.txt as write mode (overwrite)");
		fp = fopen("pid.txt", "w");
		logger.Debug("pid.txt File Descriptor : %d", fp);
		fprintf(fp, "%d", pid);
		logger.Debug("Wrote pid (%d) to pid.txt", pid);
		fclose(fp);
		logger.Debug("Closed pid.txt");
		exit(0);
		return 0;
	}

	logger.Debug("Set umask to 0");
	umask(0);

	logger.Debug("Make Child Process Independent");
	logger.Debug("Calling setsid()");
	pid_t sid = setsid();
	if (sid < 0)
	{
		logger.Error("Failed to make Child Process Independent");
		logger.Debug("Exiting Child Process");
		exit(1);
		return 1;
	}

	/*logger.Debug("Check Named Pipe Existence");
	if (access("socket", F_OK) != -1)
	{
		logger.Debug("Failed to access Named Pipe");
		logger.Debug("Error #%d", errno);
		logger.Info("Named Pipe did not Exist, Creating");
		logger.Debug("Make Named Pipe");
		if (mkfifo("socket", 0666) < 0)
		{
			logger.Error("Failed to make Named Pipe");
			logger.Error("Error #%d", errno);
			exit(1);
			return 1;
		}
		logger.Info("Successfully Created Named Pipe");
	}*/

	sock_recv = socket(PF_FILE, SOCK_STREAM, 0);
	struct sockaddr_un addr;
	memset(&addr, 0, sizeof(addr));
	addr.sun_family = AF_UNIX;
	strcpy(addr.sun_path, "socket");

	if (bind(sock_recv, (struct sockaddr*) &addr, sizeof(addr)) == -1)
	{
		logger.Error("Failed to Bind Unix Socket");
		exit(1);
		return 1;
	}

	if (listen(sock_recv, 1024) == -1)
	{
		logger.Error("Failed to Listen Unix Socket");
		exit(1);
		return 1;
	}

	//chdir("/");
#ifdef DEBUG
	logger.Debug("Close STDIN");
	close(STDIN_FILENO);
	logger.Debug("Closed STDIN");
	logger.Debug("Reopen STDOUT to out.txt");
	freopen("out.txt", "w+", stdout);
	logger.Debug("Reopened STDOUT to out.txt");
	logger.Debug("Reopen STDERR to err.txt");
	freopen("err.txt", "w+", stderr);
	logger.Debug("Reopened STDERR to err.txt");
#else
	close(STDIN_FILENO);
	close(STDOUT_FILENO);
	close(STDERR_FILENO);
#endif
	logger.Debug("Starting SocketThread");
	
	respondSocket();

	return 0;
}

int stop()
{
	logger.Debug("Command \"stop\" recognized");
	logger.Debug("Check PID File Exists");
	FILE* fp = fopen("pid.txt", "r");
	logger.Debug("pid.txt File Descriptor : %d", fp);
	if (fp == NULL)
	{
		logger.Debug("pid.txt Does not exist");
		logger.Error("Failed to get PID Info");
		exit(1);
		return 1;
	}

	pid_t pid;
	fscanf(fp, "%d", &pid);
	logger.Debug("Running Daemon pid : %d", pid);
	fclose(fp);

	logger.Debug("Signaling SIGTERM to pid : %d", pid);
	kill(pid, SIGTERM);

	logger.Debug("Removing PID File (pid.txt)");
	remove("pid.txt");
	return 0;
}

void scanBeacon()
{
	hci_module bmodule;
	memset(&bmodule, 0, sizeof(hci_module));
	bmodule.device_id = hci_get_route(NULL);
	bmodule.device_handle = hci_open_dev(bmodule.device_id);
	if (bmodule.device_handle < 0)
	{
		bmodule.state = HCI_STATE_ERROR;
		bmodule.error = errno;
		logger.Error("Failed to Open Bluetooth Device");
		logger.Error("Error #%d : %s", errno, strerror(errno));
		return;
	}

	int on = 1;
	if (ioctl(bmodule.device_handle, FIONBIO, (char*)&on) < 0)
	{
		bmodule.state = HCI_STATE_ERROR;
		bmodule.error = errno;
		logger.Error("Failed to Set Scan Parameters");
		logger.Error("Error #%d : %s", errno, strerror(errno));
		return;
	}

	bmodule.state = HCI_STATE_OPEN;

	if (hci_le_set_scan_parameters(bmodule.device_handle, 0x01, htobs(0x0010), htobs(0x0010), 0x00, 0x00, 1000) < 0)
	{
		bmodule.state = HCI_STATE_ERROR;
		bmodule.error = errno;
		logger.Error("Failed to Enable Scan");
		logger.Error("Error #%d : %s", errno, strerror(errno));
		return;
	}

	struct hci_filter filter;
	hci_filter_clear(&filter);
	hci_filter_set_ptype(HCI_EVENT_PKT, &filter);
	hci_filter_set_event(EVT_LE_META_EVENT, &filter);

	if (setsockopt(bmodule.device_handle, SOL_HCI, HCI_FILTER, &filter, sizeof(filter)) < 0)
	{
		bmodule.state = HCI_STATE_ERROR;
		bmodule.error = errno;
		logger.Error("Failed to Open Bluetooth Device");
		logger.Error("Error #%d : %s", errno, strerror(errno));
		return;
	}


	while (isScanning)
	{
		inquiry_info* ii = NULL;
		int rsp_max;
		int rsp_cnt;
		int i;
	}
}

void enableBeacon()
{
}

void disableBeacon()
{
}

void getLogs(int sock)
{
	string s = "[";
	for (auto item : logger.GetLogs())
	{
		s += "{\"create\":";
		s += std::to_string(item.GetCreatedTime());
		s += ",\"level\":";
		s += std::to_string(item.GetLogLevel());
		s += ",\"log\":";
		s += "\"";
		s += item.GetMessage();
		s += "\"},";
	}
	s.pop_back();
	s += "]";

	PACKET_DATA packet;
	packet.Magic = PACKET_MAGIC;
	packet.PType = PTYPE_GET_LOGS;
	packet.Size = s.length();
	write(sock, &packet, sizeof(PACKET_DATA));
	write(sock, s.c_str(), s.length());
}

void sendOK(int sock)
{
	PACKET packet;
	packet.Magic = PACKET_MAGIC;
	packet.PType = PTYPE_OK;
	write(sock, &packet, sizeof(packet));
}

void respondSocket()
{
	PACKET packet;
	thread scanThread;
	while (true)
	{
		memset(&packet, 0, sizeof(packet));

		struct sockaddr_un client_addr;
		int client_addr_size = sizeof(client_addr);
		int sock_cli = accept(sock_recv, (struct sockaddr*) & client_addr, (socklen_t*)& client_addr_size);

		if (sock_cli == -1)
		{
			logger.Warn("Failed to Accept Client");
			continue;
		}

		read(sock_cli, &packet, sizeof(packet));

		if (packet.Magic != PACKET_MAGIC)
		{
			logger.Warn("Invalid Packet Received");
			logger.Warn("Magic Found : %04X (%d), Expected %04X (%d)", packet.Magic, packet.Magic, PACKET_MAGIC, PACKET_MAGIC);
			logger.Warn("Packet Type : %02X (%d)", packet.PType, packet.PType);
			continue;
		}

		switch (packet.PType)
		{
		case PTYPE_GET_LOGS:
			getLogs(sock_cli);
			break;
		case PTYPE_CLEAR_LOGS:
			logger.ClearLogs();
			sendOK(sock_cli);
			break;
		case PTYPE_BEACON_ENABLE:
			enableBeacon();
			sendOK(sock_cli);
			break;
		case PTYPE_BEACON_DISABLE:
			disableBeacon();
			sendOK(sock_cli);
			break;
		case PTYPE_BEACON_SET_DATA:
			sendOK(sock_cli);
			break;
		case PTYPE_BEACON_START_SCAN:
			scanBeacon();
			sendOK(sock_cli);
			break;
		case PTYPE_BEACON_SCAN_RESULT:
			break;
		default:
			logger.Warn("Invalid Packet Received");
			logger.Warn("Magic Found : %04X (%d), Expected %04X (%d)", packet.Magic, packet.Magic, PACKET_MAGIC, PACKET_MAGIC);
			logger.Warn("Packet Type : %02X (%d)", packet.PType, packet.PType);
		}
	}
}

