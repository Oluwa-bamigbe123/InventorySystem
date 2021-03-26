using InventorySystem.Interface.Services;
using InventorySystem.Models;
using InventorySystem.Models.Entities;
using InventorySystem.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InventorySystem.Controllers
{
    public class EquipmentDistributionController : Controller
    {
        private readonly IEquipmentDistributionService _equipmentDistributionService;
        private readonly IManagerService _managerService;
        private readonly IAgentService _agentService;
        private readonly IEquipmentService _equipmentService;


        public EquipmentDistributionController(IEquipmentDistributionService equipmentDistributionService, IManagerService managerService, IAgentService agentService, IEquipmentService equipmentService)
        {
            _equipmentDistributionService = equipmentDistributionService;
            _managerService = managerService;
            _agentService = agentService;
            _equipmentService = equipmentService;
        }
        public IActionResult Index()
        {
            return View(_equipmentDistributionService.GetAll());
        }
        public IActionResult Distribute()
        {
            return View();

        }
        //POST - CREATE

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Distribute(AssignEquipmentVM assignEquipmentVM)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        int managerId = int.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
        //        Manager manager = _managerService.GetManager(managerId);
        //        Equipments equipments = _equipmentService.FindEquipmentById(assignEquipmentVM.);
        //        Agent receivingAgent = _agentService.FindByUserName(assignEquipmentVM.AgentUserName);


        //    }
        //    return View(assignEquipmentVM);


        //}
    
    }
}
