using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SagamApi4
{
    public static class Common
    {
        public static bool IsNumeri(string text)
        {
            long.TryParse(text, out long result);
            return result > 0;
        }
    }
}