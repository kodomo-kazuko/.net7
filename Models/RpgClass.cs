using System.Text.Json.Serialization;

namespace game
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RpgClass
    {
        AdCarry = 0,
        Tank = 1,
        Assassin  = 2,
    }
}
