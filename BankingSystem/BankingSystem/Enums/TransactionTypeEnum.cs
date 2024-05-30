using System.Text.Json.Serialization;

namespace BankingSystem.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]

    public enum TransactionTypeEnum
    {
        Deposit,
        Withdraw,
        Transfer,
    }
}
