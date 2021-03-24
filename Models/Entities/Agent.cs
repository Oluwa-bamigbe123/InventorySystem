﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventorySystem.Models.Entities
{
    public class Agent : BaseEntity
    {
        public Agent()
        {
            EquipmentDistribution = new List<EquipmentDistribution>();
           
        }
        [Required]
       public string UserName { get; set; }
        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
          ErrorMessage = "Email is not valid.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MinLength(6)]
        [MaxLength(72)]
        public string Password { get; set; }
        [Required]
        public string Address { get; set; }
        public IList<EquipmentDistribution> EquipmentDistribution { get; set; }



    }
}
