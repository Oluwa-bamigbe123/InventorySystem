using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventorySystem.Models.ViewModel
{
    public class AssignEquipmentVM
    {
        public int EquipmentId { get; set; }
        public int AgentId { get; set; }
        public int NumberOfEquipmentAssigned { get; set; }

        public IEnumerable<SelectListItem> EquipmentNameSelectList { get; set; }
        public IEnumerable<SelectListItem> AgentNameSelectList { get; set; }

    }
}
