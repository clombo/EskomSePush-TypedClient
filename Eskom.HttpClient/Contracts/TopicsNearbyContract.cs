using System.Text.Json.Serialization;

namespace Eskom.HttpClient.Contracts;

public class TopicsNearbyContract
{
    [JsonPropertyName("topics")]
    public Topic[] Topics { get; set; }
}

public partial class Topic
{
    [JsonPropertyName("active")]
    public DateTimeOffset Active { get; set; }

    [JsonPropertyName("body")]
    public string Body { get; set; }

    [JsonPropertyName("category")]
    public string Category { get; set; }

    [JsonPropertyName("distance")]
    public double Distance { get; set; }

    [JsonPropertyName("followers")]
    public long Followers { get; set; }

    [JsonPropertyName("timestamp")]
    public DateTimeOffset Timestamp { get; set; }
}