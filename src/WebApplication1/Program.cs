using WebApplication1;

var builder = WebApplication.CreateBuilder(args);



builder.Configuration.Sources.Clear();
builder.Configuration.AddYamlFile($"appsettings.{builder.Environment.EnvironmentName}.yaml");

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOptions();
builder.Services.AddOptions<Dictionary<string, DatabaseOption>>().BindConfiguration("");

builder.Services.AddSingleton(typeof(OptionMap<>));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", (HttpContext context) =>
{
    var config = context.RequestServices.GetRequiredService<OptionMap<DatabaseOption>>();
    return config;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
