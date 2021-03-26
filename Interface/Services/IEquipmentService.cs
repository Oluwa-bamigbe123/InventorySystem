using InventorySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventorySystem.Interface.Services
{
   public  interface IEquipmentService
    {
        public Equipments AddEquipment(Equipments equipments);
        public Equipments FindEquipmentById(int id);


        public Equipments GetEquipments(int id);
        public Equipments FindByEquipmentName(string equipmentName);

        public void DeleteEquipment(int id);

        public List<Equipments> GetAll();
        public Equipments UpdateEquipment(Equipments equipments);
        public Equipments DeductEquipment(int equipmentId, int NumberOfEquipment);
    }
}
