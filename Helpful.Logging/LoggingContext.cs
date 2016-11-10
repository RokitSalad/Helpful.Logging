using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;

namespace Helpful.Logging
{
    public static class LoggingContext
    {
        private static readonly AsyncLocal<ConcurrentDictionary<string, object>> AsyncLocalContext = new AsyncLocal<ConcurrentDictionary<string, object>>();

        private static ConcurrentDictionary<string, object> Dictionary => AsyncLocalContext.Value ?? (AsyncLocalContext.Value = new ConcurrentDictionary<string, object>());

        public static ReadOnlyDictionary<string, object> ReadOnlyDictionary => new ReadOnlyDictionary<string, object>(Dictionary);

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

        public static object Delete(string key)
        {
            object val;
            return Dictionary.TryRemove(key, out val) ? val : null;
        }
    }
}
