using InventorySystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventorySystem.Models
{
    public class Equipments : BaseEntity
    {
        public Equipments()
        {
            EquipmentDistribution = new List<EquipmentDistribution>();

        }
     

        [Required]
        public string EquipmentName { get; set; }
        [Required]
        public string EquipmentType { get; set; }
        [Required]
        [Range(1,int.MaxValue,ErrorMessage ="Number Of Equipment Must Be Greater Than 0")]
        public int EquipmentNumber { get; set; }
        public IList<EquipmentDistribution> EquipmentDistribution { get; set; }

    }
}
