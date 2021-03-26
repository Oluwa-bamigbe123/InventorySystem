using InventorySystem.Interface.Repository;
using InventorySystem.Interface.Services;
using InventorySystem.Models;
using InventorySystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventorySystem.Domain.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IEquipmentDistribution _equipmentDistributionRepository;
        private readonly IManagerRepository _managerRepository;
        private readonly IAgentRepository _agentRepository;


      public EquipmentService(IEquipmentRepository equipmentRepository, IEquipmentDistribution equipmentDistribution, IManagerRepository managerRepository, IAgentRepository agentRepository)
        {
            _equipmentRepository = equipmentRepository;
            _equipmentDistributionRepository = equipmentDistribution;
        }
        public Equipments AddEquipment(Equipments equipments)
        {
            Equipments eq = _equipmentRepository.AddEquipment(equipments);
            return eq;
        }

        public Equipments DeductEquipment(int equipmentId, int numberOfEquipment)
        {
            Equipments equipment = _equipmentRepository.FindById(equipmentId);
            equipment.EquipmentNumber -= numberOfEquipment;
            _equipmentRepository.UpdateEquipments(equipment);
            
            return equipment;
           
        }
      




        public void DeleteEquipment(int id)
        {
            _equipmentRepository.DeleteEquipment(id);
        }

        public Equipments FindByEquipmentName(string equipmentName)
        {
            throw new NotImplementedException();
        }

        public Equipments FindByEquipmentNme(string equipmentName)
        {
            return _equipmentRepository.FindByEquipmentName(equipmentName);
        }

        public Equipments FindEquipmentById(int id)
        {
           return  _equipmentRepository.FindById(id);
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
