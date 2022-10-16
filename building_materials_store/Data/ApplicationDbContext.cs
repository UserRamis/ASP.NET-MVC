using building_materials_store.Models;
using Microsoft.EntityFrameworkCore;

namespace building_materials_store.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options ): base (options)
        {
                
        }

        public DbSet<Category> Category { get; set; }
    


}
}
