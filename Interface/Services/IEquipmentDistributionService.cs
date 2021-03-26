using InventorySystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventorySystem.Interface.Services
{
   public interface IEquipmentDistributionService
    {
        public EquipmentDistribution CreateDistribution(int managerId, int numberOfEquipment, int equipmentId, int agentId);
        //public EquipmentDistribution AddDistribution(EquipmentDistribution equipmentDistribution);
        public EquipmentDistribution GetDistribution(int id);
        public List<EquipmentDistribution> GetAll();
        public EquipmentDistribution UpdateDistribution(EquipmentDistribution distribution);
    }
}
