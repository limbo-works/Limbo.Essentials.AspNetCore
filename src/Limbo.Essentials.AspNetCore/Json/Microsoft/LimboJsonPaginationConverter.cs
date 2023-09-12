using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Limbo.Essentials.AspNetCore.Json.Microsoft;

internal class LimboJsonPaginationConverter : JsonConverter<ILimboJsonPagination> {

    public override ILimboJsonPagination Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, ILimboJsonPagination? value, JsonSerializerOptions options) {
        switch (value) {
            case null: JsonSerializer.Serialize(writer, null!, options); break;
            default: JsonSerializer.Serialize(writer, value, value.GetType(), options); break;
        }
    }

}