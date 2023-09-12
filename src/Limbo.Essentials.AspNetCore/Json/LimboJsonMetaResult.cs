using System.Net;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using System;

namespace Limbo.Essentials.AspNetCore.Json {

    /// <summary>
    /// Class representing the body of a JSON response.
    /// </summary>
    public class LimboJsonMetaResult : ActionResult, IStatusCodeActionResult {

        #region Properties

        /// <summary>
        /// Gets or sets the HTTP status code.
        /// </summary>
        [global::Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public HttpStatusCode StatusCode { get; set; }

        int? IStatusCodeActionResult.StatusCode => (int) StatusCode;

        /// <summary>
        /// Gets or sets the meta data for the response.
        /// </summary>
        [JsonProperty(PropertyName = "meta", Order = -200)]
        [JsonPropertyName("meta")]
        [JsonPropertyOrder(-200)]
        public LimboJsonMetaData Meta { get; set; } = new();

        /// <summary>
        /// Gets or sets pagination information.
        /// </summary>
        [JsonProperty(PropertyName = "pagination", Order = -150, NullValueHandling = NullValueHandling.Ignore)]
        [System.Text.Json.Serialization.JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("pagination")]
        [JsonPropertyOrder(-150)]
        public ILimboJsonPagination? Pagination { get; set; }

        /// <summary>
        /// Gets or sets the data object.
        /// </summary>
        [JsonProperty(PropertyName = "data", Order = -100, NullValueHandling = NullValueHandling.Ignore)]
        [System.Text.Json.Serialization.JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("data")]
        [JsonPropertyOrder(-100)]
        public object? Data { get; set; }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public override Task ExecuteResultAsync(ActionContext context) {
            ArgumentNullException.ThrowIfNull(context);
            var services = context.HttpContext.RequestServices;
            var executor = services.GetRequiredService<IActionResultExecutor<JsonResult>>();
            return executor.ExecuteAsync(context, new JsonResult(this) {
                StatusCode = (int) Meta.Code
            });
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Creates and returns a new <see cref="LimboJsonMetaResult"/> with a <see cref="HttpStatusCode.OK"/> HTTP status code.
        /// </summary>
        /// <param name="data">The value for the <see cref="Data"/> part of the response body.</param>
        /// <returns>An instance of <see cref="LimboJsonMetaResult"/>.</returns>
        public static LimboJsonMetaResult Ok(object? data) {
            return new LimboJsonMetaResult { Data = data };
        }

        /// <summary>
        /// Creates and returns a new <see cref="LimboJsonMetaResult"/> with a <see cref="HttpStatusCode.OK"/> HTTP status code.
        /// </summary>
        /// <param name="data">The value for the <see cref="Data"/> part of the response body.</param>
        /// <param name="pagination">An object with pagination information.</param>
        /// <returns>An instance of <see cref="LimboJsonMetaResult"/>.</returns>
        public static LimboJsonMetaResult Ok(object? data, ILimboJsonPagination? pagination) {
            return new LimboJsonMetaResult { Data = data, Pagination = pagination };
        }

        /// <summary>
        /// Creates and returns a new <see cref="LimboJsonMetaResult"/> with a <see cref="HttpStatusCode.Created"/> HTTP status code.
        /// </summary>
        /// <param name="data">The value for the <see cref="Data"/> part of the response body.</param>
        /// <returns>An instance of <see cref="LimboJsonMetaResult"/>.</returns>
        public static LimboJsonMetaResult Created(object? data) {
            return new LimboJsonMetaResult { Data = data, Meta = { Code = HttpStatusCode.Created } };
        }

        /// <summary>
        /// Creates and returns a new <see cref="LimboJsonMetaResult"/> with a <see cref="HttpStatusCode.BadRequest"/> HTTP status code.
        /// </summary>
        /// <param name="error">An error message.</param>
        /// <returns>An instance of <see cref="LimboJsonMetaResult"/>.</returns>
        public static LimboJsonMetaResult BadRequest(string? error) {
            return BadRequest(error, null);
        }

        /// <summary>
        /// Creates and returns a new <see cref="LimboJsonMetaResult"/> with a <see cref="HttpStatusCode.BadRequest"/> HTTP status code.
        /// </summary>
        /// <param name="error">An error message.</param>
        /// <param name="data">The value for the <see cref="Data"/> part of the response body.</param>
        /// <returns>An instance of <see cref="LimboJsonMetaResult"/>.</returns>
        public static LimboJsonMetaResult BadRequest(string? error, object? data) {
            return new LimboJsonMetaResult { Data = data, Meta = { Code = HttpStatusCode.BadRequest, Error = error } };
        }

        /// <summary>
        /// Creates and returns a new <see cref="LimboJsonMetaResult"/> with a <see cref="HttpStatusCode.Unauthorized"/> HTTP status code.
        /// </summary>
        /// <param name="error">An error message.</param>
        /// <returns>An instance of <see cref="LimboJsonMetaResult"/>.</returns>
        public static LimboJsonMetaResult Unauthorized(string? error) {
            return Unauthorized(error, null);
        }

        /// <summary>
        /// Creates and returns a new <see cref="LimboJsonMetaResult"/> with a <see cref="HttpStatusCode.Unauthorized"/> HTTP status code.
        /// </summary>
        /// <param name="error">An error message.</param>
        /// <param name="data">The value for the <see cref="Data"/> part of the response body.</param>
        /// <returns>An instance of <see cref="LimboJsonMetaResult"/>.</returns>
        public static LimboJsonMetaResult Unauthorized(string? error, object? data) {
            return new LimboJsonMetaResult { Data = data, Meta = { Code = HttpStatusCode.Unauthorized, Error = error } };
        }

        /// <summary>
        /// Creates and returns a new <see cref="LimboJsonMetaResult"/> with a <see cref="HttpStatusCode.Forbidden"/> HTTP status code.
        /// </summary>
        /// <param name="error">An error message.</param>
        /// <returns>An instance of <see cref="LimboJsonMetaResult"/>.</returns>
        public static LimboJsonMetaResult Forbidden(string? error) {
            return Forbidden(error, null);
        }

        /// <summary>
        /// Creates and returns a new <see cref="LimboJsonMetaResult"/> with a <see cref="HttpStatusCode.Forbidden"/> HTTP status code.
        /// </summary>
        /// <param name="error">An error message.</param>
        /// <param name="data">The value for the <see cref="Data"/> part of the response body.</param>
        /// <returns>An instance of <see cref="LimboJsonMetaResult"/>.</returns>
        public static LimboJsonMetaResult Forbidden(string? error, object? data) {
            return new LimboJsonMetaResult { Data = data, Meta = { Code = HttpStatusCode.Forbidden, Error = error } };
        }

        /// <summary>
        /// Creates and returns a new <see cref="LimboJsonMetaResult"/> with a <see cref="HttpStatusCode.NotFound"/> HTTP status code.
        /// </summary>
        /// <param name="error">An error message.</param>
        /// <returns>An instance of <see cref="LimboJsonMetaResult"/>.</returns>
        public static LimboJsonMetaResult NotFound(string? error) {
            return NotFound(error, null);
        }

        /// <summary>
        /// Creates and returns a new <see cref="LimboJsonMetaResult"/> with a <see cref="HttpStatusCode.NotFound"/> HTTP status code.
        /// </summary>
        /// <param name="error">An error message.</param>
        /// <param name="data">The value for the <see cref="Data"/> part of the response body.</param>
        /// <returns>An instance of <see cref="LimboJsonMetaResult"/>.</returns>
        public static LimboJsonMetaResult NotFound(string? error, object? data) {
            return new LimboJsonMetaResult { Data = data, Meta = { Code = HttpStatusCode.NotFound, Error = error } };
        }

        /// <summary>
        /// Creates and returns a new <see cref="LimboJsonMetaResult"/> with a <see cref="HttpStatusCode.InternalServerError"/> HTTP status code.
        /// </summary>
        /// <param name="error">An error message.</param>
        /// <returns>An instance of <see cref="LimboJsonMetaResult"/>.</returns>
        public static LimboJsonMetaResult InternalServerError(string? error) {
            return InternalServerError(error, null);
        }

        /// <summary>
        /// Creates and returns a new <see cref="LimboJsonMetaResult"/> with a <see cref="HttpStatusCode.InternalServerError"/> HTTP status code.
        /// </summary>
        /// <param name="error">An error message.</param>
        /// <param name="data">The value for the <see cref="Data"/> part of the response body.</param>
        /// <returns>An instance of <see cref="LimboJsonMetaResult"/>.</returns>
        public static LimboJsonMetaResult InternalServerError(string? error, object? data) {
            return new LimboJsonMetaResult { Data = data, Meta = { Code = HttpStatusCode.InternalServerError, Error = error } };
        }

        #endregion

    }

}