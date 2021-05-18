using GraphQLProject.Model;
using Microsoft.EntityFrameworkCore;

namespace GraphQLProject.Database
{
    public class GraphQLDbContext : DbContext
    {
        public GraphQLDbContext(DbContextOptions<GraphQLDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public int MyProperty { get; set; }
    }
}
