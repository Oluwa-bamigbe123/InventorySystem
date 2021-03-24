using InventorySystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventorySystem.Interface.Repository
{
    public interface IEquipmentDistribution
    {
        public EquipmentDistribution GetDistribution(int id);
        public EquipmentDistribution FindById(int id);
        public EquipmentDistribution FindEquipmentGeneratedKey(int id);
      
        public List<EquipmentDistribution> GetAll();
    }
}
