using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Skybrud.Essentials.Strings.Extensions;
using System.Diagnostics.CodeAnalysis;
using Skybrud.Essentials.Strings;
using System.Collections.Generic;
using Skybrud.Essentials.Enums;

// ReSharper disable ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator

namespace Skybrud.Essentials.AspNetCore {

    /// <summary>
    /// Various extension methods for working with ASP.NET Core form collections.
    /// </summary>
    public static class FormCollectionExtensions {

        #region GetString...

        /// <summary>
        /// Returns the value of the first form data component with the specified <paramref name="key"/>, or
        /// <see langword="null"/> if not found.
        /// </summary>
        /// <param name="formData">The form data.</param>
        /// <param name="key">The key of the form data component.</param>
        /// <returns>The value of the first form data component matching <paramref name="key"/>; otherwise <see langword="null"/>.</returns>
        public static string? GetString(this IFormCollection? formData, string key) {
            return formData?[key].FirstOrDefault();
        }

        /// <summary>
        /// Returns the value of the first form data component with the specified <paramref name="key"/>, or
        /// <paramref name="fallback"/> if not found.
        /// </summary>
        /// <param name="formData">The form data.</param>
        /// <param name="key">The key of the form data component.</param>
        /// <param name="fallback">The fallback value.</param>
        /// <returns>The value of the first form data component matching <paramref name="key"/>; otherwise <paramref name="fallback"/>.</returns>
        public static string GetString(this IFormCollection? formData, string key, string fallback) {
            return formData.GetString(key).HasValue(out string? value) ? value : fallback;
        }

        /// <summary>
        /// Returns an array of <see cref="string"/> values representing the values of each form data component
        /// matching the specified <paramref name="key"/>.
        ///
        /// Notice that this method support both multiple form data components with the same <paramref name="key"/>
        /// as well as form data components where the value is a comma separated string or similar. Supported
        /// separators are comma (<c>,</c>), space (<c> </c>), carriage return (<c>\r</c>), new line (<c>\n</c>) and
        /// tab (<c>\t</c>).
        /// </summary>
        /// <param name="formData">The form data.</param>
        /// <param name="key">The key of the form data component(s).</param>
        /// <returns>An array of <see cref="string"/>.</returns>
        public static string[] GetStringArray(this IFormCollection? formData, string key) {
            return (formData?[key]).ToStringArray();
        }

        /// <summary>
        /// Returns an array of <see cref="string"/> values representing the values of each form data component
        /// matching the specified <paramref name="key"/>.
        ///
        /// Notice that this method support both multiple form data components with the same <paramref name="key"/>
        /// as well as form data components where the value is separated by one of the following <paramref name="separators"/>.
        /// </summary>
        /// <param name="formData">The form data.</param>
        /// <param name="key">The key of the form data component(s).</param>
        /// <param name="separators">An array of supported separators.</param>
        /// <returns>An array of <see cref="string"/>.</returns>
        public static string[] GetStringArray(this IFormCollection? formData, string key, params char[] separators) {
            return (formData?[key]).ToStringArray(separators);
        }

        /// <summary>
        /// Returns a list of <see cref="string"/> representing the values of each form data component
        /// matching the specified <paramref name="key"/>.
        ///
        /// Notice that this method support both multiple form data components with the same <paramref name="key"/>
        /// as well as form data components where the value is a comma separated string or similar. Supported
        /// separators are comma (<c>,</c>), space (<c> </c>), carriage return (<c>\r</c>), new line (<c>\n</c>) and
        /// tab (<c>\t</c>).
        /// </summary>
        /// <param name="formData">The form data.</param>
        /// <param name="key">The key of the form data component(s).</param>
        /// <returns>An array of <see cref="string"/>.</returns>
        public static List<string> GetStringList(this IFormCollection? formData, string key) {
            return (formData?[key]).ToStringList();
        }

        /// <summary>
        /// Returns a list of <see cref="string"/> values representing the values of each form data component
        /// matching the specified <paramref name="key"/>.
        ///
        /// Notice that this method support both multiple form data components with the same <paramref name="key"/>
        /// as well as form data components where the value is separated by one of the following <paramref name="separators"/>.
        /// </summary>
        /// <param name="formData">The form data.</param>
        /// <param name="key">The key of the form data component(s).</param>
        /// <param name="separators">An array of supported separators.</param>
        /// <returns>An array of <see cref="string"/>.</returns>
        public static List<string> GetStringList(this IFormCollection? formData, string key, params char[] separators) {
            return (formData?[key]).ToStringList(separators);
        }

