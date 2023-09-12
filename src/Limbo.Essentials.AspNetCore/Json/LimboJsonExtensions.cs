using System.Net;

namespace Limbo.Essentials.AspNetCore.Json {

    /// <summary>
    /// Static class with various extension methods for the Limbo JSON implementation.
    /// </summary>
    public static class LimboJsonExtensions {

        /// <summary>
        /// Sets the <c>data</c> part of <paramref name="body"/>.
        /// </summary>
        /// <typeparam name="T">The type of the body.</typeparam>
        /// <param name="body">The body.</param>
        /// <param name="data">The value for the data part.</param>
        /// <returns>An instance of <typeparamref name="T"/> - useful for method chaining.</returns>
        public static T SetData<T>(this T body, object? data) where T : LimboJsonMetaResult {
            body.Data = data;
            return body;
        }

        /// <summary>
        /// Set the error message of the <paramref name="body"/>'s meta object.
        /// </summary>
        /// <typeparam name="T">The type of the body.</typeparam>
        /// <param name="body">The body.</param>
        /// <param name="error">The error message.</param>
        /// <returns>An instance of <typeparamref name="T"/> - useful for method chaining.</returns>
        public static T SetErrorMessage<T>(this T body, string? error) where T : LimboJsonMetaResult {
            body.Meta.Error = error;
            return body;
        }

        /// <summary>
        /// Sets the pagination of the specified <paramref name="body"/> object.
        /// </summary>
        /// <typeparam name="T">The type of the body.</typeparam>
        /// <param name="body">The body.</param>
        /// <param name="total">The total amount of items.</param>
        /// <param name="limit">The limit.</param>
        /// <param name="offset">The offset.</param>
        /// <returns>An instance of <typeparamref name="T"/> - useful for method chaining.</returns>
        public static T SetPagination<T>(this T body, long total, long limit, long offset) where T : LimboJsonMetaResult {
            body.Pagination = new LimboJsonPagination(total, limit, offset);
            return body;
        }

        /// <summary>
        /// Sets the pagination of the specified <paramref name="body"/> object.
        /// </summary>
        /// <typeparam name="T">The type of the body.</typeparam>
        /// <param name="body">The body.</param>
        /// <param name="pagination"></param>
        /// <returns>An instance of <typeparamref name="T"/> - useful for method chaining.</returns>
        public static T SetPagination<T>(this T body, ILimboJsonPagination? pagination) where T : LimboJsonMetaResult {
            body.Pagination = pagination;
            return body;
        }

        /// <summary>
        /// Set the HTTP status code of the <paramref name="body"/>'s meta object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="body">The body.</param>
        /// <param name="statusCode">The HTTP status code.</param>
        /// <returns>An instance of <typeparamref name="T"/> - useful for method chaining.</returns>
        public static T SetStatusCode<T>(this T body, HttpStatusCode statusCode) where T : LimboJsonMetaResult {
            body.Meta.Code = statusCode;
            return body;
        }

    }

}