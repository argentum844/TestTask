using Serilog;
using Serilog.Events;

namespace WebApplicationDaData
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.Configure<DaDataConfiguration>(builder.Configuration);
            builder.Services.AddHttpClient();
            builder.Services.AddAutoMapper(typeof(AppMapping));
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .MinimumLevel.Verbose()
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.Extensions.Hosting", LogEventLevel.Information)
                .MinimumLevel.Override("Microsoft.Hosting", LogEventLevel.Information)
                .CreateLogger();
            builder.Services.AddSerilog();

            //var logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration);


            var app = builder.Build();
            app.UseExceptionHandler(app => app.Run(async context =>
            {
                context.Response.StatusCode=500;
                await context.Response.WriteAsync("Ошибка на сервере!");
            }));
            app.UseSerilogRequestLogging();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
