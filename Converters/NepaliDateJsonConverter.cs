using System.Text.Json;
using System.Text.Json.Serialization;

namespace DateConverter.Converters;

public class NepaliDateJsonConverter : JsonConverter<NepaliDate>
{
    public override NepaliDate Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => NepaliDate.FromString(reader.GetString() ?? "");
    public override void Write(Utf8JsonWriter writer, NepaliDate value, JsonSerializerOptions options) => writer.WriteStringValue(value.ToDateString());
}
