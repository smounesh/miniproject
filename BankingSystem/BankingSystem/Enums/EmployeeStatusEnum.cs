﻿using System.Text.Json.Serialization;

namespace BankingSystem.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]

    public enum EmployeeStatusEnum
    {
        Active,
        Disabled,
        Archieved
    }
}
