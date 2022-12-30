using AspNetWebApi.Entites;
using System.Data.Entity;

namespace AspNetWebApi.Models
{
    public class UrunDbContext : DbContext    
    {
        public DbSet<Products> Products { get; set; }
    }
}