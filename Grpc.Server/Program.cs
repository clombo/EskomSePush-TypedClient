using Eskom.HttpClient;
using Grpc.Server.ConfigModels;
using Grpc.Server.Services;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
var environment = builder.Environment;
var services = builder.Services;

config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
config.AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true, reloadOnChange: true);
config.AddEnvironmentVariables();

services.AddGrpc();
services.AddGrpcReflection();

var eskomSePushSettings = config.GetRequiredSection("EskomSePush").Get<EskomSePush>();
services.AddEskomClient(options =>
{
    options.Token = eskomSePushSettings.ApiKey;
});

var app = builder.Build();

app.MapGrpcService<EskomService>();

if (environment.IsDevelopment())
{
    app.MapGrpcReflectionService();
}

app.Run();