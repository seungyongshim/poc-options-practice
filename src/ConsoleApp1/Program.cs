using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

var builder = Host.CreateApplicationBuilder(args);



builder.Configuration.Sources.Clear();
builder.Configuration.AddYamlFile($"appsettings.{builder.Environment.EnvironmentName}.yaml");




var app = builder.Build();



await app.StartAsync();
