using System;
using System.Net;
using Newtonsoft.Json;

#pragma warning disable CS8618

namespace Skybrud.Essentials.AspNetCore.Models.NewtonsoftJson {

    /// <summary>
    /// Class representing the meta data of a JSON response.
    /// </summary>
    [Obsolete("Use the class in the 'Skybrud.Essentials.AspNetCore.Json.Newtonsoft' namespace instead.")]
    public class NewtonsoftJsonMetaData {

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