using System.Net;
using Newtonsoft.Json;

namespace Skybrud.Essentials.AspNetCore.Models.NewtonsoftJson {

    /// <summary>
    /// Class representing the body of a JSON response.
    /// </summary>
    public class NewtonsoftJsonBody {

        /// <summary>
        /// Gets or sets the meta data for the response.
        /// </summary>
        [JsonProperty(PropertyName = "meta")]
        public NewtonsoftJsonMetaData Meta { get; set; } = new();

        /// <summary>
        /// Gets or sets the data object.
        /// </summary>
        [JsonProperty(PropertyName = "data", NullValueHandling = NullValueHandling.Ignore)]
        public object? Data { get; set; }

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public NewtonsoftJsonBody() { }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="status"/> and <paramref name="error"/> message.
        /// </summary>
        /// <param name="status">The HTTP status.</param>
        /// <param name="error">The error message.</param>
        public NewtonsoftJsonBody(HttpStatusCode status, string? error) {
            Meta.Code = status;
            Meta.Error = error;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="status"/>, <paramref name="error"/> message and <paramref name="data"/>.
        /// </summary>
        /// <param name="status">The HTTP status.</param>
        /// <param name="error">The error message.</param>
        /// <param name="data">The data.</param>
        public NewtonsoftJsonBody(HttpStatusCode status, string? error, object? data) {
            Meta.Code = status;
            Meta.Error = error;
            Data = data;
        }

        #endregion

    }

}