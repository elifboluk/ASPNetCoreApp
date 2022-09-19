using Microsoft.EntityFrameworkCore;


namespace ASPNetServer.Data
{
    public class AppDBContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) => dbContextOptionsBuilder.UseSqlite("Data Source=./Data/AppDb.db");
        public void DbModelCreating(ModelBuilder modelBuilder)
        {
            Order[] orderToSeed = new Order[6];
            for (int i = 0; i <= 6; i++)
            {
                orderToSeed[i - 1] = new Order
                {
                    OrderId = 1,
                    OrderDate = DateTime.Now,
                    OrderingCompanyName = "SÜTİŞ"
                };
            }
            modelBuilder.Entity<Order>().HasData(orderToSeed);
        }
                
    }
}