        /// <summary>
        /// Attempts to get the string value of the string component with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="formData">The form data.</param>
        /// <param name="key">The key of the form data component.</param>
        /// <param name="result">When this method returns, holds the string value if successful; otherwise, <see langword="null"/>.</param>
        /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetString(this IFormCollection? formData, string key, [NotNullWhen(true)] out string? result) {

            if (formData is not null && formData.TryGetValue(key, out StringValues value) && value.FirstOrDefault() is { } str && !string.IsNullOrWhiteSpace(str)) {
                result = str;
                return true;
            }

            result = null;
            return false;

        }

        #endregion

        #region GetInt32...

        /// <summary>
        /// Gets the value of the first form data component with the specified <paramref name="key"/>, and returns
        /// the value as an <see cref="int"/>. If a matching form data component isn't found, or the value could not
        /// be converted to an integer, <c>0</c> is returned instead.
        /// </summary>
        /// <param name="formData">The form data.</param>
        /// <param name="key">The key of the form data component.</param>
        /// <returns>The converted <see cref="int"/> value if a matching form data component is found and the
        /// conversion is successful; otherwise <c>0</c>.</returns>
        public static int GetInt32(this IFormCollection? formData, string key) {
            return formData == null ? 0 : formData[key].ToInt32();
        }

        /// <summary>
        /// Gets the value of the first form data component with the specified <paramref name="key"/>, and returns
        /// the value as an <see cref="int"/>. If a matching form data component isn't found, or the value could not
        /// be converted to an integer, <paramref name="fallback"/> is returned instead.
        /// </summary>
        /// <param name="formData">The form data.</param>
        /// <param name="key">The key of the form data component.</param>
        /// <param name="fallback">The fallback value.</param>
        /// <returns>The converted <see cref="int"/> value if a matching form data component is found and the
        /// conversion is successful; otherwise <paramref name="fallback"/>.</returns>
        public static int GetInt32(this IFormCollection? formData, string key, int fallback) {
            return formData == null ? fallback : formData[key].ToInt32(fallback);
        }

        /// <summary>
        /// Gets the value of the first form data component with the specified <paramref name="key"/>, and returns
        /// the value as an <see cref="int"/>. If a matching form data component isn't found, or the value could not
        /// be converted to an integer, <see langword="null"/> is returned instead.
        /// </summary>
        /// <param name="formData">The form data.</param>
        /// <param name="key">The key of the form data component.</param>
        /// <returns>The converted <see cref="int"/> value if a matching form data component is found and the
        /// conversion is successful; otherwise <see langword="null"/>.</returns>
        public static int? GetInt32OrNull(this IFormCollection? formData, string key) {
            return formData?[key].ToInt32OrNull();
        }

        /// <summary>
        /// Attempts to get the <see cref="int"/> value of the string component with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="formData">The form data.</param>
        /// <param name="key">The key of the form data component.</param>
        /// <param name="result">When this method returns, holds the <see cref="int"/> value if successful; otherwise, <c>0</c>.</param>
        /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetInt32(this IFormCollection? formData, string key, out int result) {
            return StringUtils.TryParseInt32(GetString(formData, key), out result);
        }

        /// <summary>
        /// Attempts to get the <see cref="int"/> value of the string component with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="formData">The form data.</param>
        /// <param name="key">The key of the form data component.</param>
        /// <param name="result">When this method returns, holds the <see cref="int"/> value if successful; otherwise, <see langword="null"/>.</param>
        /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetInt32(this IFormCollection? formData, string key, [NotNullWhen(true)] out int? result) {
            return StringUtils.TryParseInt32(GetString(formData, key), out result);
        }

        /// <summary>
        /// Returns an <see cref="int"/> array based on the values of each form data component with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="formData">The form data.</param>
        /// <param name="key">The key of the form data components.</param>
        /// <returns>An <see cref="int"/> array representing the converted values.</returns>
        /// <remarks>The value of each form data component may themselves be a separated list of <see cref="int"/>
        /// values - eg. separated by commas. Values that can not be converted to a corresponding <see cref="int"/>
        /// value will be ignored.</remarks>
        public static int[] GetInt32Array(this IFormCollection? formData, string key) {
            return formData == null ? Array.Empty<int>() : formData[key].ToInt32Array();
        }

