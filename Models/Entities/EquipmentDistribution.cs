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
        public int EquipmentsId { get; set; }
        public Manager Manager { get; set; }
        [Required]
        public int ManagerId { get; set; }
        public Agent Agent { get; set; }
        [Required]
        public int AgentId { get; set; }
  
        [Required]
        public DateTime DateAssigned { get; set; }
        [Required]
        public int NumberOfEquipmentAssigned { get; set; }
   
    }
}
