using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.NET
{
    public class Util
    {
        public static String Concat(IEnumerable<String> lstStr)
        {
            StringBuilder sb = new StringBuilder();
            int j;
            int jMax = lstStr.Count();
            for (j = 0; j < jMax; j++)
            {
                if (j >0) 
                {
                    sb.Append('\t');
                }
                sb.Append(lstStr.ElementAt(j));
            }
            return sb.ToString();
        }
    }
}
