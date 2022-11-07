using Microsoft.EntityFrameworkCore;

namespace EFCoreRelationships.Data
{
    public class DataContext : DbContext
    {
        public DataContext( DbContextOptions<DataContext>options):base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Tickets> Tickets { get; set; }

        public DbSet<Passenger> Passenger { get; set; }
        public DbSet<FlightDepartments> FlightDepartments { get; set; }

    }
}
