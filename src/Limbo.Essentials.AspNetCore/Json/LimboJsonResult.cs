using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Limbo.Essentials.AspNetCore.Json {

    /// <summary>
    /// An action result which formats the given object as JSON.
    /// </summary>
    public class LimboJsonResult : ActionResult, IStatusCodeActionResult {

        #region Properties

        /// <summary>
        /// Gets or sets the value to be formatted.
        /// </summary>
        public object? Value { get; set; }

        /// <summary>
        /// Gets or sets the HTTP status code.
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        int? IStatusCodeActionResult.StatusCode => (int) StatusCode;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new <see cref="LimboJsonResult"/> with the given value.
        /// </summary>
        /// <param name="value">The value to format as JSON.</param>
        public LimboJsonResult(object? value) {
            Value = value;
            StatusCode = HttpStatusCode.OK;
        }

        /// <summary>
        /// Creates a new <see cref="LimboJsonResult"/> with the given value.
        /// </summary>
        /// <param name="value">The value to format as JSON.</param>
        /// <param name="statusCode">The HTTP status code.</param>
        public LimboJsonResult(object? value, HttpStatusCode statusCode) {
            Value = value;
            StatusCode = statusCode;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public override Task ExecuteResultAsync(ActionContext context) {
            ArgumentNullException.ThrowIfNull(context);
            var services = context.HttpContext.RequestServices;
            var executor = services.GetRequiredService<IActionResultExecutor<JsonResult>>();
            return executor.ExecuteAsync(context, new JsonResult(Value) {
                StatusCode = (int) StatusCode
            });
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Creates and returns a new <see cref="LimboJsonResult"/> with a <see cref="HttpStatusCode.OK"/> HTTP status code.
        /// </summary>
        /// <param name="value">The value to format as JSON.</param>
        /// <returns>An instance of <see cref="LimboJsonResult"/>.</returns>
        public static LimboJsonResult Ok(object? value) {
            return new LimboJsonResult(value, HttpStatusCode.OK);
        }

        /// <summary>
        /// Creates and returns a new <see cref="LimboJsonResult"/> with a <see cref="HttpStatusCode.Created"/> HTTP status code.
        /// </summary>
        /// <param name="value">The value to format as JSON.</param>
        /// <returns>An instance of <see cref="LimboJsonResult"/>.</returns>
        public static LimboJsonResult Created(object? value) {
            return new LimboJsonResult(value, HttpStatusCode.Created);
        }

        /// <summary>
        /// Creates and returns a new <see cref="LimboJsonResult"/> with a <see cref="HttpStatusCode.BadRequest"/> HTTP status code.
        /// </summary>
        /// <param name="value">The value to format as JSON.</param>
        /// <returns>An instance of <see cref="LimboJsonResult"/>.</returns>
        public static LimboJsonResult BadRequest(object? value) {
            return new LimboJsonResult(value, HttpStatusCode.BadRequest);
        }

        /// <summary>
        /// Creates and returns a new <see cref="LimboJsonResult"/> with a <see cref="HttpStatusCode.Unauthorized"/> HTTP status code.
        /// </summary>
        /// <param name="value">The value to format as JSON.</param>
        /// <returns>An instance of <see cref="LimboJsonResult"/>.</returns>
        public static LimboJsonResult Unauthorized(object? value) {
            return new LimboJsonResult(value, HttpStatusCode.Unauthorized);
        }

        /// <summary>
        /// Creates and returns a new <see cref="LimboJsonResult"/> with a <see cref="HttpStatusCode.Forbidden"/> HTTP status code.
        /// </summary>
        /// <param name="value">The value to format as JSON.</param>
        /// <returns>An instance of <see cref="LimboJsonResult"/>.</returns>
        public static LimboJsonResult Forbidden(object? value) {
            return new LimboJsonResult(value, HttpStatusCode.Forbidden);
        }

        /// <summary>
        /// Creates and returns a new <see cref="LimboJsonResult"/> with a <see cref="HttpStatusCode.NotFound"/> HTTP status code.
        /// </summary>
        /// <param name="value">The value to format as JSON.</param>
        /// <returns>An instance of <see cref="LimboJsonResult"/>.</returns>
        public static LimboJsonResult NotFound(object? value) {
            return new LimboJsonResult(value, HttpStatusCode.NotFound);
        }

        /// <summary>
        /// Creates and returns a new <see cref="LimboJsonResult"/> with a <see cref="HttpStatusCode.InternalServerError"/> HTTP status code.
        /// </summary>
        /// <param name="value">The value to format as JSON.</param>
        /// <returns>An instance of <see cref="LimboJsonResult"/>.</returns>
        public static LimboJsonResult InternalServerError(object? value) {
            return new LimboJsonResult(value, HttpStatusCode.InternalServerError);
        }

        #endregion

    }

}