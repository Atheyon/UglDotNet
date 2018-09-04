using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UglDotNet.Models.Types
{
    abstract class UglType
    {
        public abstract string Key { get; }
        public abstract bool Validate(string str);
        //T Parse(string str);
        public static readonly List<UglType> Primitives = new List<UglType>
        {
            new UglBool(),
            new UglFloat(),
            new UglInt(),
            new UglString(),
            new UglVoid()
        };

        public static Dictionary<string, UglType> PrimitiveMap
        {
            get
            {
                var result = new Dictionary<string, UglType>();
                foreach (var p in Primitives)
                    result[p.Key] = p;
                return result;
            }
        }
    }
}
