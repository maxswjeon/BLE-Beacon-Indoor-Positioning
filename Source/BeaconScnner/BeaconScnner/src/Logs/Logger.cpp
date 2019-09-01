#include "Logs/Logger.h"
using std::vector;
using std::pair;
using std::string;
using std::mutex;
using std::lock_guard;

Logger::Logger()
{
#ifdef DEBUG
	_level = LOG_LEVEL_DEBUG;
#else
	_level = LOG_LEVEL_INFO;
#endif
	_logs = vector<LogItem>();
	_color = false;
}

Logger::Logger(Logger&& other) noexcept
{
	lock_guard<mutex> guard(_mutex);
	_logs = std::move(other._logs);
	_level = other._level;
	_color = other._color;
}

Logger& Logger::operator=(Logger&& other) noexcept
{
	lock_guard<mutex> guard(_mutex);

	_logs = std::move(other._logs);
	_level = other._level;
	_color = other._color;
	return *this;
}

Logger::Logger(const Logger& other)
{
	lock_guard<mutex> guard(_mutex);
	_logs = other._logs;
	_level = other._level;
	_color = other._color;
}

Logger& Logger::operator=(const Logger& other)
{
	lock_guard<mutex> guard(_mutex);
	_logs = other._logs;
	_level = other._level;
	_color = other._color;
	return *this;
}

int Logger::Error(const char* fmt, ...)
{
	va_list ap;
	va_start(ap, fmt);
	const int result = Print(LOG_LEVEL_ERROR, fmt, ap);
	va_end(ap);
	return result;
}

int Logger::Warn(const char* fmt, ...)
{
	va_list ap;
	va_start(ap, fmt);
	const int result = Print(LOG_LEVEL_WARN, fmt, ap);
	va_end(ap);
	return result;
}

int Logger::Info(const char* fmt, ...)
{
	va_list ap;
	va_start(ap, fmt);
	const int result = Print(LOG_LEVEL_INFO, fmt, ap);
	va_end(ap);
	return result;
}

int Logger::Verbose(const char* fmt, ...)
{
	va_list ap;
	va_start(ap, fmt);
	const int result = Print(LOG_LEVEL_VERBOSE, fmt, ap);
	va_end(ap);
	return result;
}

int Logger::Debug(const char* fmt, ...)
{
	va_list ap;
	va_start(ap, fmt);
	const int result = Print(LOG_LEVEL_DEBUG, fmt, ap);
	va_end(ap);
	return result;
}

int Logger::Print(int level, const char* fmt, ...)
{
	va_list ap;
	va_start(ap, fmt);
	const int result = Print(level, fmt, ap);
	va_end(ap);
	return result;
}

void Logger::setLogLevel(int level)
{
	_level = level;
}

int Logger::getLogLevel()
{
	return _level;
}

void Logger::enableColor()
{
	_color = true;
}

void Logger::disableColor()
{
	_color = false;
}

std::vector<LogItem> Logger::GetLogs()
{
	lock_guard<mutex> guard(_mutex);
	return _logs;
}

void Logger::ClearLogs()
{
	lock_guard<mutex> guard(_mutex);
	_logs.clear();
}

int Logger::Print(int level, const char* fmt, va_list ap)
{
	if (level > _level)
	{
		return -1;
	}

	int n = vsnprintf(NULL, 0, fmt, ap);

	string str = string();
	str.resize(n + 1);
	vsnprintf(const_cast<char*>(str.data()), n + 1, fmt, ap);

	{
		lock_guard<mutex> guard(_mutex);
		switch (level)
		{
		case LOG_LEVEL_DEBUG:
			printf("[DEBG] ");
			break;
		case LOG_LEVEL_VERBOSE:
			printf("[VERB] ");
			break;
		case LOG_LEVEL_INFO:
			if (_color)
			{
				printf("\033[0;32m");
			}
			printf("[INFO] ");
			break;
		case LOG_LEVEL_WARN:
			if (_color)
			{
				printf("\033[0;33m");
			}
			printf("[WARN] ");
			break;
		case LOG_LEVEL_ERROR:
			if (_color)
			{
				printf("\033[0;31m");
			}
			printf("[EROR] ");
			break;
		}
		printf(str.c_str());
		printf("\n\033[0m");
		fflush(stdout);
		_logs.emplace_back(level, str);
	}
	return n + 8;
}
