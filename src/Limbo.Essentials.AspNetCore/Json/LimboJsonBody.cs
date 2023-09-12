using System.Net;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Limbo.Essentials.AspNetCore.Json {

    /// <summary>
    /// Class representing the body of a JSON response.
    /// </summary>
    public class LimboJsonBody {

        #region Properties

        /// <summary>
        /// Gets or sets the meta data for the response.
        /// </summary>
        [JsonProperty(PropertyName = "meta", Order = -200)]
        public LimboJsonMetaData Meta { get; set; } = new();

        /// <summary>
        /// Gets or sets pagination information.
        /// </summary>
        [JsonProperty(PropertyName = "pagination", Order = -150, NullValueHandling = NullValueHandling.Ignore)]
        [System.Text.Json.Serialization.JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ILimboJsonPagination? Pagination { get; set; }

        /// <summary>
        /// Gets or sets the data object.
        /// </summary>
        [JsonProperty(PropertyName = "data", Order = -100, NullValueHandling = NullValueHandling.Ignore)]
        [System.Text.Json.Serialization.JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public object? Data { get; set; }

        #endregion

        #region Member methods

        /// <summary>
        /// Returns a new <see cref="LimboJsonResult"/> wapping this <see cref="LimboJsonBody"/> instance.
        /// </summary>
        /// <returns>An instance of <see cref="LimboJsonResult"/>.</returns>
        public LimboJsonResult AsResult() {
            return new LimboJsonResult(this, Meta.Code);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Creates and returns a new <see cref="LimboJsonBody"/> with a <see cref="HttpStatusCode.OK"/> HTTP status code.
        /// </summary>
        /// <param name="data">The value for the <see cref="Data"/> part of the response body.</param>
        /// <returns>An instance of <see cref="LimboJsonBody"/>.</returns>
        public static LimboJsonBody Ok(object? data) {
            return new LimboJsonBody { Data = data };
        }

        /// <summary>
        /// Creates and returns a new <see cref="LimboJsonBody"/> with a <see cref="HttpStatusCode.OK"/> HTTP status code.
        /// </summary>
        /// <param name="data">The value for the <see cref="Data"/> part of the response body.</param>
        /// <param name="pagination">An object with pagination information.</param>
        /// <returns>An instance of <see cref="LimboJsonBody"/>.</returns>
        public static LimboJsonBody Ok(object? data, ILimboJsonPagination? pagination) {
            return new LimboJsonBody { Data = data, Pagination = pagination };
        }

        /// <summary>
        /// Creates and returns a new <see cref="LimboJsonBody"/> with a <see cref="HttpStatusCode.Created"/> HTTP status code.
        /// </summary>
        /// <param name="data">The value for the <see cref="Data"/> part of the response body.</param>
        /// <returns>An instance of <see cref="LimboJsonBody"/>.</returns>
        public static LimboJsonBody Created(object? data) {
            return new LimboJsonBody { Data = data, Meta = { Code = HttpStatusCode.Created } };
        }

        /// <summary>
        /// Creates and returns a new <see cref="LimboJsonBody"/> with a <see cref="HttpStatusCode.BadRequest"/> HTTP status code.
        /// </summary>
        /// <param name="error">An error message.</param>
        /// <returns>An instance of <see cref="LimboJsonBody"/>.</returns>
        public static LimboJsonBody BadRequest(string? error) {
            return BadRequest(error, null);
        }

        /// <summary>
        /// Creates and returns a new <see cref="LimboJsonBody"/> with a <see cref="HttpStatusCode.BadRequest"/> HTTP status code.
        /// </summary>
        /// <param name="error">An error message.</param>
        /// <param name="data">The value for the <see cref="Data"/> part of the response body.</param>
        /// <returns>An instance of <see cref="LimboJsonBody"/>.</returns>
        public static LimboJsonBody BadRequest(string? error, object? data) {
            return new LimboJsonBody { Data = data, Meta = { Code = HttpStatusCode.BadRequest, Error = error } };
        }

        /// <summary>
        /// Creates and returns a new <see cref="LimboJsonBody"/> with a <see cref="HttpStatusCode.Unauthorized"/> HTTP status code.
        /// </summary>
        /// <param name="error">An error message.</param>
        /// <returns>An instance of <see cref="LimboJsonBody"/>.</returns>
        public static LimboJsonBody Unauthorized(string? error) {
            return Unauthorized(error, null);
        }

        /// <summary>
        /// Creates and returns a new <see cref="LimboJsonBody"/> with a <see cref="HttpStatusCode.Unauthorized"/> HTTP status code.
        /// </summary>
        /// <param name="error">An error message.</param>
        /// <param name="data">The value for the <see cref="Data"/> part of the response body.</param>
        /// <returns>An instance of <see cref="LimboJsonBody"/>.</returns>
        public static LimboJsonBody Unauthorized(string? error, object? data) {
            return new LimboJsonBody { Data = data, Meta = { Code = HttpStatusCode.Unauthorized, Error = error } };
        }

        /// <summary>
        /// Creates and returns a new <see cref="LimboJsonBody"/> with a <see cref="HttpStatusCode.Forbidden"/> HTTP status code.
        /// </summary>
        /// <param name="error">An error message.</param>
        /// <returns>An instance of <see cref="LimboJsonBody"/>.</returns>
        public static LimboJsonBody Forbidden(string? error) {
            return Forbidden(error, null);
        }

        /// <summary>
        /// Creates and returns a new <see cref="LimboJsonBody"/> with a <see cref="HttpStatusCode.Forbidden"/> HTTP status code.
        /// </summary>
        /// <param name="error">An error message.</param>
        /// <param name="data">The value for the <see cref="Data"/> part of the response body.</param>
        /// <returns>An instance of <see cref="LimboJsonBody"/>.</returns>
        public static LimboJsonBody Forbidden(string? error, object? data) {
            return new LimboJsonBody { Data = data, Meta = { Code = HttpStatusCode.Forbidden, Error = error } };
        }

        /// <summary>
        /// Creates and returns a new <see cref="LimboJsonBody"/> with a <see cref="HttpStatusCode.NotFound"/> HTTP status code.
        /// </summary>
        /// <param name="error">An error message.</param>
        /// <returns>An instance of <see cref="LimboJsonBody"/>.</returns>
        public static LimboJsonBody NotFound(string? error) {
            return NotFound(error, null);
        }

        /// <summary>
        /// Creates and returns a new <see cref="LimboJsonBody"/> with a <see cref="HttpStatusCode.NotFound"/> HTTP status code.
        /// </summary>
        /// <param name="error">An error message.</param>
        /// <param name="data">The value for the <see cref="Data"/> part of the response body.</param>
        /// <returns>An instance of <see cref="LimboJsonBody"/>.</returns>
        public static LimboJsonBody NotFound(string? error, object? data) {
            return new LimboJsonBody { Data = data, Meta = { Code = HttpStatusCode.NotFound, Error = error } };
        }

        /// <summary>
        /// Creates and returns a new <see cref="LimboJsonBody"/> with a <see cref="HttpStatusCode.InternalServerError"/> HTTP status code.
        /// </summary>
        /// <param name="error">An error message.</param>
        /// <returns>An instance of <see cref="LimboJsonBody"/>.</returns>
        public static LimboJsonBody InternalServerError(string? error) {
            return InternalServerError(error, null);
        }

        /// <summary>
        /// Creates and returns a new <see cref="LimboJsonBody"/> with a <see cref="HttpStatusCode.InternalServerError"/> HTTP status code.
        /// </summary>
        /// <param name="error">An error message.</param>
        /// <param name="data">The value for the <see cref="Data"/> part of the response body.</param>
        /// <returns>An instance of <see cref="LimboJsonBody"/>.</returns>
        public static LimboJsonBody InternalServerError(string? error, object? data) {
            return new LimboJsonBody { Data = data, Meta = { Code = HttpStatusCode.InternalServerError, Error = error } };
        }

        #endregion

    }

}