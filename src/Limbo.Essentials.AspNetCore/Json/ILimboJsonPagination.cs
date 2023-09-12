using System.Text.Json.Serialization;
using Limbo.Essentials.AspNetCore.Json.Microsoft;

namespace Limbo.Essentials.AspNetCore.Json {

    /// <summary>
    /// Interface describing an object with pagination information.
    /// </summary>
    [JsonConverter(typeof(LimboJsonPaginationConverter))]
    public interface ILimboJsonPagination { }
}