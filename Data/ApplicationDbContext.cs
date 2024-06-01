using CsvDataManager.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CsvDataManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
        public DbSet<Persons> Persons { get; set; }

    }
}
