using Microsoft.EntityFrameworkCore;
using RazorZoo.Models;

namespace RazorZoo.Data
{
    public class ZooContext : DbContext {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Cage> Cages {get;set;}
        public ZooContext(DbContextOptions<ZooContext> options):base(options){

        }  
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Animal>().ToTable("Animal");
            modelBuilder.Entity<Cage>().ToTable("Cage");
        }
    }
}