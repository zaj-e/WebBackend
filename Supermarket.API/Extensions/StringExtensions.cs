using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Supermarket.API.Extensions
{
    public static class StringExtensions
    {
        public static string toSnakeCase(this string str)
        {
            return string.Concat(
                str.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() :
                x.ToString())).ToLower();
        }
    }
}
