using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UglDotNet.Models.Types
{
    class UglInt : UglType
    {
        public override string Key => "int";

        public override bool Validate(string str) =>
            Regex.IsMatch(str, @"^(?:0x[0-9a-fA-F]+|0o[0-7]+|0b[0-1]+|[0-9]+)$");
    }
}
