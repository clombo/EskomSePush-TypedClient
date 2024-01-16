using System.Text.Json.Serialization;
using Eskom.HttpClient.Contracts.Types;

namespace Eskom.HttpClient.Contracts;

public partial class AreasSearchContract
{
    [JsonPropertyName("areas")]
    public AreaType[] Areas { get; set; }
}