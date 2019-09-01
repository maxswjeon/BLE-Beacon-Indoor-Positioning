#include "Logs/LogItem.h"

LogItem::LogItem(int level, std::string message)
{
	_level = level;
	_message = std::move(message);
	_create = time(0);
}

LogItem::LogItem(int level, std::string message, time_t create)
{
	_level = level;
	_message = std::move(message);
	_create = create;
}

std::string LogItem::GetMessage()
{
	return _message;
}

time_t LogItem::GetCreatedTime()
{
	return _create;
}

int LogItem::GetLogLevel()
{
	return _level;
}
