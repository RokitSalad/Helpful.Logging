using System.Collections.Generic;
using System.Dynamic;

namespace Helpful.Logging
{
    public class DynamicDictionary : DynamicObject
    {
        private readonly IDictionary<string, object> _dictionary;
        public IDictionary<string, object> AsDictionary => _dictionary;

        public DynamicDictionary(IDictionary<string, object> dictionary)
        {
            _dictionary = dictionary;
        }

        public override bool TryGetMember(
            GetMemberBinder binder, out object result)
        {
            return _dictionary.TryGetValue(binder.Name, out result);
        }

        public override bool TrySetMember(
            SetMemberBinder binder, object value)
        {
            if(_dictionary.ContainsKey(binder.Name))
            {
                _dictionary[binder.Name] = value;
            }
            else
            {
                _dictionary.Add(binder.Name, value);
            }

            return true;
        }
        
        public override string ToString()
        {
            return _dictionary.ToString();
        }
    }
}