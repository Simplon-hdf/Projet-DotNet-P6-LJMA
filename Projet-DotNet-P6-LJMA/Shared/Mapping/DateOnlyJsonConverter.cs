using System.Globalization;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Projet_DotNet_P6_LJMA.Shared.Mapping
{
    public class DateOnlyJsonConverter : JsonConverter<DateOnly>
    {
        private const string DateFormat = "yyyy-MM-dd";

        public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
            DateOnly.ParseExact(reader.GetString()!, DateFormat, CultureInfo.InvariantCulture);

        public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options) =>
            writer.WriteStringValue(value.ToString(DateFormat, CultureInfo.InvariantCulture));
    }
}
