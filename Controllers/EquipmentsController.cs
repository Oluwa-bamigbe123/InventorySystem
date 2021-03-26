using InventorySystem.Interface.Services;
using InventorySystem.Models;
using InventorySystem.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventorySystem.Controllers
{
    public class EquipmentsController : Controller
    {
        private readonly IEquipmentService _equipmentService;

        
        public EquipmentsController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        [Authorize(Roles = "Manager")]
        public IActionResult Index()
        {
            return View(_equipmentService.GetAll());
        }
        //GET - CREATE
        [Authorize(Roles = "Manager")]
        public IActionResult Create()
        {
            return View();

        }
        //POST - CREATE
        [Authorize(Roles = "Manager")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Equipments equipments)
        {
            if (ModelState.IsValid)
            {
                _equipmentService.AddEquipment(equipments);
                return RedirectToAction(nameof(Index));
              
            }
            return View(equipments);
            

        }
        [Authorize(Roles = "Manager")]
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipment = _equipmentService.GetEquipments(id.Value);
            if (equipment == null)
            {
                return NotFound();
            }
            return View(equipment);
        }

        [Authorize(Roles = "Manager")]
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {

            _equipmentService.DeleteEquipment(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        [Authorize(Roles = "Manager")]
        public IActionResult Details(int? id)
        {
            return View(_equipmentService.GetEquipments(id.Value));
        }
        [HttpGet]
        public IActionResult AddEquipment()
        {
            AddEquipmentVM addEquipmentVM = new AddEquipmentVM();

            List<SelectListItem> EquipmentNameSelectList = new List<SelectListItem>();

            List<Equipments> equipments = _equipmentService.GetAll();

            foreach (var equipment in equipments)
            {
                EquipmentNameSelectList.Add(new SelectListItem
                {
                    Value = equipment.Id.ToString(),
                    Text = equipment.EquipmentName
                });
            }
            addEquipmentVM.EquipmentNameSelectList = EquipmentNameSelectList;

            return View(addEquipmentVM);
        }
        
    }
}
