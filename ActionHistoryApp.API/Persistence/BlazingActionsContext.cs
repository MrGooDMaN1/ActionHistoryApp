using ActionHistoryApp.API.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace ActionHistoryApp.API.Persistence
{
    public class BlazingActionsContext : DbContext
    {
        public DbSet<ActionItem> Actions => Set<ActionItem>();

        public BlazingActionsContext(DbContextOptions<BlazingActionsContext> options) : base(options) { }

        //Переопределив метод OnModelCreating, мы сможем подключить классы
        //конфигурации, которые создали в предыдущем разделе
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ActionItemConfig());
        }
    }
}