        /// <summary>
        /// Returns an <see cref="int"/> array based on the values of each form data component with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="formData">The form data.</param>
        /// <param name="key">The key of the form data components.</param>
        /// <returns>An <see cref="int"/> list representing the converted values.</returns>
        /// <remarks>The value of each form data component may themselves be a separated list of <see cref="int"/>
        /// values - eg. separated by commas. Values that can not be converted to a corresponding <see cref="int"/>
        /// value will be ignored.</remarks>
        public static List<int> GetInt32List(this IFormCollection? formData, string key) {
            return formData?[key].ToInt32List() ?? new List<int>();
        }

        #endregion

        #region GetInt64...

        /// <summary>
        /// Gets the value of the first form data component with the specified <paramref name="key"/>, and returns
        /// the value as a <see cref="long"/>. If a matching form data component isn't found, or the value could not
        /// be converted to a <see cref="long"/>, <c>0</c> is returned instead.
        /// </summary>
        /// <param name="formData">The form data.</param>
        /// <param name="key">The key of the form data component.</param>
        /// <returns>The converted <see cref="long"/> value if a matching form data component is found and the
        /// conversion is successful; otherwise <c>0</c>.</returns>
        public static long GetInt64(this IFormCollection? formData, string key) {
            return formData == null ? 0 : formData[key].ToInt64();
        }

        /// <summary>
        /// Gets the value of the first form data component with the specified <paramref name="key"/>, and returns
        /// the value as a <see cref="long"/>. If a matching form data component isn't found, or the value could not
        /// be converted to a <see cref="long"/>, <paramref name="fallback"/> is returned instead.
        /// </summary>
        /// <param name="formData">The form data.</param>
        /// <param name="key">The key of the form data component.</param>
        /// <param name="fallback">The fallback value.</param>
        /// <returns>The converted <see cref="long"/> value if a matching form data component is found and the
        /// conversion is successful; otherwise <paramref name="fallback"/>.</returns>
        public static long GetInt64(this IFormCollection? formData, string key, long fallback) {
            return formData == null ? fallback : formData[key].ToInt64(fallback);
        }

        /// <summary>
        /// Gets the value of the first form data component with the specified <paramref name="key"/>, and returns
        /// the value as a <see cref="long"/>. If a matching form data component isn't found, or the value could not
        /// be converted to an integer, <see langword="null"/> is returned instead.
        /// </summary>
        /// <param name="formData">The form data.</param>
        /// <param name="key">The key of the form data component.</param>
        /// <returns>The converted <see cref="long"/> value if a matching form data component is found and the
        /// conversion is successful; otherwise <see langword="null"/>.</returns>
        public static long? GetInt64OrNull(this IFormCollection? formData, string key) {
            return formData?[key].ToInt64OrNull();
        }

        /// <summary>
        /// Attempts to get the <see cref="long"/> value of the string component with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="formData">The form data.</param>
        /// <param name="key">The key of the form data component.</param>
        /// <param name="result">When this method returns, holds the <see cref="long"/> value if successful; otherwise, <c>0</c>.</param>
        /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetInt64(this IFormCollection? formData, string key, out long result) {
            return StringUtils.TryParseInt64(GetString(formData, key), out result);
        }

        /// <summary>
        /// Attempts to get the <see cref="long"/> value of the string component with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="formData">The form data.</param>
        /// <param name="key">The key of the form data component.</param>
        /// <param name="result">When this method returns, holds the <see cref="long"/> value if successful; otherwise, <see langword="null"/>.</param>
        /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetInt64(this IFormCollection? formData, string key, [NotNullWhen(true)] out long? result) {
            return StringUtils.TryParseInt64(GetString(formData, key), out result);
        }

        /// <summary>
        /// Returns a <see cref="long"/> array based of the values of each form data component with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="formData">The form data.</param>
        /// <param name="key">The key of the form data components.</param>
        /// <returns>A <see cref="long"/> array representing the converted values.</returns>
        /// <remarks>The value of each form data component may themselves be a separated list of <see cref="long"/>
        /// values - eg. separated by commas. Values that can not be converted to a corresponding <see cref="long"/>
        /// value will be ignored.</remarks>
        public static long[] GetInt64Array(this IFormCollection? formData, string key) {
            return formData == null ? Array.Empty<long>() : formData[key].ToInt64Array();
        }

        /// <summary>
        /// Returns a <see cref="long"/> list based of the values of each form data component with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="formData">The form data.</param>
        /// <param name="key">The key of the form data components.</param>
        /// <returns>A <see cref="long"/> list representing the converted values.</returns>
        /// <remarks>The value of each form data component may themselves be a separated list of <see cref="long"/>
        /// values - eg. separated by commas. Values that can not be converted to a corresponding <see cref="long"/>
        /// value will be ignored.</remarks>
        public static List<long> GetInt64List(this IFormCollection? formData, string key) {
            return formData?[key].ToInt64List() ?? new List<long>();
        }

