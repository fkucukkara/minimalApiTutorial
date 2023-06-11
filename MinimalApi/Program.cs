using MinimalApi.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.RegisterServices();

var app = builder.Build();

app.Logger.LogInformation("App is started!");

app.UseExceptionMiddleware();
app.UseHttpsRedirection();
app.RegisterEndpointDefinitons();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
