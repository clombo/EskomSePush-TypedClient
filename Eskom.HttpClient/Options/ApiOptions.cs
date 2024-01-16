namespace Eskom.HttpClient.Options;

public enum ApiVersion
{
    v2
}
public class ApiOptions
{
    public string Token { get; set; }
    public ApiVersion ApiVersion { get; set; } = ApiVersion.v2;
}

