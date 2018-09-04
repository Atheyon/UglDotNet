using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UglDotNet.Models;
using System.IO;

namespace UglDotNet
{
    public static class UglLexer
    {
        public static IEnumerable<UglLine> UglLex(FileInfo fi) =>
            UglLex(File.ReadLines(fi.FullName));

        public static IEnumerable<UglLine> UglLex(string uglyContents) =>
            UglLex(uglyContents.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None));

        public static IEnumerable<UglLine> UglLex(IEnumerable<string> lines)
        {
            var lexExp = new Regex(@"(\s*)(\w+|\-)(?:\s+(.*))?\s*");
            int lineNumber = 0;
            foreach (var line in lines)
            {
                var unTabbedLine = line.Replace("\t", new string(' ', 8));
                var result = lexExp.Match(unTabbedLine);
                if (result.Success)
                    yield return new UglLine
                    {
                        LineNumber = lineNumber,
                        Indent = result.Groups[1].Length,
                        Key = result.Groups[2].Value,
                        Value = result.Groups[3].Value
                    };
                lineNumber++;
            }
        }
    }
}