        #endregion

        #region GetFloat...

        /// <summary>
        /// Gets the value of the first form data component with the specified <paramref name="key"/>, and returns
        /// the value as a <see cref="float"/>. If a matching form data component isn't found, or the value could
        /// not be converted to a <see cref="float"/>, <c>0</c> is returned instead.
        /// </summary>
        /// <param name="formData">The form data.</param>
        /// <param name="key">The key of the form data component.</param>
        /// <returns>The converted <see cref="float"/> value if a matching form data component is found and the
        /// conversion is successful; otherwise <c>0</c>.</returns>
        public static float GetFloat(this IFormCollection? formData, string key) {
            return formData == null ? 0 : formData[key].ToFloat();
        }

        /// <summary>
        /// Gets the value of the first form data component with the specified <paramref name="key"/>, and returns
        /// the value as a <see cref="float"/>. If a matching form data component isn't found, or the value could
        /// not be converted to a <see cref="float"/>, <paramref name="fallback"/> is returned instead.
        /// </summary>
        /// <param name="formData">The form data.</param>
        /// <param name="key">The key of the form data component.</param>
        /// <param name="fallback">The fallback value.</param>
        /// <returns>The converted <see cref="float"/> value if a matching form data component is found and the
        /// conversion is successful; otherwise <paramref name="fallback"/>.</returns>
        public static float GetFloat(this IFormCollection? formData, string key, float fallback) {
            return formData == null ? fallback : formData[key].ToFloat(fallback);
        }

        /// <summary>
        /// Gets the value of the first form data component with the specified <paramref name="key"/>, and returns
        /// the value as a <see cref="float"/>. If a matching form data component isn't found, or the value could not
        /// be converted to an integer, <see langword="null"/> is returned instead.
        /// </summary>
        /// <param name="formData">The form data.</param>
        /// <param name="key">The key of the form data component.</param>
        /// <returns>The converted <see cref="float"/> value if a matching form data component is found and the
        /// conversion is successful; otherwise <see langword="null"/>.</returns>
        public static float? GetFloatOrNull(this IFormCollection? formData, string key) {
            return formData?[key].ToFloatOrNull();
        }

        /// <summary>
        /// Attempts to get the <see cref="float"/> value of the string component with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="formData">The form data.</param>
        /// <param name="key">The key of the form data component.</param>
        /// <param name="result">When this method returns, holds the <see cref="float"/> value if successful; otherwise, <c>0</c>.</param>
        /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetFloat(this IFormCollection? formData, string key, out float result) {
            return StringUtils.TryParseFloat(GetString(formData, key), out result);
        }

        /// <summary>
        /// Attempts to get the <see cref="float"/> value of the string component with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="formData">The form data.</param>
        /// <param name="key">The key of the form data component.</param>
        /// <param name="result">When this method returns, holds the <see cref="float"/> value if successful; otherwise, <see langword="null"/>.</param>
        /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetFloat(this IFormCollection? formData, string key, [NotNullWhen(true)] out float? result) {
            return StringUtils.TryParseFloat(GetString(formData, key), out result);
        }

        /// <summary>
        /// Returns a <see cref="float"/> array based on the values of each form data component with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="formData">The form data.</param>
        /// <param name="key">The key of the form data components.</param>
        /// <returns>A <see cref="float"/> array representing the converted values.</returns>
        /// <remarks>The value of each form data component may themselves be a separated list of <see cref="float"/>
        /// values - eg. separated by commas. Values that can not be converted to a corresponding <see cref="float"/>
        /// value will be ignored.</remarks>
        public static float[] GetFloatArray(this IFormCollection? formData, string key) {
            return formData?[key].ToFloatArray() ?? Array.Empty<float>();
        }

        /// <summary>
        /// Returns a <see cref="float"/> list based on the values of each form data component with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="formData">The form data.</param>
        /// <param name="key">The key of the form data components.</param>
        /// <returns>A <see cref="float"/> list representing the converted values.</returns>
        /// <remarks>The value of each form data component may themselves be a separated list of <see cref="float"/>
        /// values - eg. separated by commas. Values that can not be converted to a corresponding <see cref="float"/>
        /// value will be ignored.</remarks>
        public static List<float> GetFloatList(this IFormCollection? formData, string key) {
            return formData?[key].ToFloatList() ?? new List<float>();
        }

        #endregion

        #region GetDouble...

