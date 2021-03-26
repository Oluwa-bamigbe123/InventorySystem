using InventorySystem.Interface.Services;
using InventorySystem.Models;
using InventorySystem.Models.Entities;
using InventorySystem.Models.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InventorySystem.Controllers
{
    public class ManagerController : Controller
    {
        private readonly IManagerService _managerService;
        private readonly IAgentService _agentService;
        private readonly IEquipmentService _equipmentService;
        private readonly IEquipmentDistributionService _equipmentDistributionService;

        public ManagerController(IManagerService managerService, IAgentService agentService, IEquipmentService equipmentService, IEquipmentDistributionService equipmentDistributionService)
        {
            _managerService = managerService;
            _agentService = agentService;
            _equipmentService = equipmentService;
            _equipmentDistributionService = equipmentDistributionService;
        }
        [Authorize(Roles = "Manager")]
        public IActionResult Index()
        {
            return View(_managerService.GetAll());
        }

        //GET CREATE

        public IActionResult Create()
        {
            return View();

        }
        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Manager man)
        {
            if (ModelState.IsValid)
            {
                _managerService.AddManager(man);
                return RedirectToAction(nameof(Index));

            }
            return View(man);
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(string email, string password)
        {

            var manager = _managerService.Login(email, password);
            if (manager == null)
            {
                ViewBag.Message = "Invalid Username/Password";
                return View();
            }
            else
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, $"{manager.FirstName}"),
                    new Claim(ClaimTypes.GivenName, $"{manager.FirstName} {manager.LastName}"),
                    new Claim(ClaimTypes.NameIdentifier, manager.Id.ToString()),
                    new Claim(ClaimTypes.Email, manager.Email),
                    new Claim(ClaimTypes.Role, "Manager"),

                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authenticationProperties = new AuthenticationProperties();
                var principal = new ClaimsPrincipal(claimsIdentity);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authenticationProperties);
                return RedirectToAction(nameof(Dashboard));
            }
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Manager");
        }
        public IActionResult Dashboard()
        {
            int managerId = int.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            Manager manager = _managerService.GetManager(managerId);
            return View(manager);

        }


        public IActionResult AssignEquipment()
        {
            AssignEquipmentVM assignEquipmentVM = new AssignEquipmentVM();

            List<SelectListItem> AgentNameSelectList = new List<SelectListItem>();
            List<SelectListItem> EquipmentNameSelectList = new List<SelectListItem>();

            List<Agent> agents = _agentService.GetAll();
            List<Equipments> equipments = _equipmentService.GetAll();

            foreach (var agent in agents)
            {
                AgentNameSelectList.Add(new SelectListItem
                {
                    Value = agent.Id.ToString(),
                    Text = agent.UserName
                });
            }

            foreach(var equipment in equipments)
            {
                EquipmentNameSelectList.Add(new SelectListItem
                {
                    Value = equipment.Id.ToString(),
                    Text = equipment.EquipmentName
                });
            }

            assignEquipmentVM.EquipmentNameSelectList = EquipmentNameSelectList;
            assignEquipmentVM.AgentNameSelectList = AgentNameSelectList;


            return View(assignEquipmentVM);


        }
        [HttpPost]
        public IActionResult AssignEquipment(AssignEquipmentVM assignEquipmentVM)
        {
            EquipmentDistribution equipmentDistribution = new EquipmentDistribution();
            int managerId = int.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
           int agentId = int.Parse(assignEquipmentVM.AgentId.ToString());
            Agent agent = _agentService.GetAgent(agentId);

            if (agent == null)
            {
                return View(assignEquipmentVM);
            }
            else
            {
                _equipmentService.DeductEquipment(assignEquipmentVM.EquipmentId, assignEquipmentVM.NumberOfEquipmentAssigned);

                _equipmentDistributionService.CreateDistribution(managerId, assignEquipmentVM.EquipmentId, assignEquipmentVM.NumberOfEquipmentAssigned ,agentId);

            }

            return RedirectToAction(nameof(Dashboard));

        }
    }
}
