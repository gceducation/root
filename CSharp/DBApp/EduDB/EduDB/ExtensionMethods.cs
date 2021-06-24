using System;
using System.Collections.Generic;
using System.Text;

namespace EduDB
{
    public static class ExtensionMethods
    {
        // JAVA compat
        public static char getCharAt(this String str, int j)
        {
            return str[j];
        }
    }
}

