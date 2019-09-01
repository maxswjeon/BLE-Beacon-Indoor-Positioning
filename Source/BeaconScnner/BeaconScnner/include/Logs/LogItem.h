#include <time.h>

#include <string>

class LogItem
{
public:
	LogItem(int level, std::string message);
	LogItem(int level, std::string message, time_t create);

	std::string GetMessage();
	time_t GetCreatedTime();
	int GetLogLevel();
private:
	time_t _create;
	std::string _message;
	int _level;
};