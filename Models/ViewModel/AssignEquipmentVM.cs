using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventorySystem.Models.ViewModel
{
    public class AssignEquipmentVM
    {
        public string EquipmentName { get; set; }
        public int EquipmentGeneratedKey { get; set; }
        public string AgentUserName { get; set; }
        public DateTime DateAssigned { get; set; }

    }
}
