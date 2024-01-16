using Eskom.HttpClient.Consumers;
using Eskom.HttpClient.Consumers.Interfaces;
using Eskom.HttpClient.Contracts;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace Grpc.Server.Services;

public class EskomService : Eskom.EskomBase
{
    private readonly IEskomApiConsumer _eskomEskomApiConsumer;

    public EskomService(IEskomApiConsumer eskomEskomApiConsumer)
    {
        _eskomEskomApiConsumer = eskomEskomApiConsumer;
    }

    public async Task<AllowanceResponse> ApiAllowance(Empty request, ServerCallContext context, CancellationToken cancellationToken)
    {
        var data = await _eskomEskomApiConsumer.CheckAllowanceAsync(cancellationToken);

        if (data == null)
            throw new RpcException(new Core.Status(StatusCode.NotFound, "No data found!"));

        var response = new AllowanceResponse
        {
            Count = data.Allowance.Count,
            Limit = data.Allowance.Limit,
            Type = data.Allowance.Type
        };

        return await Task.FromResult(response);
    }

    public async Task<AreaSearchResponse> SearchArea(AreaSearchRequest request, ServerCallContext context, CancellationToken cancellationToken)
    {
        var data = await _eskomEskomApiConsumer.AreasSearchAsync(request.Text, cancellationToken);
        
        var response = new AreaSearchResponse
        {
            Areas = { 
                data.Areas
                    .Select(s => 
                        new Areas()
                            {
                              Id  = s.Id,
                              Name = s.Name,
                              Region = s.Region
                            })
                    .ToList() 
            }
        };

        return await Task.FromResult(response);
    }

    public async Task<StatusResponse> GetStatus(Empty request, ServerCallContext context, CancellationToken cancellationToken)
    {
        var data = await _eskomEskomApiConsumer.StatusAsync(cancellationToken);

        if (data == null)
            throw new RpcException(new Core.Status(StatusCode.NotFound, "No data found!"));

        var response = new StatusResponse { };
        
        //Adding Cape Town
        response.Status.Add(new Status
        {
            Name = data.Status.Capetown.Name,
            Current = new CurrentStage
            {
                Stage = data.Status.Capetown.Stage.ToString(),
                Updated = data.Status.Capetown.StageUpdated.ToTimestamp()
            },
            Next =
            {
                data.Status.Capetown.NextStages
                    .Select(s => new NextStage()
                        {
                            Stage = s.Stage.ToString(),
                            Start = s.StageStartTimestamp.ToTimestamp()
                        }
                    )
            }
        });
        
        // Adding national aka Eskom
        response.Status.Add(new Status
        {
            Name = data.Status.Eskom.Name,
            Current = new CurrentStage
            {
                Stage = data.Status.Eskom.Stage.ToString(),
                Updated = data.Status.Eskom.StageUpdated.ToTimestamp()
            },
            Next =
            {
                data.Status.Eskom.NextStages
                    .Select(s => new NextStage()
                        {
                            Stage = s.Stage.ToString(),
                            Start = s.StageStartTimestamp.ToTimestamp()
                        }
                    ).ToArray()
            }
        });
        return await Task.FromResult(response);
    }
}