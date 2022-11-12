using Microsoft.EntityFrameworkCore;

namespace LearnWebApi.Model.Native
{
    public class MedicineDbContext : DbContext
    {
        public MedicineDbContext(DbContextOptions<MedicineDbContext> options)
            : base(options)
        {

        }

        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
