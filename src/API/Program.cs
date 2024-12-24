using API.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.RegisterServices();

var app = builder.Build();

app.UseExceptionMiddleware();
app.UseHttpsRedirection();
app.RegisterEndpointDefinitons();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
