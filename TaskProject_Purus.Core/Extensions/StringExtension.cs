using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProject_Purus.Core.Extensions
{
    public static class StringExtension
    {
        public static string IsSelected(this string value, string compareValue)
        {
            return value == compareValue ? "selected" : string.Empty;
        }
    }
}
