using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proms.models
{
    public class KeyValue
    {
        public string key { set; get; }
        public object value { set; get; }

        public KeyValue(string key, object value)
        {
            this.key = key;
            this.value = value;
        }
    }
}