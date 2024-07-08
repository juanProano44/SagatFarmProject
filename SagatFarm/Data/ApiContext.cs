using Microsoft.EntityFrameworkCore;
using SagatFarm.Models;

namespace SagatFarm.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<ToDo> ToDos { get; set; }

        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }
    }
    
}

