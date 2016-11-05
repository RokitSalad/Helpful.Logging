using System;
using log4net;

namespace Helpful.Logging
{
    public class Logger : ILogger
    {
        private readonly ILog _logger;

        public bool IsDebugEnabled => _logger.IsDebugEnabled;
        public bool IsInfoEnabled => _logger.IsInfoEnabled;
        public bool IsWarnEnabled => _logger.IsWarnEnabled;
        public bool IsErrorEnabled => _logger.IsErrorEnabled;
        public bool IsFatalEnabled => _logger.IsFatalEnabled;

        public Logger(Type loggerType)
        {
            _logger = LogManager.GetLogger(loggerType);
        }

        public void Fatal(object message, Exception exception = null)
        {
            _logger.Fatal(LogMessageBuilder.BuildMessage(message), exception);
        }

        public void Error(object message, Exception exception = null)
        {
            _logger.Error(LogMessageBuilder.BuildMessage(message), exception);
        }

        public void Warn(object message, Exception exception = null)
        {
            _logger.Warn(LogMessageBuilder.BuildMessage(message), exception);
        }

        public void Info(object message, Exception exception = null)
        {
            _logger.Info(LogMessageBuilder.BuildMessage(message), exception);
        }

        public void Debug(object message, Exception exception = null)
        {
            _logger.Debug(LogMessageBuilder.BuildMessage(message), exception);
        }
    }
}
