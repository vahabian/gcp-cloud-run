
namespace Web.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configure Kestrel to use HTTP/2
            builder.WebHost.ConfigureKestrel(options =>
            {
                // Enable HTTP/2 protocol
                options.ListenAnyIP(8080, listenOptions =>
                {
                    listenOptions.Protocols = Microsoft.AspNetCore.Server.Kestrel.Core.HttpProtocols.Http2 | Microsoft.AspNetCore.Server.Kestrel.Core.HttpProtocols.Http1;
                });
            });

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();


            app.UseSwagger();
            app.UseSwaggerUI();


            //app.UseHttpsRedirection();

            app.UseAuthorization();

            //app.MapGet("/", () => "Welcome to the default route!");
            //app.MapControllerRoute(name: "default", pattern: "/", defaults: new { controller = "Home", action = "Index" });

            app.MapControllers();

            app.Run();
        }
    }
}


