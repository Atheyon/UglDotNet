using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UglDotNet.Models.Schema
{
    public class SchemaField
    {
        public string Key { get; set; }
        public string Type { get; set; }
        public bool? Required { get; set;}
        public string Default { get; set;}
        public SchemaArrayOpts Array { get; set;}
        public SchemaField[] Fields { get; set;}
    }
}
