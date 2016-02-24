using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public static class StringUtil
    {
        public static bool NullOrEmtpy(string str)
        {
            if (String.IsNullOrEmpty(str))
            {
                Logger.Error("String is null or empty \n" + Environment.StackTrace);
                return true;
            }

            return false;
        }

        public static bool NullOrEmtpyOrWhitespace(string str)
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
