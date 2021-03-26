using InventorySystem.Interface.Repository;
using InventorySystem.Interface.Services;
using InventorySystem.Models;
using InventorySystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InventorySystem.Domain.Services
{
    public class EquipmentDistributionService : IEquipmentDistributionService
    {
        private readonly IEquipmentDistribution _equipmentDistributionRepository;
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IAgentRepository _agentRepository;
        private readonly IManagerRepository _managerRepository;


        public EquipmentDistributionService(IEquipmentDistribution equipmentDistribution, IEquipmentRepository equipmentRepository,IAgentRepository agentRepository,IManagerRepository managerRepository)
        {
            _equipmentDistributionRepository = equipmentDistribution;
            _equipmentRepository = equipmentRepository;
            _agentRepository = agentRepository;
            _managerRepository = managerRepository;
        }

        //public EquipmentDistribution AddDistribution(EquipmentDistribution equipmentDistribution)
        //{
        //    return _equipmentDistributionRepository.AddDistribution(equipmentDistribution);

           
        //}

        public EquipmentDistribution CreateDistribution(int managerId, int numberOfEquipment, int equipmentId,int agentId)
        {
            //Manager manager = _managerRepository.GetManager(managerId);
            //manager.Id = managerId;

            //Equipments equipment = _equipmentRepository.FindById(equipmentId);

            //equipment.Id = equipmentId;

            //Agent agent = _agentRepository.FindById(agentId); 

            //agent.Id = agentId;
           

            EquipmentDistribution equipmentDistribution = new EquipmentDistribution
            {
                ManagerId = managerId,
                DateAssigned = DateTime.Now,
                NumberOfEquipmentAssigned = numberOfEquipment,
                EquipmentsId = equipmentId,
                AgentId = agentId,
            };

            return _equipmentDistributionRepository.CreateDistribution(equipmentDistribution);

            
        }






        public List<EquipmentDistribution> GetAll()
        {
            return _equipmentDistributionRepository.GetAll();
        }

        public EquipmentDistribution GetDistribution(int id)
        {
            return _equipmentDistributionRepository.GetDistribution(id);
        }

        public EquipmentDistribution UpdateDistribution(EquipmentDistribution distribution)
        {
            return _equipmentDistributionRepository.UpdateDistribution(distribution);
        }
    }
}
