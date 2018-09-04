using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UglDotNet.Models.Types
{
    class UglBool : UglType
    {
        public override string Key => "bool";

        public override bool Validate(string str) =>
            bool.TryParse(str, out bool _);
    }
}
