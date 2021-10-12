using BuildAppYD.Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildAppYD.DataAccess.Concrete.EntityFramework.Contexts
{
   public class BuildAppYDContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-OF69QGO;Database=BuildAppYDDB;Trusted_Connection=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        } 

        public  DbSet<Building> Buildings { get; set; }
        public  DbSet<Room> Rooms { get; set; }
        public  DbSet<Store> Stores { get; set; }
    }
}
