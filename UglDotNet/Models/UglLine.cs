using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UglDotNet.Models
{
    public class UglLine
    {
        public int LineNumber { get; set; }
        public int Indent { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return Key + (Value == null ? "" : " " + Value);
        }
    }
}
