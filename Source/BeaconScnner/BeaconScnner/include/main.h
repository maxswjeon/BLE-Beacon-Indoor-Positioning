#pragma once
#include "Logs/Logger.h"
#include "protocol.h"

#include <unistd.h>
#include <signal.h>
#include <sys/socket.h>
#include <sys/un.h>
#include <sys/ioctl.h>
#include <sys/types.h>
#include <sys/stat.h>

#include <string>
#include <thread>

#include <string.h>
#include <time.h>

#include <bluetooth/bluetooth.h>
#include <bluetooth/hci.h>
#include <bluetooth/hci_lib.h>

#define TRUE 1
#define FALSE 0

#define HCI_STATE_ERROR  -1
#define HCI_STATE_NONE       0
#define HCI_STATE_OPEN       2
#define HCI_STATE_SCANNING   3
#define HCI_STATE_FILTERING  4

#define EIR_FLAGS                   0X01
#define EIR_NAME_SHORT              0x08
#define EIR_NAME_COMPLETE           0x09
#define EIR_MANUFACTURE_SPECIFIC    0xFF

typedef struct {
	int device_id;
	int device_handle;
	struct hci_filter original_filter;
	int state;
	int error;
} hci_module;

#define STRING_MATCH 0

#define PROC_NAME "BeaconScanner"