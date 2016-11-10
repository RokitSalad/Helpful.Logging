using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace Helpful.Logging
{
    public static class LoggingContext
    {
        private static readonly AsyncLocal<ConcurrentDictionary<string, object>> AsyncLocalContext = new AsyncLocal<ConcurrentDictionary<string, object>>();

        public const string RequestHeadersKey = "6492A684-9B1C-40FB-9B00-F0EDDCBA5A81";

        private static readonly object ThreadLock = new object();

        public static ConcurrentDictionary<string, object> Dictionary
        {
            get
            {
                if (AsyncLocalContext.Value == null)
                {
                    SafeInitialiseDictionary();
                }
                return AsyncLocalContext.Value;
            }
        }

        private static void SafeInitialiseDictionary()
        {
            bool lockTaken = false;
            Monitor.Enter(ThreadLock, ref lockTaken);
            if (AsyncLocalContext.Value == null)
            {
                AsyncLocalContext.Value = new ConcurrentDictionary<string, object>();
            }
            if (lockTaken)
            {
                Monitor.Exit(ThreadLock);
            }
        }

        public static void Set(string key, object value)
        {
            if (Dictionary.ContainsKey(key))
            {
                Dictionary[key] = value;
            }
            else
            {
                Dictionary.GetOrAdd(key, value);
            }
        }

        public static object Get(string key)
        {
            if (Dictionary.ContainsKey(key))
            {
                return Dictionary[key];
            }
            return null;
        }
    }
}
