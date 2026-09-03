using System;
using System.Collections.Generic;
using System.Text;

namespace structDemo
{
    public class DataStore<T>
    {
        public T Data { get; set; }
    }

    class KeyValuePair<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
    }
}
