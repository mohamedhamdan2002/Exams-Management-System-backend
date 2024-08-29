using Application.DataTransferObjects.ExamSolutionDtos;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Api.Converters
{
    public class AnswerDtoConverter : JsonConverter<AnswerDto>
    {
        public override AnswerDto? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using(JsonDocument document = JsonDocument.ParseValue(ref reader))
            {
                JsonElement root = document.RootElement;
                string? type = root.GetProperty("type").GetString();
                if (type is null)
                    throw new ArgumentNullException("type must be null");
                return type switch
                {
                    "Choice" => JsonSerializer.Deserialize<ChoiceAnswerDto>(root.GetRawText(), options),
                    "Boolean" => JsonSerializer.Deserialize<BooleanAnswerDto>(root.GetRawText(), options),
                    _ => throw new JsonException($"Unknown type '{type}' for answerDto.")
                };
            }
        }

        public override void Write(Utf8JsonWriter writer, AnswerDto value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteString("type", value.Type);
            writer.WriteString("questionId", value.QuestionId);
            switch(value)
            {
                case ChoiceAnswerDto choiceAnswer:
                    writer.WriteString("choice", choiceAnswer.Choice);
                    break;
                case BooleanAnswerDto booleanAnswer:
                    writer.WriteBoolean("value", booleanAnswer.Value);
                    break;
                default:
                    throw new NotSupportedException($"Unsupported type: {value.GetType().Name}");
            }
            writer.WriteEndObject();
        }
    }
}
