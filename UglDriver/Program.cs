using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UglDotNet;

namespace UglDriver
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = UglLexer.UglLex(new FileInfo(@"sampleUgls/ugl.schema.ugl"));
            var node = UglParser.UglParse(lines);
            Console.WriteLine(node.ToString());
        }
    }
}
