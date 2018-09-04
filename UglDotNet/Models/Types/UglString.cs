using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UglDotNet.Models.Types
{
    class UglString : UglType
    {
        public override string Key => "string"

        public override bool Validate(string str) => true;
    }
}
