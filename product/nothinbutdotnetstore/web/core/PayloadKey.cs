using System;
using System.Collections.Specialized;

namespace nothinbutdotnetstore.web.core
{
    public class PayloadKey<KeyValue>
    {
        string key_name;

        public PayloadKey(string key_name)
        {
            this.key_name = key_name;
        }

        public static implicit operator string(PayloadKey<KeyValue> key)
        {
            return key.ToString();
        }

        public override string ToString()
        {
            return this.key_name;
        }

        public KeyValue map_from(NameValueCollection collection)
        {
            return (KeyValue) Convert.ChangeType(collection[key_name], typeof (KeyValue));
        }
    }
}