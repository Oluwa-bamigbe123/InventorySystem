using InventorySystem.Interface.Services;
using InventorySystem.Models.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InventorySystem.Controllers
{
    public class AgentController : Controller
    {
        private readonly IAgentService _agentService;
       
        public AgentController(IAgentService agentService)
        {
            _agentService = agentService;
        }
        [Authorize(Roles = "Manager")]
        public IActionResult Index()
        {
            return View(_agentService.GetAll());
        }
        [Authorize(Roles = "Manager")]
        public IActionResult Create()
        {
            return View();

        }
        // POST CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager")]
        public IActionResult Create(Agent agn)
        {
            if (ModelState.IsValid)
            {
                _agentService.AddAgent(agn);
                return RedirectToAction(nameof(Index));

            }
            return View(agn);
        }
        [HttpGet]
        [AllowAnonymous]
        [Authorize(Roles = "Manager")]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(string email, string password)
        {

            var agent = _agentService.Login(email, password);
            if (agent == null)
            {
                ViewBag.Message = "Invalid Username/Password";
                return View();
            }
            else
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, $"{agent.UserName}"),
                    new Claim(ClaimTypes.GivenName, $"{agent.UserName} {agent.Email}"),
                    new Claim(ClaimTypes.NameIdentifier, agent.Id.ToString()),
                    new Claim(ClaimTypes.Email, agent.Email),
                    new Claim(ClaimTypes.Role, "Agent"),

                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authenticationProperties = new AuthenticationProperties();
                var principal = new ClaimsPrincipal(claimsIdentity);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authenticationProperties);
                return RedirectToAction(nameof(Dashboard));
            }
        }
        public IActionResult ViewDetails(int loggedinAgentId, string email)
        {
            int agentId = int.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            Agent agent = _agentService.GetAgentByEmail(email);
            return View(agent);
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Agent");
        }
        public IActionResult Dashboard()
        {
            //int agentId = int.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            //Agent agent = _agentService.GetAgent(agentId);
            //return View(agentId);

            int agentId = int.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            Agent agent = _agentService.GetAgent(agentId);
            return View(agent);

        }
        [Authorize(Roles = "Manager")]
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agent = _agentService.GetAgent(id.Value);
            if (agent == null)
            {
                return NotFound();
            }
            return View(agent);
        }
        [Authorize(Roles = "Manager")]
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {

            _agentService.DeleteAgent(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        [Authorize(Roles = "Manager")]
        public IActionResult Details(int? id)
        {
            return View(_agentService.GetAgent(id.Value));
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agent = _agentService.GetAgent(id.Value);
            if (agent == null)
            {
                return NotFound();
            }
            return View(agent);
        }
        [HttpPost]
        public IActionResult Edit(int id, Agent agent)
        {
            if (id != agent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _agentService.UpdateAgent(agent);
                return RedirectToAction(nameof(Index));
            }
            return View(agent);
        }

    }
}
