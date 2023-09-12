using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Skybrud.Essentials.Enums;
using Skybrud.Essentials.Strings;
using Skybrud.Essentials.Strings.Extensions;

namespace Limbo.Essentials.AspNetCore {

    /// <summary>
    /// Various extension methods for working with ASP.NET Core header collections.
    /// </summary>
    public static class HeaderDictionaryExtensions {

        #region GetString...

        /// <summary>
        /// Returns the value of the first header with the specified <paramref name="key"/>, or <see langword="null"/> if not found.
        /// </summary>
        /// <param name="headers">The header collection.</param>
        /// <param name="key">The key of the header.</param>
        /// <returns>The value of the first header matching <paramref name="key"/>; otherwise <see langword="null"/>.</returns>
        public static string? GetString(this IHeaderDictionary? headers, string key) {
            return headers?[key].FirstOrDefault();
        }

        /// <summary>
        /// Returns the value of the header with the specified <paramref name="key"/>, or
        /// <paramref name="fallback"/> if not found.
        /// </summary>
        /// <param name="headers">The header collection.</param>
        /// <param name="key">The key of the header.</param>
        /// <param name="fallback">The fallback value.</param>
        /// <returns>The value of the first header matching <paramref name="key"/>; otherwise <paramref name="fallback"/>.</returns>
        public static string GetString(this IHeaderDictionary? headers, string key, string fallback) {
            return headers.GetString(key).HasValue(out string? value) ? value : fallback;
        }

        /// <summary>
        /// Attempts to get the string value of the header item with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="headers">The header collection.</param>
        /// <param name="key">The key of the header.</param>
        /// <param name="result">When this method returns, holds the string value if successful; otherwise, <see langword="null"/>.</param>
        /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetString(this IHeaderDictionary? headers, string key, [NotNullWhen(true)] out string? result) {

            if (headers is not null && headers.TryGetValue(key, out StringValues value) && value.FirstOrDefault() is { } str && !string.IsNullOrWhiteSpace(str)) {
                result = str;
                return true;
            }

            result = null;
            return false;

        }

        #endregion

        #region GetInt32...

        /// <summary>
        /// Gets the value of the header with the specified <paramref name="key"/>, and returns the value as an
        /// <see cref="int"/>. If a matching header isn't found, or the value could not be converted to an integer,
        /// <c>0</c> is returned instead.
        /// </summary>
        /// <param name="headers">The header collection.</param>
        /// <param name="key">The key of the header.</param>
        /// <returns>The converted <see cref="int"/> value if a matching header is found and the conversion is successful; otherwise <c>0</c>.</returns>
        public static int GetInt32(this HeaderDictionary? headers, string key) {
            return headers == null ? 0 : headers[key].ToInt32();
        }

        /// <summary>
        /// Gets the value of the header with the specified <paramref name="key"/>, and returns the value as an
        /// <see cref="int"/>. If a matching header isn't found, or the value could not be converted to an integer,
        /// <paramref name="fallback"/> is returned instead.
        /// </summary>
        /// <param name="headers">The header collection.</param>
        /// <param name="key">The key of the header.</param>
        /// <param name="fallback">The fallback value.</param>
        /// <returns>The converted <see cref="int"/> value if a matching header is found and the conversion is successful; otherwise <paramref name="fallback"/>.</returns>
        public static int GetInt32(this HeaderDictionary? headers, string key, int fallback) {
            return headers == null ? fallback : headers[key].ToInt32(fallback);
        }

        /// <summary>
        /// Gets the value of the header with the specified <paramref name="key"/>, and returns the value as an
        /// <see cref="int"/>. If a matching header isn't found, or the value could not be converted to an integer,
        /// <see langword="null"/> is returned instead.
        /// </summary>
        /// <param name="headers">The header collection.</param>
        /// <param name="key">The key of the header.</param>
        /// <returns>The converted <see cref="int"/> value if a matching header is found and the conversion is successful; otherwise <see langword="null"/>.</returns>
        public static int? GetInt32OrNull(this HeaderDictionary? headers, string key) {
            return headers?[key].ToInt32OrNull();
        }

