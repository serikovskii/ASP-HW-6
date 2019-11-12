namespace WebApplication11
{
    using System.Data.Entity;
    using WebApplication11.Models;

    public class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}