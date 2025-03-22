using FurniStyle.Repository.Data.Context;
using FurniStyle.Repository.Data.DataSeeding;
using Microsoft.EntityFrameworkCore;

namespace FurniStyle.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #region Adding Db Connection String

            builder.Services.AddDbContext<FurniStyleDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            #endregion

            #region Register LoggerService

            builder.Services.AddLogging();
            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();
            builder.Logging.AddDebug();



            #endregion

            var app = builder.Build();

            #region Applying Migrations

            using var scope = app.Services.CreateScope();
            var serviceProvider = scope.ServiceProvider;
            var dataContext = serviceProvider.GetRequiredService<FurniStyleDbContext>();
            try
            {
                await dataContext.Database.MigrateAsync();
                await FurniStyleDataSeeding.SeedingData(dataContext);
            }
            catch (Exception ex)
            {
                var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "There is an Error While Migration..!");

            }

            #endregion


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
