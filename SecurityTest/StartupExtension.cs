using Microsoft.AspNetCore.Builder;
using SecurityTest.Application;
using SecurityTest.Persistence;

namespace SecurityTest
{
    public static class StartupExtension
    { 
   public static void AddSwagger(IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Version = "v1",
                Title = "Test Api"
            });
        });

    }
    public static WebApplication ConfigureService(this WebApplicationBuilder builder)
    {
        AddSwagger(builder.Services);

        builder.Services.AddPersistenceServices(builder.Configuration);
        builder.Services.AddApplicationServices();
        builder.Services.AddControllers();
        builder.Services.AddCors(option =>
        {
            option.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
        });
        return builder.Build();

    }
    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseCors("Open");;
            app.UseMiddleware<ExceptionHandlingMiddleware>();
            app.MapControllers();
        return app;
    }
}
}