        /// <summary>
        /// Attempts to get the <see cref="int"/> value of the header with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="headers">The header collection.</param>
        /// <param name="key">The key of the header.</param>
        /// <param name="result">When this method returns, holds the <see cref="int"/> value if successful; otherwise, <c>0</c>.</param>
        /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetInt32(this HeaderDictionary? headers, string key, out int result) {
            return StringUtils.TryParseInt32(GetString(headers, key), out result);
        }

        /// <summary>
        /// Attempts to get the <see cref="int"/> value of the header with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="headers">The header collection.</param>
        /// <param name="key">The key of the header.</param>
        /// <param name="result">When this method returns, holds the <see cref="int"/> value if successful; otherwise, <see langword="null"/>.</param>
        /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetInt32(this HeaderDictionary? headers, string key, [NotNullWhen(true)] out int? result) {
            return StringUtils.TryParseInt32(GetString(headers, key), out result);
        }

        #endregion

        #region GetInt64...

        /// <summary>
        /// Gets the value of the header with the specified <paramref name="key"/>, and returns the value as a
        /// <see cref="long"/>. If a matching header isn't found, or the value could not be converted to a
        /// <see cref="long"/>, <c>0</c> is returned instead.
        /// </summary>
        /// <param name="headers">The header collection.</param>
        /// <param name="key">The key of the header.</param>
        /// <returns>The converted <see cref="long"/> value if a matching header is found and the
        /// conversion is successful; otherwise <c>0</c>.</returns>
        public static long GetInt64(this HeaderDictionary? headers, string key) {
            return headers == null ? 0 : headers[key].ToInt64();
        }

        /// <summary>
        /// Gets the value of the header with the specified <paramref name="key"/>, and returns
        /// the value as a <see cref="long"/>. If a matching header isn't found, or the value could not
        /// be converted to a <see cref="long"/>, <paramref name="fallback"/> is returned instead.
        /// </summary>
        /// <param name="headers">The header collection.</param>
        /// <param name="key">The key of the header.</param>
        /// <param name="fallback">The fallback value.</param>
        /// <returns>The converted <see cref="long"/> value if a matching header is found and the
        /// conversion is successful; otherwise <paramref name="fallback"/>.</returns>
        public static long GetInt64(this HeaderDictionary? headers, string key, long fallback) {
            return headers == null ? fallback : headers[key].ToInt64(fallback);
        }

        /// <summary>
        /// Gets the value of the header with the specified <paramref name="key"/>, and returns
        /// the value as a <see cref="long"/>. If a matching header isn't found, or the value could not
        /// be converted to an integer, <see langword="null"/> is returned instead.
        /// </summary>
        /// <param name="headers">The header collection.</param>
        /// <param name="key">The key of the header.</param>
        /// <returns>The converted <see cref="long"/> value if a matching header is found and the
        /// conversion is successful; otherwise <see langword="null"/>.</returns>
        public static long? GetInt64OrNull(this HeaderDictionary? headers, string key) {
            return headers?[key].ToInt64OrNull();
        }

        /// <summary>
        /// Attempts to get the <see cref="long"/> value of the string component with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="headers">The header collection.</param>
        /// <param name="key">The key of the header.</param>
        /// <param name="result">When this method returns, holds the <see cref="long"/> value if successful; otherwise, <c>0</c>.</param>
        /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetInt64(this HeaderDictionary? headers, string key, out long result) {
            return StringUtils.TryParseInt64(GetString(headers, key), out result);
        }

        /// <summary>
        /// Attempts to get the <see cref="long"/> value of the string component with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="headers">The header collection.</param>
        /// <param name="key">The key of the header.</param>
        /// <param name="result">When this method returns, holds the <see cref="long"/> value if successful; otherwise, <see langword="null"/>.</param>
        /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetInt64(this HeaderDictionary? headers, string key, [NotNullWhen(true)] out long? result) {
            return StringUtils.TryParseInt64(GetString(headers, key), out result);
        }

