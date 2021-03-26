using InventorySystem.Models;
using InventorySystem.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventorySystem.Interface.Repository
{
    public interface IEquipmentRepository
    {
        public int CreateEquipment(Equipments equipments);
        public Equipments AddEquipment(Equipments equipments);
        public Equipments GetEquipments(int id);
        public Equipments FindById(int id);
        public Equipments FindByEquipmentName(string equipmentName);
        public Equipments FindByProductId(int id);
        public void DeleteEquipment(int id);
        public List<Equipments> GetAll();
        public Equipments UpdateEquipments(Equipments equipments);
       
    }
}
