using Eskom.HttpClient.Consumers;
using Eskom.HttpClient.Consumers.Interfaces;
using Eskom.HttpClient.Options;
using Microsoft.Extensions.DependencyInjection;

namespace Eskom.HttpClient;

public static class ServiceExtension
{
    public static IServiceCollection AddEskomClient(
        this IServiceCollection services,
        Action<ApiOptions> action)
    {

        var myOptions = new ApiOptions();
        action(myOptions);

        services.AddHttpClient<IEskomApiConsumer,EskomEskomApiConsumer>(options =>
        {
            options.BaseAddress = BuildUri(myOptions.ApiVersion);
            options.DefaultRequestHeaders.Add("Token",myOptions.Token);
        });

        return services;
    }

    private static string GetVersion(ApiVersion version)
    {
        if (version == ApiVersion.v2)
        {
            return "2.0";
        }
        
        //Default - TODO : Throw exception here if proper version is not given
        return "2.0";
    }

    private static Uri BuildUri(ApiVersion version)
    {
        string apiVersion = GetVersion(version);
        return new Uri($"https://developer.sepush.co.za/business/{apiVersion}/");
    }
}