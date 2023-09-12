using System;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Limbo.Essentials.AspNetCore {

    /// <summary>
    /// Various extension methods for working with <see cref="HttpRequest"/>.
    /// </summary>
    public static class RequestExtensions {

        /// <summary>
        /// Returns the <see cref="Uri"/> of the specified <paramref name="request"/>.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>An instance of <see cref="Uri"/>.</returns>
        public static Uri GetUri(this HttpRequest request) {
            return new UriBuilder {
                Scheme = request.Scheme,
                Host = request.Host.Host,
                Port = request.Host.Port ?? (request.Scheme == "https" ? 443 : 80),
                Path = request.Path,
                Query = request.QueryString.ToUriComponent()
            }.Uri;
        }

        /// <summary>
        /// Returns the value of the <c>Accept</c> HTTP header, or <c>null</c> if the header is not present.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The header value.</returns>
        public static string? GetAcceptTypes(this HttpRequest? request) {
            return request?.Headers["Accept"].FirstOrDefault();
        }

        /// <summary>
        /// Returns the value of the <c>Accept-Encoding</c> HTTP header, or <c>null</c> if the header is not present.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The header value.</returns>
        public static string? GetAcceptEncoding(this HttpRequest? request) {
            return request?.Headers["Accept-Encoding"].FirstOrDefault();
        }

        /// <summary>
        /// Returns the value of the <c>Accept-Language</c> HTTP header, or <c>null</c> if the header is not present.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The header value.</returns>
        public static string? GetAcceptLanguage(this HttpRequest? request) {
            return request?.Headers["Accept-Language"].FirstOrDefault();
        }

        /// <summary>
        /// Gets the remote address of the specified <paramref name="request"/>.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The remote address.</returns>
        public static string? GetRemoteAddress(this HttpRequest? request) {
            return request?.HttpContext.Connection.RemoteIpAddress?.ToString();
        }

        /// <summary>
        /// Returns the value of the <c>Referer</c> HTTP header, or <c>null</c> if the header is not present.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The header value.</returns>
        public static string? GetReferrer(this HttpRequest? request) {
            return request?.Headers["Referer"].FirstOrDefault();
        }

        /// <summary>
        /// Gets the user agent of the specified <paramref name="request"/>.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The user agent.</returns>
        public static string? GetUserAgent(this HttpRequest? request) {
            return request?.Headers["User-Agent"].FirstOrDefault();
        }

        /// <summary>
        /// Returns the value of the <c>X-Forwarded-For</c> header, or <c>null</c> if the header is not present.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The value of the header, or <c>null</c> if not present.</returns>
        public static string? GetForwardedFor(this HttpRequest? request) {
            return request?.Headers["X-Forwarded-For"].FirstOrDefault();
        }

    }

}