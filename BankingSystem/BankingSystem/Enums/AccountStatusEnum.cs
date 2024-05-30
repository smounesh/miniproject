using System.Text.Json.Serialization;

namespace BankingSystem.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]

    public enum AccountStatusEnum
    {
        Active,
        OnHold,
        Closed,
    }
}
