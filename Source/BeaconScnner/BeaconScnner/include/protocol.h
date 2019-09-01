#pragma once

#include <stdint.h>

#define PACKET_MAGIC 0xBEEF

#define PTYPE_OK 0x00
#define PTYPE_GET_LOGS 0x01
#define PTYPE_CLEAR_LOGS 0x02
#define PTYPE_BEACON_STATUS 0x03
#define PTYPE_BEACON_ENABLE 0x04
#define PTYPE_BEACON_DISABLE 0x05
#define PTYPE_BEACON_SET_DATA 0x06
#define PTYPE_BEACON_START_SCAN 0x07
#define PTYPE_BEACON_SCAN_RESULT 0x08

#define BEACON_NONE 0x00
#define BEACON_ADVERTIZING 0x01
#define BEACON_SCANNING 0x02


#pragma pack(push, 1)
typedef struct
{
	uint16_t Magic;
	uint8_t PType;
}PACKET;

typedef struct
{
	uint16_t Magic;
	uint8_t PType;
	uint64_t Size;
}PACKET_DATA;

typedef struct
{
	uint16_t Magic;
	uint8_t PType;
	char UUID[6];
	uint16_t Major;
	uint16_t Minor;
	uint8_t DefRSSI;
}PACKET_BEACON_DATA;
#pragma pack(pop)