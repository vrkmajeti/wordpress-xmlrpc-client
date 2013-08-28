using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordpress.Xml.Rpc
{
    internal static class Guard
    {
        public static void AgainstNullOrEmpty(string name, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(name);
            }
        }

        public static void AgainstNull<TObj>(string name, TObj value) where TObj : class
        {
            if (value == null)
            {
                throw new ArgumentNullException(name);
            }
        }
    }
}
