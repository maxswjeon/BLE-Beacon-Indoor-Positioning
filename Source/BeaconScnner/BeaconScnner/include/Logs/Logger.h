#pragma once
#include "LogItem.h"

#include <string>
#include <vector>
#include <mutex>

#include <stdio.h>
#include <stdarg.h>

// Constants
// Log Levels
#define LOG_LEVEL_NONE 0
#define LOG_LEVEL_ERROR 1
#define LOG_LEVEL_WARN 2
#define LOG_LEVEL_INFO 3
#define LOG_LEVEL_VERBOSE 4
#define LOG_LEVEL_DEBUG 5

class Logger
{
public:
	Logger();
	Logger(Logger&&) noexcept;
	Logger& operator= (Logger&&) noexcept;
	
	Logger(const Logger&);
	Logger& operator= (const Logger&);

	int Error(const char* fmt, ...);
	int Warn(const char* fmt, ...);
	int Info(const char* fmt, ...);
	int Verbose(const char* fmt, ...);
	int Debug(const char* fmt, ...);
	int Print(int level, const char* fmt, ...);
	void setLogLevel(int level);
	int getLogLevel();
	void enableColor();
	void disableColor();

	std::vector<LogItem> GetLogs();
	void ClearLogs();
private:
	int Print(int level, const char* fmt, va_list ap);

	bool _color;
	int _level;
	mutable std::mutex _mutex;
	std::vector<LogItem> _logs;
};