        /// <summary>
        /// Gets the value of the first form data component with the specified <paramref name="key"/>, and returns
        /// the value as a <see cref="double"/>. If a matching form data component isn't found, or the value could
        /// not be converted to a <see cref="double"/>, <c>0</c> is returned instead.
        /// </summary>
        /// <param name="formData">The form data.</param>
        /// <param name="key">The key of the form data component.</param>
        /// <returns>The converted <see cref="double"/> value if a matching form data component is found and the
        /// conversion is successful; otherwise <c>0</c>.</returns>
        public static double GetDouble(this IFormCollection? formData, string key) {
            return formData == null ? 0 : formData[key].ToDouble();
        }

        /// <summary>
        /// Gets the value of the first form data component with the specified <paramref name="key"/>, and returns
        /// the value as a <see cref="double"/>. If a matching form data component isn't found, or the value could
        /// not be converted to a <see cref="double"/>, <paramref name="fallback"/> is returned instead.
        /// </summary>
        /// <param name="formData">The form data.</param>
        /// <param name="key">The key of the form data component.</param>
        /// <param name="fallback">The fallback value.</param>
        /// <returns>The converted <see cref="double"/> value if a matching form data component is found and the
        /// conversion is successful; otherwise <paramref name="fallback"/>.</returns>
        public static double GetDouble(this IFormCollection? formData, string key, double fallback) {
            return formData == null ? fallback : formData[key].ToDouble(fallback);
        }

        /// <summary>
        /// Gets the value of the first form data component with the specified <paramref name="key"/>, and returns
        /// the value as a <see cref="double"/>. If a matching form data component isn't found, or the value could not
        /// be converted to an integer, <see langword="null"/> is returned instead.
        /// </summary>
        /// <param name="formData">The form data.</param>
        /// <param name="key">The key of the form data component.</param>
        /// <returns>The converted <see cref="double"/> value if a matching form data component is found and the
        /// conversion is successful; otherwise <see langword="null"/>.</returns>
        public static double? GetDoubleOrNull(this IFormCollection? formData, string key) {
            return formData?[key].ToDoubleOrNull();
        }

        /// <summary>
        /// Attempts to get the <see cref="double"/> value of the string component with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="formData">The form data.</param>
        /// <param name="key">The key of the form data component.</param>
        /// <param name="result">When this method returns, holds the <see cref="double"/> value if successful; otherwise, <c>0</c>.</param>
        /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetDouble(this IFormCollection? formData, string key, out double result) {
            return StringUtils.TryParseDouble(GetString(formData, key), out result);
        }

        /// <summary>
        /// Attempts to get the <see cref="double"/> value of the string component with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="formData">The form data.</param>
        /// <param name="key">The key of the form data component.</param>
        /// <param name="result">When this method returns, holds the <see cref="double"/> value if successful; otherwise, <see langword="null"/>.</param>
        /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetDouble(this IFormCollection? formData, string key, [NotNullWhen(true)] out double? result) {
            return StringUtils.TryParseDouble(GetString(formData, key), out result);
        }

        /// <summary>
        /// Returns a <see cref="double"/> array based on the values of each form data component with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="formData">The form data.</param>
        /// <param name="key">The key of the form data components.</param>
        /// <returns>A <see cref="double"/> array representing the converted values.</returns>
        /// <remarks>The value of each form data component may themselves be a separated list of <see cref="double"/>
        /// values - eg. separated by commas. Values that can not be converted to a corresponding <see cref="double"/>
        /// value will be ignored.</remarks>
        public static double[] GetDoubleArray(this IFormCollection? formData, string key) {
            return formData == null ? Array.Empty<double>() : formData[key].ToDoubleArray();
        }

        /// <summary>
        /// Returns a <see cref="double"/> list based on the values of each form data component with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="formData">The form data.</param>
        /// <param name="key">The key of the form data components.</param>
        /// <returns>A <see cref="double"/> list representing the converted values.</returns>
        /// <remarks>The value of each form data component may themselves be a separated list of <see cref="double"/>
        /// values - eg. separated by commas. Values that can not be converted to a corresponding <see cref="double"/>
        /// value will be ignored.</remarks>
        public static List<double> GetDoubleList(this IFormCollection? formData, string key) {
            return formData?[key].ToDoubleList() ?? new List<double>();
        }

        #endregion

        #region GetBoolean...

