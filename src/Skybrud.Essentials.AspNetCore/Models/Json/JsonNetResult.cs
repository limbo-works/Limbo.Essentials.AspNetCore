using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Skybrud.Essentials.AspNetCore.Models.Json {

    /// <summary>
    /// Class representing a JOSN based result serialized using <strong>Newtonsoft.Json</strong>.
    /// </summary>
    [Obsolete("Use the 'NewtonsoftJsonNetResult' class instead.")]
    public class JsonNetResult : ContentResult {

        #region Constructors

        /// <summary>
        /// Initializes a new <strong>200 OK</strong> result wrapping the specified <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The value/body of the result. The value will be serialized to JSON before being returned to the client.</param>
        public JsonNetResult(object value) : this(HttpStatusCode.OK, value) { }

        /// <summary>
        /// Initializes a new result with <paramref name="status"/> wrapping the specified <paramref name="value"/>.
        /// </summary>
        /// <param name="status">The HTTP status code.</param>
        /// <param name="value">The value/body of the result. The value will be serialized to JSON before being returned to the client.</param>
        public JsonNetResult(HttpStatusCode status, object value) {

            // Serialize the data to a JSON string using JSON.net
            string json = JsonConvert.SerializeObject(value, Formatting.None);

            StatusCode = (int) status;
            ContentType = "application/json";
            Content = json;

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns a new <strong>200 OK</strong> result with the specified <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The value/body of the result. The value will be serialized to JSON before being returned to the client.</param>
        /// <returns>An instance of <see cref="JsonNetResult"/>.</returns>
        public static JsonNetResult Ok(object value) {
            return new JsonNetResult(HttpStatusCode.OK, value);
        }

        /// <summary>
        /// Returns a new <strong>201 Created</strong> result with the specified <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The value/body of the result. The value will be serialized to JSON before being returned to the client.</param>
        /// <returns>An instance of <see cref="JsonNetResult"/>.</returns>
        public static JsonNetResult Created(object value) {
            return new JsonNetResult(HttpStatusCode.Created, value);
        }

        /// <summary>
        /// Returns a new <strong>400 Bad Request</strong> result with the specified <paramref name="error"/> message.
        /// </summary>
        /// <param name="error">A message describing the error.</param>
        /// <returns>An instance of <see cref="JsonNetResult"/>.</returns>
        public static JsonNetResult BadRequest(string error) {
            JsonBody body = new(HttpStatusCode.BadRequest, error, null);
            return new JsonNetResult(HttpStatusCode.BadRequest, body);
        }

        /// <summary>
        /// Returns a new <strong>401 Unauthorized</strong> result with the specified <paramref name="error"/> message.
        /// </summary>
        /// <param name="error">A message describing the error.</param>
        /// <returns>An instance of <see cref="JsonNetResult"/>.</returns>
        public static JsonNetResult Unauthorized(string error) {
            JsonBody body = new(HttpStatusCode.Unauthorized, error, null);
            return new JsonNetResult(HttpStatusCode.Unauthorized, body);
        }

        /// <summary>
        /// Returns a new <strong>403 Forbidden</strong> result with the specified <paramref name="error"/> message.
        /// </summary>
        /// <param name="error">A message describing the error.</param>
        /// <returns>An instance of <see cref="JsonNetResult"/>.</returns>
        public static JsonNetResult Forbidden(string error) {
            JsonBody body = new(HttpStatusCode.Forbidden, error, null);
            return new JsonNetResult(HttpStatusCode.Forbidden, body);
        }

        /// <summary>
        /// Returns a new <strong>404 Not Found</strong> result with the specified <paramref name="error"/> message.
        /// </summary>
        /// <param name="error">A message describing the error.</param>
        /// <returns>An instance of <see cref="JsonNetResult"/>.</returns>
        public static JsonNetResult NotFound(string error) {
            JsonBody body = new(HttpStatusCode.NotFound, error, null);
            return new JsonNetResult(HttpStatusCode.NotFound, body);
        }

        /// <summary>
        /// Returns a new <strong>500 Internal Server Error</strong> result with the specified <paramref name="error"/> message.
        /// </summary>
        /// <param name="error">A message describing the error.</param>
        /// <returns>An instance of <see cref="JsonNetResult"/>.</returns>
        public static JsonNetResult InternalError(string error) {
            JsonBody body = new(HttpStatusCode.InternalServerError, error, null);
            return new JsonNetResult(HttpStatusCode.InternalServerError, body);
        }

        #endregion

    }

}