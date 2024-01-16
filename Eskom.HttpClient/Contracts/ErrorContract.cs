using System.Text.Json.Serialization;

namespace Eskom.HttpClient.Contracts;

public class ErrorContract
{
    [JsonPropertyName("error")]
    public string Error { get; set; }
}