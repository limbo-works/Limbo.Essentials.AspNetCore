using System;
using System.Collections.Generic;
using Microsoft.Extensions.Primitives;
using Skybrud.Essentials.Strings.Extensions;
using System.Linq;
using Skybrud.Essentials.Enums;
using Skybrud.Essentials.Strings;

// ReSharper disable ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator

namespace Skybrud.Essentials.AspNetCore {

    /// <summary>
    /// Various extension methods for working with the <see cref="StringValues"/> class.
    /// </summary>
    public static class StringValuesExtensions {

        internal static readonly char[] DefaultSeparators = { ',', ' ', '\r', '\n', '\t' };

        #region ToString...

        /// <summary>
        /// Parses the specified array of string <paramref name="values"/> into a <see cref="string"/> array.
        /// </summary>
        /// <param name="values">The string values.</param>
        /// <returns>A array of <see cref="string"/>.</returns>
        public static string[] ToStringArray(this StringValues? values) {
            return values?.SelectMany(StringUtils.ParseStringArray).ToArray() ?? Array.Empty<string>();
        }

        /// <summary>
        /// Parses the specified array of string <paramref name="values"/> into a <see cref="string"/> array.
        /// </summary>
        /// <param name="values">The string values.</param>
        /// <param name="separators">An array of supported separators.</param>
        /// <returns>A array of <see cref="string"/>.</returns>
        public static string[] ToStringArray(this StringValues? values, params char[] separators) {
            return values?.SelectMany(x => StringUtils.ParseStringArray(x, separators)).ToArray() ?? Array.Empty<string>();
        }

        /// <summary>
        /// Parses the specified array of string <paramref name="values"/> into a <see cref="string"/> list.
        /// </summary>
        /// <param name="values">The string values.</param>
        /// <returns>A list of <see cref="string"/>.</returns>
        public static List<string> ToStringList(this StringValues? values) {
            return values?.SelectMany(StringUtils.ParseStringArray).ToList() ?? new List<string>();
        }

        /// <summary>
        /// Parses the specified array of string <paramref name="values"/> into a <see cref="string"/> list.
        /// </summary>
        /// <param name="values">The string values.</param>
        /// <param name="separators">An array of supported separators.</param>
        /// <returns>A list of <see cref="string"/>.</returns>
        public static List<string> ToStringList(this StringValues? values, params char[] separators) {
            return values?.SelectMany(x => StringUtils.ParseStringArray(x, separators)).ToList() ?? new List<string>();
        }

        #endregion