        #endregion

        #region GetFloat...

        /// <summary>
        /// Gets the value of the header with the specified <paramref name="key"/>, and returns
        /// the value as a <see cref="float"/>. If a matching header isn't found, or the value could
        /// not be converted to a <see cref="float"/>, <c>0</c> is returned instead.
        /// </summary>
        /// <param name="headers">The header collection.</param>
        /// <param name="key">The key of the header.</param>
        /// <returns>The converted <see cref="float"/> value if a matching header is found and the
        /// conversion is successful; otherwise <c>0</c>.</returns>
        public static float GetFloat(this HeaderDictionary? headers, string key) {
            return headers == null ? 0 : headers[key].ToFloat();
        }

        /// <summary>
        /// Gets the value of the header with the specified <paramref name="key"/>, and returns
        /// the value as a <see cref="float"/>. If a matching header isn't found, or the value could
        /// not be converted to a <see cref="float"/>, <paramref name="fallback"/> is returned instead.
        /// </summary>
        /// <param name="headers">The header collection.</param>
        /// <param name="key">The key of the header.</param>
        /// <param name="fallback">The fallback value.</param>
        /// <returns>The converted <see cref="float"/> value if a matching header is found and the
        /// conversion is successful; otherwise <paramref name="fallback"/>.</returns>
        public static float GetFloat(this HeaderDictionary? headers, string key, float fallback) {
            return headers == null ? fallback : headers[key].ToFloat(fallback);
        }

        /// <summary>
        /// Gets the value of the header with the specified <paramref name="key"/>, and returns
        /// the value as a <see cref="float"/>. If a matching header isn't found, or the value could not
        /// be converted to an integer, <see langword="null"/> is returned instead.
        /// </summary>
        /// <param name="headers">The header collection.</param>
        /// <param name="key">The key of the header.</param>
        /// <returns>The converted <see cref="float"/> value if a matching header is found and the
        /// conversion is successful; otherwise <see langword="null"/>.</returns>
        public static float? GetFloatOrNull(this HeaderDictionary? headers, string key) {
            return headers?[key].ToFloatOrNull();
        }

        /// <summary>
        /// Attempts to get the <see cref="float"/> value of the string component with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="headers">The header collection.</param>
        /// <param name="key">The key of the header.</param>
        /// <param name="result">When this method returns, holds the <see cref="float"/> value if successful; otherwise, <c>0</c>.</param>
        /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetFloat(this HeaderDictionary? headers, string key, out float result) {
            return StringUtils.TryParseFloat(GetString(headers, key), out result);
        }

        /// <summary>
        /// Attempts to get the <see cref="float"/> value of the string component with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="headers">The header collection.</param>
        /// <param name="key">The key of the header.</param>
        /// <param name="result">When this method returns, holds the <see cref="float"/> value if successful; otherwise, <see langword="null"/>.</param>
        /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetFloat(this HeaderDictionary? headers, string key, [NotNullWhen(true)] out float? result) {
            return StringUtils.TryParseFloat(GetString(headers, key), out result);
        }

        #endregion

        #region GetDouble...

        /// <summary>
        /// Gets the value of the header with the specified <paramref name="key"/>, and returns
        /// the value as a <see cref="double"/>. If a matching header isn't found, or the value could
        /// not be converted to a <see cref="double"/>, <c>0</c> is returned instead.
        /// </summary>
        /// <param name="headers">The header collection.</param>
        /// <param name="key">The key of the header.</param>
        /// <returns>The converted <see cref="double"/> value if a matching header is found and the
        /// conversion is successful; otherwise <c>0</c>.</returns>
        public static double GetDouble(this HeaderDictionary? headers, string key) {
            return headers == null ? 0 : headers[key].ToDouble();
        }

