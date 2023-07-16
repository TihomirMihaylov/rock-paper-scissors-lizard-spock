using Game.Clients;
using Game.Clients.Interfaces;
using Game.Services;
using Game.Services.Interfaces;

namespace Game
{
    public class Program
    {
        private static IConfiguration Configuration { get; }

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add configuration
            builder.Services.AddOptions<Configuration>().Bind(builder.Configuration.GetSection("Config"));
            
            // Add services to the container.
            builder.Services.AddSingleton<IChoices, ChoicesService>();
            builder.Services.AddSingleton<IRandomProviderClient, RandomProviderClient>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();

            var app = builder.Build();

            //Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            //    app.UseSwagger();
            //    app.UseSwaggerUI();
            //}

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}