        /// <summary>
        /// Gets the value of the first form data component with the specified <paramref name="key"/>, and returns
        /// the value as a <see cref="bool"/>. If a matching form data component isn't found, or the value could not
        /// be converted to a <see cref="bool"/>, <c>false</c> is returned instead.
        /// </summary>
        /// <param name="formData">The form data.</param>
        /// <param name="key">The key of the form data component.</param>
        /// <returns>The converted <see cref="bool"/> value if a matching form data component is found and the
        /// conversion is successful; otherwise <c>false</c>.</returns>
        public static bool GetBoolean(this IFormCollection? formData, string key) {
            return formData != null && formData[key].ToBoolean();
        }

        /// <summary>
        /// Gets the value of the first form data component with the specified <paramref name="key"/>, and returns
        /// the value as a <see cref="bool"/>. If a matching form data component isn't found, or the value could not
        /// be converted to a <see cref="bool"/>, <paramref name="fallback"/> is returned instead.
        /// </summary>
        /// <param name="formData">The form data.</param>
        /// <param name="key">The key of the form data component.</param>
        /// <param name="fallback">The fallback value.</param>
        /// <returns>The converted <see cref="bool"/> value if a matching form data component is found and the
        /// conversion is successful; otherwise <paramref name="fallback"/>.</returns>
        public static bool GetBoolean(this IFormCollection? formData, string key, bool fallback) {
            return formData == null ? fallback : formData[key].ToBoolean(fallback);
        }

        /// <summary>
        /// Gets the value of the first form data component with the specified <paramref name="key"/>, and returns
        /// the value as a <see cref="bool"/>. If a matching form data component isn't found, or the value could not
        /// be converted to an integer, <see langword="null"/> is returned instead.
        /// </summary>
        /// <param name="formData">The form data.</param>
        /// <param name="key">The key of the form data component.</param>
        /// <returns>The converted <see cref="bool"/> value if a matching form data component is found and the
        /// conversion is successful; otherwise <see langword="null"/>.</returns>
        public static bool? GetBooleanOrNull(this IFormCollection? formData, string key) {
            return formData?[key].ToBooleanOrNull();
        }

        /// <summary>
        /// Attempts to get the <see cref="bool"/> value of the string component with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="formData">The form data.</param>
        /// <param name="key">The key of the form data component.</param>
        /// <param name="result">When this method returns, holds the <see cref="bool"/> value if successful; otherwise, <see langword="false"/>.</param>
        /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetBoolean(this IFormCollection? formData, string key, out bool result) {
            return StringUtils.TryParseBoolean(GetString(formData, key), out result);
        }

        /// <summary>
        /// Attempts to get the <see cref="bool"/> value of the string component with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="formData">The form data.</param>
        /// <param name="key">The key of the form data component.</param>
        /// <param name="result">When this method returns, holds the <see cref="bool"/> value if successful; otherwise, <see langword="null"/>.</param>
        /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetBoolean(this IFormCollection? formData, string key, [NotNullWhen(true)] out bool? result) {
            return StringUtils.TryParseBoolean(GetString(formData, key), out result);
        }

        #endregion

        #region GetGuid...

        /// <summary>
        /// Gets the value of the first form data component with the specified <paramref name="key"/>, and returns
        /// the value as a <see cref="Guid"/>. If a matching form data component isn't found, or the value could not
        /// be converted to a <see cref="Guid"/>, <see cref="Guid.Empty"/> is returned instead.
        /// </summary>
        /// <param name="formData">The form data.</param>
        /// <param name="key">The key of the form data component.</param>
        /// <returns>The converted <see cref="Guid"/> value if a matching form data component is found and the
        /// conversion is successful; otherwise, <see cref="Guid.Empty"/>.</returns>
        public static Guid GetGuid(this IFormCollection? formData, string key) {
            return formData == null ? Guid.Empty : formData[key].ToGuid();
        }

        /// <summary>
        /// Gets the value of the first form data component with the specified <paramref name="key"/>, and returns
        /// the value as a <see cref="Guid"/>. If a matching form data component isn't found, or the value could not
        /// be converted to a <see cref="Guid"/>, <paramref name="fallback"/> is returned instead.
        /// </summary>
        /// <param name="formData">The form data.</param>
        /// <param name="key">The key of the form data component.</param>
        /// <param name="fallback">The fallback value.</param>
        /// <returns>The converted <see cref="Guid"/> value if a matching form data component is found and the
        /// conversion is successful; otherwise, <paramref name="fallback"/>.</returns>
        public static Guid GetGuid(this IFormCollection? formData, string key, Guid fallback) {
            return formData == null ? fallback : formData[key].ToGuid(fallback);
        }

