using Microsoft.Extensions.Primitives;
using Skybrud.Essentials.Strings.Extensions;
using System.Linq;

namespace Skybrud.Essentials.AspNetCore {
    
    /// <summary>
    /// Various extension methods for working with ASP.NET Core query strings.
    /// </summary>
    public static class QueryStringExtensions {
        
        /// <summary>
        /// Converts the specified <paramref name="values" /> to an <see cref="int" /> value.
        /// </summary>
        /// <param name="values">The values to be converted.</param>
        /// <returns>The result of the conversion.</returns>
        public static int ToInt32(this StringValues values) {
            string input = values.FirstOrDefault();
            return input?.ToInt32() ?? 0;
        }

        /// <summary>
        /// Converts the specified <paramref name="values" /> to an <see cref="int" /> value. If the conversion fails,
        /// <paramref name="fallback" /> is returned instead.
        /// </summary>
        /// <param name="values">The values to be converted.</param>
        /// <param name="fallback">The fallback value.</param>
        /// <returns>The result of the conversion.</returns>
        public static int ToInt32(this StringValues values, int fallback) {
            string input = values.FirstOrDefault();
            return input?.ToInt32(fallback) ?? fallback;
        }

        /// <summary>
        /// Converts the specified <paramref name="values" /> to a <see cref="bool" /> value. If the conversion fails,
        /// <c>false</c> is returned instead.
        /// </summary>
        /// <param name="values">The values to be converted.</param>
        /// <returns>The result of the conversion.</returns>
        public static bool ToBoolean(this StringValues values) {
            string str = values.FirstOrDefault();
            return str != null && str.ToBoolean();
        }

        /// <summary>
        /// Converts the specified <paramref name="values" /> to a <see cref="bool" /> value. If the conversion fails,
        /// <paramref name="fallback" /> is returned instead.
        /// </summary>
        /// <param name="values">The values to be converted.</param>
        /// <param name="fallback">The fallback value.</param>
        /// <returns>The result of the conversion.</returns>
        public static bool ToBoolean(this StringValues values, bool fallback) {
            string str = values.FirstOrDefault();
            return str?.ParseBoolean(fallback) ?? fallback;
        }

    }

}