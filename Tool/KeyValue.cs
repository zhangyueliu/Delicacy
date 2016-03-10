using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool
{
    public class KeyValue<TKey, TValue>
    {
        public override int GetHashCode()
        {
            return Key.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            return Key.Equals(((KeyValue<TKey, TValue>)obj).Key);
        }

        public TKey Key { get; set; }
        public TValue Value { get; set; }
    }
}
