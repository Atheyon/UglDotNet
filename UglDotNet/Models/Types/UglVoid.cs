using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UglDotNet.Models.Types
{
    class UglVoid : UglType
    {
        public override string Key => "void";

        public override bool Validate(string str) => string.IsNullOrEmpty(str);
    }
}
