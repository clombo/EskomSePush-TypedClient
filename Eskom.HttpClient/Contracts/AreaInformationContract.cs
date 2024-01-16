using System.Text.Json.Serialization;

namespace Eskom.HttpClient.Contracts;

public partial class AreaInformationContract
{
    [JsonPropertyName("events")]
    public Event[] Events { get; set; }

    [JsonPropertyName("info")]
    public Info Info { get; set; }

    [JsonPropertyName("schedule")]
    public Schedule Schedule { get; set; }
}

public partial class Event
{
    [JsonPropertyName("end")]
    public DateTimeOffset End { get; set; }

    [JsonPropertyName("note")]
    public string Note { get; set; }

    [JsonPropertyName("start")]
    public DateTimeOffset Start { get; set; }
}

public partial class Info
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("region")]
    public string Region { get; set; }
}

public partial class Schedule
{
    [JsonPropertyName("days")]
    public Day[] Days { get; set; }

    [JsonPropertyName("source")]
    public Uri Source { get; set; }
}

public partial class Day
{
    [JsonPropertyName("date")]
    public DateTimeOffset Date { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("stages")]
    public Stages[] Stages { get; set; }
}

public partial class Stages
{
    public string[] stageDetail { get; set; }
}