using InventorySystem.Interface.Repository;
using InventorySystem.Interface.Services;
using InventorySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventorySystem.Domain.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IEquipmentRepository _equipmentRepository;


      public EquipmentService(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }
        public Equipments AddEquipment(Equipments equipments)
        {
            Equipments eq = _equipmentRepository.AddEquipment(equipments);
            return eq;
        }

        public void DeleteEquipment(int id)
        {
            _equipmentRepository.DeleteEquipment(id);
        }

        public List<Equipments> GetAll()
        {
            return _equipmentRepository.GetAll();
        }

        public Equipments GetEquipments(int id)
        {
            return _equipmentRepository.GetEquipments(id);
        }

        public Equipments UpdateEquipment(Equipments equipments)
        {
            return _equipmentRepository.UpdateEquipments(equipments);
        }
    }
}
