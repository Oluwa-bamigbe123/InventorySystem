using InventorySystem.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventorySystem.Models
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
        {
          
        }
        public DbSet<Equipments> Equipments { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<ProjectRoles> Roles { get; set; }
        public DbSet<EquipmentDistribution> EquipmentDistribution { get; set; }
    }
}