        /// <summary>
        /// Gets the value of the header with the specified <paramref name="key"/>, and returns
        /// the value as a <see cref="double"/>. If a matching header isn't found, or the value could
        /// not be converted to a <see cref="double"/>, <paramref name="fallback"/> is returned instead.
        /// </summary>
        /// <param name="headers">The header collection.</param>
        /// <param name="key">The key of the header.</param>
        /// <param name="fallback">The fallback value.</param>
        /// <returns>The converted <see cref="double"/> value if a matching header is found and the
        /// conversion is successful; otherwise <paramref name="fallback"/>.</returns>
        public static double GetDouble(this HeaderDictionary? headers, string key, double fallback) {
            return headers == null ? fallback : headers[key].ToDouble(fallback);
        }

        /// <summary>
        /// Gets the value of the header with the specified <paramref name="key"/>, and returns
        /// the value as a <see cref="double"/>. If a matching header isn't found, or the value could not
        /// be converted to an integer, <see langword="null"/> is returned instead.
        /// </summary>
        /// <param name="headers">The header collection.</param>
        /// <param name="key">The key of the header.</param>
        /// <returns>The converted <see cref="double"/> value if a matching header is found and the
        /// conversion is successful; otherwise <see langword="null"/>.</returns>
        public static double? GetDoubleOrNull(this HeaderDictionary? headers, string key) {
            return headers?[key].ToDoubleOrNull();
        }

        /// <summary>
        /// Attempts to get the <see cref="double"/> value of the string component with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="headers">The header collection.</param>
        /// <param name="key">The key of the header.</param>
        /// <param name="result">When this method returns, holds the <see cref="double"/> value if successful; otherwise, <c>0</c>.</param>
        /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetDouble(this HeaderDictionary? headers, string key, out double result) {
            return StringUtils.TryParseDouble(GetString(headers, key), out result);
        }

        /// <summary>
        /// Attempts to get the <see cref="double"/> value of the string component with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="headers">The header collection.</param>
        /// <param name="key">The key of the header.</param>
        /// <param name="result">When this method returns, holds the <see cref="double"/> value if successful; otherwise, <see langword="null"/>.</param>
        /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetDouble(this HeaderDictionary? headers, string key, [NotNullWhen(true)] out double? result) {
            return StringUtils.TryParseDouble(GetString(headers, key), out result);
        }

        #endregion

        #region GetBoolean...

        /// <summary>
        /// Gets the value of the header with the specified <paramref name="key"/>, and returns
        /// the value as a <see cref="bool"/>. If a matching header isn't found, or the value could not
        /// be converted to a <see cref="bool"/>, <c>false</c> is returned instead.
        /// </summary>
        /// <param name="headers">The header collection.</param>
        /// <param name="key">The key of the header.</param>
        /// <returns>The converted <see cref="bool"/> value if a matching header is found and the
        /// conversion is successful; otherwise <c>false</c>.</returns>
        public static bool GetBoolean(this HeaderDictionary? headers, string key) {
            return headers != null && headers[key].ToBoolean();
        }

        /// <summary>
        /// Gets the value of the header with the specified <paramref name="key"/>, and returns
        /// the value as a <see cref="bool"/>. If a matching header isn't found, or the value could not
        /// be converted to a <see cref="bool"/>, <paramref name="fallback"/> is returned instead.
        /// </summary>
        /// <param name="headers">The header collection.</param>
        /// <param name="key">The key of the header.</param>
        /// <param name="fallback">The fallback value.</param>
        /// <returns>The converted <see cref="bool"/> value if a matching header is found and the
        /// conversion is successful; otherwise <paramref name="fallback"/>.</returns>
        public static bool GetBoolean(this HeaderDictionary? headers, string key, bool fallback) {
            return headers == null ? fallback : headers[key].ToBoolean(fallback);
        }