        /// <summary>
        /// Converts the specified <paramref name="values" /> to an <see cref="int" /> value.
        /// </summary>
        /// <param name="values">The values to be converted.</param>
        /// <returns>The result of the conversion.</returns>
        public static int ToInt32(this StringValues values) {
            string? input = values.FirstOrDefault();
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
            string? input = values.FirstOrDefault();
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
        /// Parses the specified array of string <paramref name="values"/> into an <see cref="int"/> list.
        /// </summary>
        /// <param name="values">The string values.</param>
        /// <returns>A list of <see cref="int"/>.</returns>
        public static List<int> ToInt32List(this StringValues values) {
            return values.SelectMany(StringUtils.ParseInt32List).ToList();
        }

        /// <summary>
        /// Converts the specified <paramref name="values" /> to a <see cref="long" /> value.
        /// </summary>
        /// <param name="values">The values to be converted.</param>
        /// <returns>The result of the conversion.</returns>
        public static long ToInt64(this StringValues values) {
            string? input = values.FirstOrDefault();
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
            string? input = values.FirstOrDefault();
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
        /// Parses the specified array of string <paramref name="values"/> into a <see cref="long"/> list.
        /// </summary>
        /// <param name="values">The string values.</param>
        /// <returns>A list of <see cref="long"/>.</returns>
        public static List<long> ToInt64List(this StringValues values) {
            return values.SelectMany(StringUtils.ParseInt64List).ToList();
        }

        /// <summary>
        /// Converts the specified <paramref name="values" /> to a <see cref="float" /> value.
        /// </summary>
        /// <param name="values">The values to be converted.</param>
        /// <returns>The result of the conversion.</returns>
        public static float ToFloat(this StringValues values) {
            string? input = values.FirstOrDefault();
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
            string? input = values.FirstOrDefault();
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
        /// Parses the specified array of string <paramref name="values"/> into a <see cref="float"/> list.
        /// </summary>
        /// <param name="values">The string values.</param>
        /// <returns>A list of <see cref="float"/>.</returns>
        public static List<float> ToFloatList(this StringValues values) {
            return values.SelectMany(StringUtils.ParseFloatList).ToList();
        }

        /// <summary>
        /// Converts the specified <paramref name="values" /> to a <see cref="double" /> value.
        /// </summary>
        /// <param name="values">The values to be converted.</param>
        /// <returns>The result of the conversion.</returns>
        public static double ToDouble(this StringValues values) {
            string? input = values.FirstOrDefault();
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
            string? input = values.FirstOrDefault();
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
        /// Parses the specified array of string <paramref name="values"/> into a <see cref="double"/> list.
        /// </summary>
        /// <param name="values">The string values.</param>
        /// <returns>A list of <see cref="double"/>.</returns>
        public static List<double> ToDoubleList(this StringValues values) {
            return values.SelectMany(StringUtils.ParseDoubleList).ToList();
        }

        /// <summary>
        /// Converts the specified <paramref name="values" /> to a <see cref="bool" /> value. If the conversion fails,
        /// <c>false</c> is returned instead.
        /// </summary>
        /// <param name="values">The values to be converted.</param>
        /// <returns>The result of the conversion.</returns>
        public static bool ToBoolean(this StringValues values) {
            string? str = values.FirstOrDefault();
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
            string? str = values.FirstOrDefault();
            return str?.ToBoolean(fallback) ?? fallback;
        }

        /// <summary>
        /// Converts the specified <paramref name="values" /> to a <see cref="Guid" /> value. If the conversion fails, <see cref="Guid.Empty"/> is returned instead.
        /// </summary>
        /// <param name="values">The values to be converted.</param>
        /// <returns>The result of the conversion.</returns>
        public static Guid ToGuid(this StringValues values) {
            string? str = values.FirstOrDefault();
            return str?.ToGuid() ?? Guid.Empty;
        }

        /// <summary>
        /// Converts the specified <paramref name="values" /> to a <see cref="Guid" /> value. If the conversion fails, <paramref name="fallback" /> is returned instead.
        /// </summary>
        /// <param name="values">The values to be converted.</param>
        /// <param name="fallback">The fallback value.</param>
        /// <returns>The result of the conversion.</returns>
        public static Guid ToGuid(this StringValues values, Guid fallback) {
            string? str = values.FirstOrDefault();
            return str?.ToGuid(fallback) ?? fallback;
        }

        /// <summary>
        /// Converts the specified <paramref name="values" /> to a <see cref="Guid" /> value. If the conversion fails, <see langword="null"/> is returned instead.
        /// </summary>
        /// <param name="values">The values to be converted.</param>
        /// <returns>The result of the conversion.</returns>
        public static Guid? ToGuidOrNull(this StringValues values) {
            string? str = values.FirstOrDefault();
            return StringUtils.TryParseGuid(str, out Guid? result) ? result : null;
        }

        /// <summary>
        /// Parses the specified array of string <paramref name="values"/> into a <see cref="Guid"/> array.
        /// </summary>
        /// <param name="values">The string values.</param>
        /// <returns>An array of <see cref="Guid"/>.</returns>
        public static Guid[] ToGuidArray(this StringValues values) {
            return values.SelectMany(StringUtils.ParseGuidArray).ToArray();
        }

        /// <summary>
        /// Parses the specified array of string <paramref name="values"/> into a <see cref="Guid"/> list.
        /// </summary>
        /// <param name="values">The string values.</param>
        /// <returns>A list of <see cref="Guid"/>.</returns>
        public static List<Guid> ToGuidList(this StringValues values) {
            return values.SelectMany(StringUtils.ParseGuidList).ToList();
        }

        #region ToEnum...

        /// <summary>
        /// Converts the specified <paramref name="values" /> to a corresponding <typeparamref name="TEnum"/> value. If
        /// the conversion fails, the default value of <typeparamref name="TEnum"/> is returned instead.
        /// </summary>
        /// <param name="values">The values to be converted.</param>
        /// <returns>The result of the conversion.</returns>
        public static TEnum ToEnum<TEnum>(this StringValues? values) where TEnum : struct, Enum {
            string? str = values?.FirstOrDefault();
            return EnumUtils.TryParseEnum(str, out TEnum? result) ? result.Value : default;
        }

        /// <summary>
        /// Converts the specified <paramref name="values" /> to a corresponding <typeparamref name="TEnum"/> value. If
        /// the conversion fails, <paramref name="fallback" /> is returned instead.
        /// </summary>
        /// <param name="values">The values to be converted.</param>
        /// <param name="fallback">The fallback value.</param>
        /// <returns>The result of the conversion.</returns>
        public static TEnum ToEnum<TEnum>(this StringValues? values, TEnum fallback) where TEnum : struct, Enum {
            string? str = values?.FirstOrDefault();
            return EnumUtils.TryParseEnum(str, out TEnum? result) ? result.Value : fallback;
        }

        /// <summary>
        /// Converts the specified <paramref name="values" /> to a corresponding <typeparamref name="TEnum"/> value. If the conversion fails, <see langword="null"/> is returned instead.
        /// </summary>
        /// <param name="values">The values to be converted.</param>
        /// <returns>The result of the conversion.</returns>
        public static TEnum? ToEnumOrNull<TEnum>(this StringValues? values) where TEnum : struct, Enum {
            string? str = values?.FirstOrDefault();
            return EnumUtils.TryParseEnum(str, out TEnum? result) ? result : null;
        }

        /// <summary>
        /// Parses the specified array of string <paramref name="values"/> into a corresponding <typeparamref name="TEnum"/> array.
        /// </summary>
        /// <param name="values">The string values.</param>
        /// <returns>An array of <typeparamref name="TEnum"/>.</returns>
        public static TEnum[] ToEnumArray<TEnum>(this StringValues? values) where TEnum : struct, Enum {
            return values is { Count: > 0 } ? ToEnumList<TEnum>(values).ToArray() : Array.Empty<TEnum>();
        }

        /// <summary>
        /// Parses the specified array of string <paramref name="values"/> into a corresponding <typeparamref name="TEnum"/> array.
        /// </summary>
        /// <param name="values">The string values.</param>
        /// <param name="separators">An array of supported separators.</param>
        /// <returns>An array of <typeparamref name="TEnum"/>.</returns>
        public static TEnum[] ToEnumArray<TEnum>(this StringValues? values, params char[] separators) where TEnum : struct, Enum {
            return values is { Count: > 0 } ? ToEnumList<TEnum>(values, separators).ToArray() : Array.Empty<TEnum>();
        }

        /// <summary>
        /// Parses the specified array of string <paramref name="values"/> into a <typeparamref name="TEnum"/> list.
        /// </summary>
        /// <param name="values">The string values.</param>
        /// <returns>A list of <typeparamref name="TEnum"/>.</returns>
        public static List<TEnum> ToEnumList<TEnum>(this StringValues? values) where TEnum : struct, Enum {
            return ToEnumList<TEnum>(values, DefaultSeparators);
        }

        /// <summary>
        /// Parses the specified array of string <paramref name="values"/> into a <typeparamref name="TEnum"/> list.
        /// </summary>
        /// <param name="values">The string values.</param>
        /// <param name="separators">An array of supported separators.</param>
        /// <returns>A list of <typeparamref name="TEnum"/>.</returns>
        public static List<TEnum> ToEnumList<TEnum>(this StringValues? values, params char[] separators) where TEnum : struct, Enum {

            List<TEnum> list = new();
            if (values is null) return list;

            foreach (string? value in values) {

                if (value is null) continue;

                foreach (string piece in value.Split(separators, StringSplitOptions.RemoveEmptyEntries)) {

                    if (EnumUtils.TryParseEnum(piece, out TEnum? result)) {
                        list.Add(result.Value);
                    }

                }

            }

            return list;

        }

        #endregion

    }

}