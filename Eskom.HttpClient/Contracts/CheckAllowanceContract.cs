using System.Text.Json.Serialization;

namespace Eskom.HttpClient.Contracts;

public partial class CheckAllowanceContract
{
    [JsonPropertyName("allowance")]
    public Allowance Allowance { get; set; }
}

public partial class Allowance
{
    [JsonPropertyName("count")]
    public int Count { get; set; }

    [JsonPropertyName("limit")]
    public int Limit { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }
}