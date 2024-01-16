using System.Text.Json.Serialization;
using Eskom.HttpClient.Contracts.Types;

namespace Eskom.HttpClient.Contracts;

public class AreasNerbyContract
{
    [JsonPropertyName("areas")]
    public AreaType[] Areas { get; set; }
}