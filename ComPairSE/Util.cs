using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComPairSE
{
    public static class Util
    {
        public static decimal ToPrice(this int arg)
        {
            return arg / 100m;
        }
    }
}
