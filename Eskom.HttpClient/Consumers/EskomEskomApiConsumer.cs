using System.Text.Json;
using Eskom.HttpClient.Consumers.Interfaces;
using Eskom.HttpClient.Contracts;

namespace Eskom.HttpClient.Consumers;

//...TODO
/*
 * How to use cancellation token effectively
 * Handle 429 exception - Limit reached
 * See error contract
 * Handle null exceptions
 * Do versioning - Version factory pattern? - See O2C if that can work?
 * Build as nuget package
 */
public class EskomEskomApiConsumer : IEskomApiConsumer
{
    private readonly System.Net.Http.HttpClient _httpClient;

    public EskomEskomApiConsumer(System.Net.Http.HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<StatusContract?> StatusAsync(CancellationToken cancellationToken)
    {
        var response = await _httpClient.GetAsync("status",cancellationToken);
        return  await ReadStream<StatusContract>(response);
    }

    public async Task<CheckAllowanceContract?> CheckAllowanceAsync(CancellationToken cancellationToken)
    {
        var response = await _httpClient.GetAsync("api_allowance",cancellationToken);
        return await ReadStream<CheckAllowanceContract>(response);
    }
    
    public async Task<AreasSearchContract?> AreasSearchAsync(string text,CancellationToken cancellationToken)
    {
        var response = await _httpClient.GetAsync($"areas_search?text={text}",cancellationToken);
        return await ReadStream<AreasSearchContract>(response);
    }

    public async Task<AreasNerbyContract?> AreasNearbyAsync(double lat, double lon, CancellationToken cancellationToken)
    {
        var response = await _httpClient.GetAsync($"areas_nearby?lat={lat}&lon={lon}", cancellationToken);
        return await ReadStream<AreasNerbyContract>(response);
    }

    public async Task<TopicsNearbyContract?> TopicsNearbyAsync(double lat, double lon, CancellationToken cancellationToken)
    {
        var response = await _httpClient.GetAsync($"topics_nearby?lat={lat}&lon={lon}", cancellationToken);
        return await ReadStream<TopicsNearbyContract>(response);
    }
    
    public async Task<AreaInformationContract?> AreaInformationAsync(string id, CancellationToken cancellationToken)
    {
        var response = await _httpClient.GetAsync($"area?id={id}", cancellationToken);
        return await ReadStream<AreaInformationContract>(response);
    }

    private static async Task<T?> ReadStream<T>(HttpResponseMessage message)
    {
        message.EnsureSuccessStatusCode();
        await using var responseStream = await message.Content.ReadAsStreamAsync();
        return JsonSerializer.Deserialize<T>(responseStream);
    }
}