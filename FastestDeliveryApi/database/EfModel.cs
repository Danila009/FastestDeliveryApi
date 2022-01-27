using FastestDeliveryApi.model;
using FastestDeliveryApi.model.user;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastestDeliveryApi.database
{
    public class EfModel: DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Food>();
        }

        public EfModel(DbContextOptions options) : base(options)
        {
            //Database.EnsureCreated();
        }

        public virtual DbSet<User> users { get; set; }
        public virtual DbSet<Food> Foods { get; set; }

        public virtual DbSet<History> Histories { get; set; }

    }
}
