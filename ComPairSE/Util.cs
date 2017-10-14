using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComPairSE
{
    public static class Util
    {
        public static decimal ToDecimal(this int arg)
        {
            return arg / 100m;
        }

        public static string ObjToString(Object obj)
        {
            string ObjectString = JsonConvert.SerializeObject(obj);
            return ObjectString;
        }

        public static List<T> StringToObj <T> (this string str)
        {
            return JsonConvert.DeserializeObject<List<T>>(str);
        }
    }
}
