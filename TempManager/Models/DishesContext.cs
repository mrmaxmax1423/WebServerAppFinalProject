using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TempManager.Models
{
    public class DishesContext : DbContext
    {
        public DishesContext(DbContextOptions<DishesContext> options)
            : base(options)
        { }
        public DbSet<Entree> Entrees { get; set; }
        public DbSet<Side> Sides { get; set; }
        public DbSet<Dessert> Desserts { get; set; }
    }
}

