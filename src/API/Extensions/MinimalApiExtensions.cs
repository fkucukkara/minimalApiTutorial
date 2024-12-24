using API.Behaviours;
using API.Endpoints;
using API.Mediator.Commands;
using API.Services;
using Data;
using Data.Repository;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace API.Extensions;
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
            cfg.AddOpenBehavior(typeof(PerformanceBehaviour<,>));            
            cfg.AddBehavior<IPipelineBehavior<CreatePost, Post>, CreatePostValidationBehaviour<CreatePost, Post>>();
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