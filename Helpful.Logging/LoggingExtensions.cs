namespace Helpful.Logging
{
    public static class LoggingExtensions
    {
        public static ILogger GetLogger(this object loggingSource)
        {
            return new Logger(loggingSource.GetType());
        }
    }
}