        /// <summary>
        /// Gets the value of the first form data component with the specified <paramref name="key"/>, and returns
        /// the value as a <see cref="Guid"/>. If a matching form data component isn't found, or the value could not
        /// be converted to a <see cref="Guid"/>, <see langword="null"/> is returned instead.
        /// </summary>
        /// <param name="formData">The form data.</param>
        /// <param name="key">The key of the form data component.</param>
        /// <returns>The converted <see cref="Guid"/> value if a matching form data component is found and the
        /// conversion is successful; otherwise, <see langword="null"/>.</returns>
        public static Guid? GetGuidOrNull(this IFormCollection? formData, string key) {
            return formData?[key].ToGuidOrNull();
        }

        /// <summary>
        /// Returns an array of <see cref="Guid"/> values based on the values of each form data component with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="formData">The form data.</param>
        /// <param name="key">The key of the form data component.</param>
        /// <returns>An instance of <see cref="List{Guid}"/>.</returns>
        public static Guid[] GetGuidArray(this IFormCollection? formData, string key) {
            return formData?[key].ToGuidArray() ?? Array.Empty<Guid>();
        }

        /// <summary>
        /// Returns a list of <see cref="Guid"/> values based on the values of each form data component with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="formData">The form data.</param>
        /// <param name="key">The key of the form data component.</param>
        /// <returns>An instance of <see cref="List{Guid}"/>.</returns>
        public static List<Guid> GetGuidList(this IFormCollection? formData, string key) {
            return formData?[key].ToGuidList() ?? new List<Guid>();
        }

        /// <summary>
        /// Attempts to get the <see cref="Guid"/> value of the string component with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="formData">The form data.</param>
        /// <param name="key">The key of the form data component.</param>
        /// <param name="result">When this method returns, holds the <see cref="Guid"/> value if successful; otherwise, <see cref="Guid.Empty"/>.</param>
        /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetGuid(this IFormCollection? formData, string key, out Guid result) {
            return StringUtils.TryParseGuid(GetString(formData, key), out result);
        }

        /// <summary>
        /// Attempts to get the <see cref="bool"/> value of the string component with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="formData">The form data.</param>
        /// <param name="key">The key of the form data component.</param>
        /// <param name="result">When this method returns, holds the <see cref="Guid"/> value if successful; otherwise, <see langword="null"/>.</param>
        /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetGuid(this IFormCollection? formData, string key, [NotNullWhen(true)] out Guid? result) {
            return StringUtils.TryParseGuid(GetString(formData, key), out result);
        }

        #endregion

        #region GetEnum...

        /// <summary>
        /// Returns the corresponding <typeparamref name="TEnum"/> value of the first form data component with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="formData">The form data.</param>
        /// <param name="key">The key of the form data component.</param>
        /// <returns>The converted <typeparamref name="TEnum"/> value if a matching form data component is found and the
        /// conversion is successful; otherwise, the default value of <typeparamref name="TEnum"/>.</returns>
        public static TEnum GetEnum<TEnum>(this IFormCollection? formData, string key) where TEnum : struct, Enum {
            return (formData?[key]).ToEnum<TEnum>();
        }

        /// <summary>
        /// Returns the corresponding <typeparamref name="TEnum"/> value of the first form data component with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="formData">The form data.</param>
        /// <param name="key">The key of the form data component.</param>
        /// <param name="fallback">The fallback value in case a value isn't found or cant be converted.</param>
        /// <returns>The converted <typeparamref name="TEnum"/> value if a matching form data component is found and the
        /// conversion is successful; otherwise, <paramref name="fallback"/>.</returns>
        public static TEnum GetEnum<TEnum>(this IFormCollection? formData, string key, TEnum fallback) where TEnum : struct, Enum {
            return (formData?[key]).ToEnum(fallback);
        }

        /// <summary>
        /// Returns the corresponding <typeparamref name="TEnum"/> value of the first form data component with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="formData">The form data.</param>
        /// <param name="key">The key of the form data component.</param>
        /// <returns>The converted <typeparamref name="TEnum"/> value if a matching form data component is found and the
        /// conversion is successful; otherwise, <see langword="null"/>.</returns>
        public static TEnum? GetEnumOrNull<TEnum>(this IFormCollection? formData, string key) where TEnum : struct, Enum {
            return (formData?[key]).ToEnumOrNull<TEnum>();
        }

