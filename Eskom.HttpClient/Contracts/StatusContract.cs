using System.Text.Json.Serialization;

namespace Eskom.HttpClient.Contracts;

public partial class StatusContract
{
    [JsonPropertyName("status")]
    public Status Status { get; set; }
}

public partial class Status
{
    [JsonPropertyName("capetown")]
    public Capetown Capetown { get; set; }

    [JsonPropertyName("eskom")]
    public Capetown Eskom { get; set; }
}

public partial class Capetown
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("next_stages")]
    public NextStage[] NextStages { get; set; }

    [JsonPropertyName("stage")]
    public string Stage { get; set; }

    [JsonPropertyName("stage_updated")]
    public DateTimeOffset StageUpdated { get; set; }
}

public partial class NextStage
{
    [JsonPropertyName("stage")]
    public string Stage { get; set; }

    [JsonPropertyName("stage_start_timestamp")]
    public DateTimeOffset StageStartTimestamp { get; set; }
}