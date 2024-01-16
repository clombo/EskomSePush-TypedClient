using System.Text.Json.Serialization;

namespace Eskom.HttpClient.Contracts.Types;

public partial class AreaType
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("region")]
    public string Region { get; set; }
}