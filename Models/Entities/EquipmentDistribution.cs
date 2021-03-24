using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventorySystem.Models.Entities
{
    public class EquipmentDistribution : BaseEntity
    {
     
        public Equipments Equipments { get; set; }
        [Required]
        public int EquipmentGeneratedKey { get; set; }
        [Required]
        public int EquipmentName { get; set; }
    
        public Manager Mamager { get; set; }
        [Required]
        public int ManagerId { get; set; }
        public Agent Agent { get; set; }
        [Required]
        public int AgentId { get; set; }
        [Required]
        public DateTime DateAssigned { get; set; }
        [Required]
        public string Status { get; set; }
    }
}
