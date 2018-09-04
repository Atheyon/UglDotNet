using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OneOf;
using UglDotNet.Models.Types;

namespace UglDotNet.Models.Schema
{
    class SchemaContext
    {
        public UglNode Root { get; set; }
        public Schema Schema { get; set; }
        public Dictionary<string, OneOf<SchemaType, UglType>> Types { get; set;}
        public List<SchemaError> Errors { get; set; }
        public Schema Result { get; set;}
    }
}
