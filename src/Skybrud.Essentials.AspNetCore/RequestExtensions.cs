using System;
using Microsoft.AspNetCore.Http;

namespace Skybrud.Essentials.AspNetCore {
    
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
                Port = request.Host.Port ?? (request.Scheme == "https" ? 80 : 443),
                Path = request.Path,
                Query = request.QueryString.ToUriComponent()
            }.Uri;
        }

    }

}