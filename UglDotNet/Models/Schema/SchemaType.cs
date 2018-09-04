using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UglDotNet.Models.Schema
{
    public class SchemaType
    {
        public string Key { get; set; }
        public string Kind { get; set; } //todo: more correct typey types
        public string Type { get; set; }
        public SchemaArrayOpts Array { get; set; }
        public List<SchemaField> Fields { get; set;}
    }
}