using System;

namespace Helpful.Logging
{
    public interface ILogger
    {
        void Error(object message, Exception exception = null);
        void Warn(object message, Exception exception = null);
        void Info(object message, Exception exception = null);
        void Debug(object message, Exception exception = null);
        bool IsDebugEnabled { get; }
        bool IsInfoEnabled { get; }
        bool IsWarnEnabled { get; }
        bool IsErrorEnabled { get; }
        bool IsFatalEnabled { get; }
        void Fatal(object message, Exception exception = null);
    }
}