        /// <summary>
        /// Gets the value of the header with the specified <paramref name="key"/>, and returns
        /// the value as a <see cref="bool"/>. If a matching header isn't found, or the value could not
        /// be converted to an integer, <see langword="null"/> is returned instead.
        /// </summary>
        /// <param name="headers">The header collection.</param>
        /// <param name="key">The key of the header.</param>
        /// <returns>The converted <see cref="bool"/> value if a matching header is found and the
        /// conversion is successful; otherwise <see langword="null"/>.</returns>
        public static bool? GetBooleanOrNull(this HeaderDictionary? headers, string key) {
            return headers?[key].ToBooleanOrNull();
        }

        /// <summary>
        /// Attempts to get the <see cref="bool"/> value of the string component with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="headers">The header collection.</param>
        /// <param name="key">The key of the header.</param>
        /// <param name="result">When this method returns, holds the <see cref="bool"/> value if successful; otherwise, <see langword="false"/>.</param>
        /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetBoolean(this HeaderDictionary? headers, string key, out bool result) {
            return StringUtils.TryParseBoolean(GetString(headers, key), out result);
        }

        /// <summary>
        /// Attempts to get the <see cref="bool"/> value of the string component with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="headers">The header collection.</param>
        /// <param name="key">The key of the header.</param>
        /// <param name="result">When this method returns, holds the <see cref="bool"/> value if successful; otherwise, <see langword="null"/>.</param>
        /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetBoolean(this HeaderDictionary? headers, string key, [NotNullWhen(true)] out bool? result) {
            return StringUtils.TryParseBoolean(GetString(headers, key), out result);
        }

        #endregion

        #region GetGuid...

        /// <summary>
        /// Gets the value of the header with the specified <paramref name="key"/>, and returns
        /// the value as a <see cref="Guid"/>. If a matching header isn't found, or the value could not
        /// be converted to a <see cref="Guid"/>, <see cref="Guid.Empty"/> is returned instead.
        /// </summary>
        /// <param name="headers">The header collection.</param>
        /// <param name="key">The key of the header.</param>
        /// <returns>The converted <see cref="Guid"/> value if a matching header is found and the
        /// conversion is successful; otherwise, <see cref="Guid.Empty"/>.</returns>
        public static Guid GetGuid(this HeaderDictionary? headers, string key) {
            return headers == null ? Guid.Empty : headers[key].ToGuid();
        }

        /// <summary>
        /// Gets the value of the header with the specified <paramref name="key"/>, and returns
        /// the value as a <see cref="Guid"/>. If a matching header isn't found, or the value could not
        /// be converted to a <see cref="Guid"/>, <paramref name="fallback"/> is returned instead.
        /// </summary>
        /// <param name="headers">The header collection.</param>
        /// <param name="key">The key of the header.</param>
        /// <param name="fallback">The fallback value.</param>
        /// <returns>The converted <see cref="Guid"/> value if a matching header is found and the
        /// conversion is successful; otherwise, <paramref name="fallback"/>.</returns>
        public static Guid GetGuid(this HeaderDictionary? headers, string key, Guid fallback) {
            return headers == null ? fallback : headers[key].ToGuid(fallback);
        }

        /// <summary>
        /// Gets the value of the header with the specified <paramref name="key"/>, and returns
        /// the value as a <see cref="Guid"/>. If a matching header isn't found, or the value could not
        /// be converted to a <see cref="Guid"/>, <see langword="null"/> is returned instead.
        /// </summary>
        /// <param name="headers">The header collection.</param>
        /// <param name="key">The key of the header.</param>
        /// <returns>The converted <see cref="Guid"/> value if a matching header is found and the
        /// conversion is successful; otherwise, <see langword="null"/>.</returns>
        public static Guid? GetGuidOrNull(this HeaderDictionary? headers, string key) {
            return headers?[key].ToGuidOrNull();
        }

