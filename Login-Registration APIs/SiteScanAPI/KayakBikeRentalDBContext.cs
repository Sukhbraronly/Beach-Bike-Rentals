using Microsoft.EntityFrameworkCore;
using KayakBikeRentalAPI.Model;

namespace KayakBikeRentalAPI
{
    public class KayakBikeRentalDBContext : DbContext
    {
        public KayakBikeRentalDBContext()
        {
        }
        public KayakBikeRentalDBContext(DbContextOptions<KayakBikeRentalDBContext> options) : base(options)
        {
        }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<AdminModel> Admins { get; set; }
        public DbSet<CustomerModel> Customers { get; set; }

    }
}
