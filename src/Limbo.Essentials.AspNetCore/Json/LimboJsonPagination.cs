﻿using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Limbo.Essentials.AspNetCore.Json {

    /// <summary>
    /// Class with pagination information.
    /// </summary>
    public class LimboJsonPagination : ILimboJsonPagination {

        /// <summary>
        /// Gets the total amount of items.
        /// </summary>
        [JsonProperty("total")]
        [JsonPropertyName("total")]
        public long Total { get; }

        /// <summary>
        /// Gets the limit.
        /// </summary>
        [JsonProperty("limit")]
        [JsonPropertyName("limit")]
        public long Limit { get; }

        /// <summary>
        /// Gets the offset.
        /// </summary>
        [JsonProperty("offset")]
        [JsonPropertyName("offset")]
        public long Offset { get; }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="total"/>, <paramref name="limit"/> and <paramref name="offset"/> values.
        /// </summary>
        /// <param name="total">The total amount of items.</param>
        /// <param name="limit">The limit.</param>
        /// <param name="offset">The offset.</param>
        public LimboJsonPagination(long total, long limit, long offset) {
            Total = total;
            Limit = limit;
            Offset = offset;
        }

    }

}