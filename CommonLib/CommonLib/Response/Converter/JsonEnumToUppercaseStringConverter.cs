using System.Text.Json;
using System.Text.Json.Serialization;

namespace CommonLib.Response.Converter;

public class JsonEnumToUppercaseStringConverter<T> : JsonConverter<T> where T : Enum
{
    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string enumString = reader.GetString();

        if (Enum.TryParse(typeof(T), enumString, true, out var enumValue))
        {
            return (T)enumValue;
        }

        throw new JsonException($"Unable to convert \"{enumString}\" to Enum \"{typeof(T)}\".");
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        string enumString = value.ToString().ToUpperInvariant();
        writer.WriteStringValue(enumString);
    }
}