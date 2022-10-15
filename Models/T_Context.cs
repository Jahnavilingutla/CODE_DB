
using Microsoft.EntityFrameworkCore;

namespace CODE_DB.Models
{
    public class T_Context:DbContext
    {
        public T_Context(DbContextOptions<T_Context> options) : base(options)
        {

        }

        public DbSet<IT_Trainee> IT_Trainees { get; set; }
    }
}
