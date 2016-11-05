using System.Collections.Generic;
using System.Threading;

namespace Helpful.Logging
{
    public static class LoggingContext
    {
        private static readonly AsyncLocal<Dictionary<string, object>> AsyncLocalContext = new AsyncLocal<Dictionary<string, object>>();

        public const string RequestHeadersKey = "6492A684-9B1C-40FB-9B00-F0EDDCBA5A81";

        public static IDictionary<string, object> Dictionary
        {
            get
            {
                if (AsyncLocalContext.Value == null)
                {
                    AsyncLocalContext.Value = new Dictionary<string, object>();
                }
                return AsyncLocalContext.Value;
            }
        }

        public static void Set(string key, object value)
        {
            if (AsyncLocalContext.Value == null)
            {
                AsyncLocalContext.Value = new Dictionary<string, object>();
            }
            if (AsyncLocalContext.Value.ContainsKey(key))
            {
                AsyncLocalContext.Value[key] = value;
            }
            else
            {
                AsyncLocalContext.Value.Add(key, value);
            }
        }

        public static object Get(string key)
        {
            if (AsyncLocalContext.Value == null)
            {
                AsyncLocalContext.Value = new Dictionary<string, object>();
            }
            if (AsyncLocalContext.Value.ContainsKey(key))
            {
                return AsyncLocalContext.Value[key];
            }
            return null;
        }
    }
}
