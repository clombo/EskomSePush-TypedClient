using Eskom.HttpClient.Contracts;

namespace Eskom.HttpClient.Consumers.Interfaces;

public interface IEskomApiConsumer
{
    Task<StatusContract?> StatusAsync(CancellationToken cancellationToken);
    Task<CheckAllowanceContract?> CheckAllowanceAsync(CancellationToken cancellationToken);
    Task<AreasSearchContract?> AreasSearchAsync(string text,CancellationToken cancellationToken);
    Task<AreasNerbyContract?> AreasNearbyAsync(double lat, double lon,CancellationToken cancellationToken);
    Task<TopicsNearbyContract?> TopicsNearbyAsync(double lat, double lon,CancellationToken cancellationToken);
    Task<AreaInformationContract?> AreaInformationAsync(string id,CancellationToken cancellationToken);
}