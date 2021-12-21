using Microsoft.Extensions.Primitives;
using Skybrud.Essentials.Strings.Extensions;
using System.Linq;
using Skybrud.Essentials.Strings;

namespace Skybrud.Essentials.AspNetCore {
    
    /// <summary>
    /// Various extension methods for working with the <see cref="StringValues"/> class.
    /// </summary>
    public static class StringValuesExtensions {
        
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
        /// Parses the specified array of string <paramref name="values"/> into an <see cref="int"/> array.
        /// </summary>
        /// <param name="values">The string values.</param>
        /// <returns>An array of <see cref="int"/>.</returns>
        public static int[] ToInt32Array(this StringValues values) {
            return values.SelectMany(StringUtils.ParseInt32Array).ToArray();
        }
        
        /// <summary>
        /// Converts the specified <paramref name="values" /> to a <see cref="long" /> value.
        /// </summary>
        /// <param name="values">The values to be converted.</param>
        /// <returns>The result of the conversion.</returns>
        public static long ToInt64(this StringValues values) {
            string input = values.FirstOrDefault();
            return input?.ToInt64() ?? 0;
        }

        /// <summary>
        /// Converts the specified <paramref name="values" /> to a <see cref="long" /> value. If the conversion fails,
        /// <paramref name="fallback" /> is returned instead.
        /// </summary>
        /// <param name="values">The values to be converted.</param>
        /// <param name="fallback">The fallback value.</param>
        /// <returns>The result of the conversion.</returns>
        public static long ToInt64(this StringValues values, long fallback) {
            string input = values.FirstOrDefault();
            return input?.ToInt64(fallback) ?? fallback;
        }
        
        /// <summary>
        /// Parses the specified array of string <paramref name="values"/> into a <see cref="long"/> array.
        /// </summary>
        /// <param name="values">The string values.</param>
        /// <returns>An array of <see cref="long"/>.</returns>
        public static long[] ToInt64Array(this StringValues values) {
            return values.SelectMany(StringUtils.ParseInt64Array).ToArray();
        }
        
        /// <summary>
        /// Converts the specified <paramref name="values" /> to a <see cref="float" /> value.
        /// </summary>
        /// <param name="values">The values to be converted.</param>
        /// <returns>The result of the conversion.</returns>
        public static float ToFloat(this StringValues values) {
            string input = values.FirstOrDefault();
            return input?.ToFloat() ?? 0;
        }

        /// <summary>
        /// Converts the specified <paramref name="values" /> to a <see cref="float" /> value. If the conversion fails,
        /// <paramref name="fallback" /> is returned instead.
        /// </summary>
        /// <param name="values">The values to be converted.</param>
        /// <param name="fallback">The fallback value.</param>
        /// <returns>The result of the conversion.</returns>
        public static float ToFloat(this StringValues values, float fallback) {
            string input = values.FirstOrDefault();
            return input?.ToFloat(fallback) ?? fallback;
        }
        
        /// <summary>
        /// Parses the specified array of string <paramref name="values"/> into a <see cref="float"/> array.
        /// </summary>
        /// <param name="values">The string values.</param>
        /// <returns>An array of <see cref="float"/>.</returns>
        public static float[] ToFloatArray(this StringValues values) {
            return values.SelectMany(StringUtils.ParseFloatArray).ToArray();
        }
        
        /// <summary>
        /// Converts the specified <paramref name="values" /> to a <see cref="double" /> value.
        /// </summary>
        /// <param name="values">The values to be converted.</param>
        /// <returns>The result of the conversion.</returns>
        public static double ToDouble(this StringValues values) {
            string input = values.FirstOrDefault();
            return input?.ToDouble() ?? 0;
        }

        /// <summary>
        /// Converts the specified <paramref name="values" /> to a <see cref="double" /> value. If the conversion fails,
        /// <paramref name="fallback" /> is returned instead.
        /// </summary>
        /// <param name="values">The values to be converted.</param>
        /// <param name="fallback">The fallback value.</param>
        /// <returns>The result of the conversion.</returns>
        public static double ToDouble(this StringValues values, double fallback) {
            string input = values.FirstOrDefault();
            return input?.ToDouble(fallback) ?? fallback;
        }
        
        /// <summary>
        /// Parses the specified array of string <paramref name="values"/> into a <see cref="double"/> array.
        /// </summary>
        /// <param name="values">The string values.</param>
        /// <returns>An array of <see cref="double"/>.</returns>
        public static double[] ToDoubleArray(this StringValues values) {
            return values.SelectMany(StringUtils.ParseDoubleArray).ToArray();
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
            return str?.ToBoolean(fallback) ?? fallback;
        }

    }

}