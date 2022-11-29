using Microsoft.EntityFrameworkCore;
using WebAPI_2.Models;

namespace WebAPI_2.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<TodoSQL> Todos { get; set; }
    }
}
