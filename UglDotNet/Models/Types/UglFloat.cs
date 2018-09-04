using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UglDotNet.Models.Types
{
    class UglFloat : UglType
    {
        public override string Key => "float";

        public override bool Validate(string str) =>
            float.TryParse(str, out float _);
    }
}
