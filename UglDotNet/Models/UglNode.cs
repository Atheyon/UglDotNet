using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UglDotNet.Models.Schema;

namespace UglDotNet.Models
{
    public class UglNode
    {
        public static readonly string ArrayKey = "-";
        public UglLine Line { get; set; }
        public int Depth { get; set; }
        public Dictionary<string, UglNode> Fields { get; set; }
        public List<UglNode> Elements { get; set; }
        public string Type { get; set; }
        public SchemaField Schema { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(new string('\t', Depth == -1 ? 0 : Depth) + Line.ToString());
            foreach(var kvp in Fields)
                sb.Append(kvp.Value.ToString());
            foreach (var node in Elements)
                sb.Append(node.ToString());
            return sb.ToString();
        }
    }
}