        /// <summary>
        /// Attempts to get the <see cref="Guid"/> value of the string component with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="headers">The header collection.</param>
        /// <param name="key">The key of the header.</param>
        /// <param name="result">When this method returns, holds the <see cref="Guid"/> value if successful; otherwise, <see cref="Guid.Empty"/>.</param>
        /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetGuid(this HeaderDictionary? headers, string key, out Guid result) {
            return StringUtils.TryParseGuid(GetString(headers, key), out result);
        }

        /// <summary>
        /// Attempts to get the <see cref="bool"/> value of the string component with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="headers">The header collection.</param>
        /// <param name="key">The key of the header.</param>
        /// <param name="result">When this method returns, holds the <see cref="Guid"/> value if successful; otherwise, <see langword="null"/>.</param>
        /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetGuid(this HeaderDictionary? headers, string key, [NotNullWhen(true)] out Guid? result) {
            return StringUtils.TryParseGuid(GetString(headers, key), out result);
        }

        #endregion

        #region GetEnum...

        /// <summary>
        /// Returns the corresponding <typeparamref name="TEnum"/> value of the header with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="headers">The header collection.</param>
        /// <param name="key">The key of the header.</param>
        /// <returns>The converted <typeparamref name="TEnum"/> value if a matching header is found and the
        /// conversion is successful; otherwise, the default value of <typeparamref name="TEnum"/>.</returns>
        public static TEnum GetEnum<TEnum>(this HeaderDictionary? headers, string key) where TEnum : struct, Enum {
            return (headers?[key]).ToEnum<TEnum>();
        }

        /// <summary>
        /// Returns the corresponding <typeparamref name="TEnum"/> value of the header with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="headers">The header collection.</param>
        /// <param name="key">The key of the header.</param>
        /// <param name="fallback">The fallback value in case a value isn't found or cant be converted.</param>
        /// <returns>The converted <typeparamref name="TEnum"/> value if a matching header is found and the
        /// conversion is successful; otherwise, <paramref name="fallback"/>.</returns>
        public static TEnum GetEnum<TEnum>(this HeaderDictionary? headers, string key, TEnum fallback) where TEnum : struct, Enum {
            return (headers?[key]).ToEnum(fallback);
        }

        /// <summary>
        /// Returns the corresponding <typeparamref name="TEnum"/> value of the header with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="headers">The header collection.</param>
        /// <param name="key">The key of the header.</param>
        /// <returns>The converted <typeparamref name="TEnum"/> value if a matching header is found and the
        /// conversion is successful; otherwise, <see langword="null"/>.</returns>
        public static TEnum? GetEnumOrNull<TEnum>(this HeaderDictionary? headers, string key) where TEnum : struct, Enum {
            return (headers?[key]).ToEnumOrNull<TEnum>();
        }

        /// <summary>
        /// Attempts to get the enum value of type <typeparamref name="TEnum"/> from the header with the specified <paramref name="key"/>.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="headers">The header collection.</param>
        /// <param name="key">The key of the header.</param>
        /// <param name="result">When this method returns, contains the parsed <typeparamref name="TEnum"/> value if successful; otherwise, <see langword="null"/>. This parameter is passed uninitialized.</param>
        /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetEnum<TEnum>(this HeaderDictionary? headers, string key, out TEnum result) where TEnum : struct, Enum {
            result = default;
            return TryGetString(headers, key, out string? value) && EnumUtils.TryParseEnum(value, out result);
        }

        /// <summary>
        /// Attempts to get the enum value of type <typeparamref name="TEnum"/> from the header with the specified <paramref name="key"/>.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="headers">The header collection.</param>
        /// <param name="key">The key of the header.</param>
        /// <param name="result">When this method returns, contains the parsed <typeparamref name="TEnum"/> value if successful; otherwise, the default value of <typeparamref name="TEnum"/>. This parameter is passed uninitialized.</param>
        /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetEnum<TEnum>(this HeaderDictionary? headers, string key, out TEnum? result) where TEnum : struct, Enum {
            result = null;
            return TryGetString(headers, key, out string? value) && EnumUtils.TryParseEnum(value, out result);
        }

        #endregion

    }

}