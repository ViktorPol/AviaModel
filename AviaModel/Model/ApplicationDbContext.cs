using Microsoft.EntityFrameworkCore;
using AviaModel.Model.Entity;
namespace AviaModel.Model
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Avia>Avias{get; set;}
        public DbSet<Mark> Marks { get; set; }

        public DbSet<Country> Countries { get; set; }

        // конфигурация контекста
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // получаем файл конфигурации
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            // устанавливаем для контекста строку подключения
            // инициализируем саму строку подключения
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        }
        
    }

}
