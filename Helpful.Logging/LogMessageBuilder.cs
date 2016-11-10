using System.Collections.Generic;
using System.Dynamic;

namespace Helpful.Logging
{
    public static class LogMessageBuilder
    {
        public static object BuildMessage(object innerMessage)
        {
            var eo = new ExpandoObject();
            var eoColl = (ICollection<KeyValuePair<string, object>>)eo;

            foreach (var kvp in LoggingContext.ReadOnlyDictionary)
            {
                if(!string.IsNullOrEmpty(kvp.Key))
                {
                    eoColl.Add(kvp);
                }
            }

            eoColl.Add(new KeyValuePair<string, object>("Message Content", innerMessage));
            dynamic result = eo;
            return result;
        }
    }
}
