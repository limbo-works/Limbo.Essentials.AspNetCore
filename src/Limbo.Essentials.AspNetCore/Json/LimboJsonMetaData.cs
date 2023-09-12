using System.Net;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Limbo.Essentials.AspNetCore.Json;

/// <summary>
/// Class representing the meta data of a JSON response.
/// </summary>
public class LimboJsonMetaData {

    /// <summary>
    /// Gets or sets the status code.
    /// </summary>
    [JsonProperty(PropertyName = "code")]
    [JsonPropertyName("code")]
    public HttpStatusCode Code { get; set; } = HttpStatusCode.OK;

    /// <summary>
    /// Gets or sets the error message. If the error message is <see langword="null"/>, the property will not be a part of the JSON
    /// response.
    /// </summary>
    [JsonProperty(PropertyName = "error", NullValueHandling = NullValueHandling.Ignore)]
    [JsonPropertyName("error")]
    [System.Text.Json.Serialization.JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Error { get; set; }

}