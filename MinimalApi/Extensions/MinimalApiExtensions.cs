using Data;
using Data.Repository;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Behaviours;
using MinimalApi.Endpoints;
using MinimalApi.Mediator.Commands;
using MinimalApi.Services;
using System.Reflection;

namespace MinimalApi.Extensions;
public static class MinimalApiExtensions
{
    public static void RegisterServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<SocialDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("SocialDbContext")));
        builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        builder.Services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
            cfg.AddBehavior<IPipelineBehavior<CreatePost, Post>, CreatePostValidationBehaviour<CreatePost, Post>>();
            cfg.AddOpenBehavior(typeof(PerformanceBehaviour<,>));
        });

        builder.Services.AddScoped<IPostService, PostService>();
    }

    public static void RegisterEndpointDefinitons(this WebApplication app)
    {
        var endPointDefinitions = typeof(Program).Assembly
            .GetTypes()
            .Where(t => t.IsAssignableTo(typeof(IEndpointDefiniton))
                  && t.IsAbstract == false && t.IsInterface == false)
            .Select(Activator.CreateInstance)
            .Cast<IEndpointDefiniton>();

        foreach (var endPointDef in endPointDefinitions)
        {
            endPointDef.RegisterEndpoints(app);
        }
    }
}