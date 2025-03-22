using FurniStyle.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FurniStyle.Repository.Data.Context
{
    public class FurniStyleDbContext:DbContext
    {
        public FurniStyleDbContext(DbContextOptions <FurniStyleDbContext> options):base(options)  { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Furni> Furnis {  get; set; }
        public DbSet<Room> Rooms {  get; set; }
        public DbSet<Category> Categories {  get; set; }
        
    }
}
