using InventorySystem.Interface.Repository;
using InventorySystem.Models;
using InventorySystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventorySystem.Domain.Repository
{
    public class EquipmentDistributionRepository : IEquipmentDistribution
    {
        private readonly InventoryDbContext _context;

        public EquipmentDistributionRepository(InventoryDbContext context)
        {
            _context = context;

        }

        //public EquipmentDistribution AddDistribution(EquipmentDistribution distribution)
        //{
        //    _context.EquipmentDistribution.Add(distribution);
        //    _context.SaveChanges();
        //    return distribution;
        //}

        public EquipmentDistribution CreateDistribution(EquipmentDistribution equipmentDistribution)
        {
            _context.EquipmentDistribution.Add(equipmentDistribution);
            _context.SaveChanges();
            return equipmentDistribution;
        }

        public EquipmentDistribution FindById(int id)
        {
            return _context.EquipmentDistribution.FirstOrDefault(i => i.Id == id);
        }

       

        public List<EquipmentDistribution> GetAll()
        {
            return _context.EquipmentDistribution.ToList();
        }

        public EquipmentDistribution GetDistribution(int id)
        {
            return _context.EquipmentDistribution.Find(id);
        }

        public EquipmentDistribution UpdateDistribution(EquipmentDistribution distribution)
        {
            _context.EquipmentDistribution.Update(distribution);
            _context.SaveChanges();
            return distribution;
        }
    }
}
