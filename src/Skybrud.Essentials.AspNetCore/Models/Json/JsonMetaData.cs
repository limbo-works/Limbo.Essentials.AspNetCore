using System.Net;
using Newtonsoft.Json;

namespace Skybrud.Essentials.AspNetCore.Models.Json {

    /// <summary>
    /// Class representing the meta data of a JSON response.
    /// </summary>
    public class JsonMetaData {

        /// <summary>
        /// Gets or sets the status code.
        /// </summary>
        [JsonProperty(PropertyName = "code")]
        public HttpStatusCode Code { get; set; }

        /// <summary>
        /// Gets or sets the error message. If the error message is <c>NULL</c>, the property will not be a part of the JSON response.
        /// </summary>
        [JsonProperty(PropertyName = "error", NullValueHandling = NullValueHandling.Ignore)]
        public string Error { get; set; }

    }

}