        /// <summary>
        /// Returns an array of <typeparamref name="TEnum"/> values representing the values of each form data component
        /// matching the specified <paramref name="key"/>.
        ///
        /// Notice that this method support both multiple form data components with the same <paramref name="key"/>
        /// as well as form data components where the value is a comma separated string or similar. Supported
        /// separators are comma (<c>,</c>), space (<c> </c>), carriage return (<c>\r</c>), new line (<c>\n</c>) and
        /// tab (<c>\t</c>).
        /// </summary>
        /// <param name="formData">The form data.</param>
        /// <param name="key">The key of the form data component(s).</param>
        /// <returns>An array of <typeparamref name="TEnum"/>.</returns>
        public static TEnum[] GetEnumArray<TEnum>(this IFormCollection? formData, string key) where TEnum : struct, Enum {
            return (formData?[key]).ToEnumArray<TEnum>();
        }

        /// <summary>
        /// Returns an array of <typeparamref name="TEnum"/> values representing the values of each form data component
        /// matching the specified <paramref name="key"/>.
        ///
        /// Notice that this method support both multiple form data components with the same <paramref name="key"/>
        /// as well as form data components where the value is separated by one of the following <paramref name="separators"/>.
        /// </summary>
        /// <param name="formData">The form data.</param>
        /// <param name="key">The key of the form data component(s).</param>
        /// <param name="separators">An array of supported separators.</param>
        /// <returns>An array of <typeparamref name="TEnum"/>.</returns>
        public static TEnum[] GetEnumArray<TEnum>(this IFormCollection? formData, string key, params char[] separators) where TEnum : struct, Enum {
            return (formData?[key]).ToEnumArray<TEnum>(separators);
        }

        /// <summary>
        /// Returns a list of <typeparamref name="TEnum"/> values representing the values of each form data component
        /// matching the specified <paramref name="key"/>.
        ///
        /// Notice that this method support both multiple form data components with the same <paramref name="key"/>
        /// as well as form data components where the value is a comma separated string or similar. Supported
        /// separators are comma (<c>,</c>), space (<c> </c>), carriage return (<c>\r</c>), new line (<c>\n</c>) and
        /// tab (<c>\t</c>).
        /// </summary>
        /// <param name="formData">The form data.</param>
        /// <param name="key">The key of the form data component(s).</param>
        /// <returns>A list of <typeparamref name="TEnum"/>.</returns>
        public static List<TEnum> GetEnumList<TEnum>(this IFormCollection? formData, string key) where TEnum : struct, Enum {
            return (formData?[key]).ToEnumList<TEnum>();
        }

        /// <summary>
        /// Returns a list of <typeparamref name="TEnum"/> values representing the values of each form data component
        /// matching the specified <paramref name="key"/>.
        ///
        /// Notice that this method support both multiple form data components with the same <paramref name="key"/>
        /// as well as form data components where the value is separated by one of the following <paramref name="separators"/>.
        /// </summary>
        /// <param name="formData">The form data.</param>
        /// <param name="key">The key of the form data component(s).</param>
        /// <param name="separators">An array of supported separators.</param>
        /// <returns>A list of <typeparamref name="TEnum"/>.</returns>
        public static List<TEnum> GetEnumList<TEnum>(this IFormCollection? formData, string key, params char[] separators) where TEnum : struct, Enum {
            return (formData?[key]).ToEnumList<TEnum>(separators);
        }

        /// <summary>
        /// Attempts to get the enum value of type <typeparamref name="TEnum"/> from the first form data component with the specified <paramref name="key"/>.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="formData">The form data.</param>
        /// <param name="key">The key of the form data component.</param>
        /// <param name="result">When this method returns, contains the parsed <typeparamref name="TEnum"/> value if successful; otherwise, <see langword="null"/>. This parameter is passed uninitialized.</param>
        /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetEnum<TEnum>(this IFormCollection? formData, string key, out TEnum result) where TEnum : struct, Enum {
            result = default;
            return TryGetString(formData, key, out string? value) && EnumUtils.TryParseEnum(value, out result);
        }

        /// <summary>
        /// Attempts to get the enum value of type <typeparamref name="TEnum"/> from the header with the specified <paramref name="key"/>.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="formData">The form data.</param>
        /// <param name="key">The key of the form data component.</param>
        /// <param name="result">When this method returns, contains the parsed <typeparamref name="TEnum"/> value if successful; otherwise, the default value of <typeparamref name="TEnum"/>. This parameter is passed uninitialized.</param>
        /// <returns><see langword="true"/> if successful; otherwise, <see langword="false"/>.</returns>
        public static bool TryGetEnum<TEnum>(this IFormCollection? formData, string key, out TEnum? result) where TEnum : struct, Enum {
            result = null;
            return TryGetString(formData, key, out string? value) && EnumUtils.TryParseEnum(value, out result);
        }

        #endregion

    }

}