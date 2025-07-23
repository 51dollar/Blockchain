using Microsoft.EntityFrameworkCore;

namespace Blockchain
{
    internal class BlockchainContext : DbContext 
    {
        public BlockchainContext()
        { }

        public DbSet<Block> Blocks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MIROTON;Database=BlockchainDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
