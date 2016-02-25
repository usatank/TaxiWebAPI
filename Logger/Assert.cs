using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public static class Assert
    {
        public static bool IsNull(object obj)
        {
            if (obj == null)
            {
                Logger.Error("Object is null \n" + Environment.StackTrace);
                return true;
            }

            return false;
        }
        public static bool IsNullOrEmtpy(string str)
        {
            if (String.IsNullOrEmpty(str))
            {
                Logger.Error("String is null or empty \n" + Environment.StackTrace);
                return true;
            }

            return false;
        }

        public static bool IsPositive(int i)
        {
            if (i <= 0)
            {
                Logger.Error("Value is not positive \n" + Environment.StackTrace);
                return false;
            }

            return true;
        }

        public static bool IsNullOrEmtpyOrWhitespace(string str)
        {
            if (String.IsNullOrEmpty(str) || String.IsNullOrWhiteSpace(str))
            {
                Logger.Error("String is null or empty or whitespace \n" + Environment.StackTrace);
                return true;
            }

            return false;
        }
    }
}
