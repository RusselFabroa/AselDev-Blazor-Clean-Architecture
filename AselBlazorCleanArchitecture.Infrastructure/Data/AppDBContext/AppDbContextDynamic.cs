using AselBlazorCleanArchitecture.Shared.Models;
using Microsoft.EntityFrameworkCore;


namespace AselBlazorCleanArchitecture.Infrastructure.Data.AppDBContext
{
    public class AppDbContextDynamic : DbContext
    {
        public AppDbContextDynamic(DbContextOptions<AppDbContextDynamic>options) :base(options) { }

        //DbSet<Entity> _entityName { get; set; }
        DbSet<EmployeeInformation> tblempinformation {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeInformation>().HasNoKey();
            //modelBuilder.Entity<MergedEmpInfoManhourAndTurnstrile>().HasNoKey().ToView(null);
         


        }

    }
}
