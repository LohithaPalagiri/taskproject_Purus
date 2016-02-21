using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProject_Purus.Core.Extensions
{
    public static class BoolExtensions
    {
        public static string IsSelected(this bool value)
        {
            return value ? "selected" : string.Empty;
        }

        public static string IsQuoteReady(this bool? status)
        {
            if (status != null && status.Value)
            {
                return "View Quote";
            }
            return "Pending...";
        }
    }
}
