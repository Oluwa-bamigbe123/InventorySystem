using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventorySystem.Models
{
    public class AddEquipmentVM
    {
        public IEnumerable<SelectListItem> EquipmentNameSelectList { get; set; }
        public string EquipmentType { get; set; }
        public int NumberOfEquipment { get; set; }
       
    }
}
