using InventorySystem.Interface.Repository;
using InventorySystem.Models;
using InventorySystem.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventorySystem.Domain.Repository
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly InventoryDbContext _context;

        public EquipmentRepository(InventoryDbContext context)
        {
            _context = context;

        }
        public Equipments AddEquipment(Equipments equipments)
        {
            _context.Equipments.Add(equipments);
            _context.SaveChanges();
            return equipments;

        }

        public int CreateEquipment(Equipments equipments)
        {
            try
            {
                _context.Equipments.Add(equipments);
                _context.SaveChanges();
                return equipments.Id;
            }
            catch (Exception ea)
            {
                Console.WriteLine($"err2: {ea.Message}");
            }
            return equipments.Id;
        }

        public void DeleteEquipment(int id)
        {
            var equipment = _context.Equipments.Find(id);
            _context.Remove(equipment);
            _context.SaveChanges();
        }

        public Equipments FindById(int id)
        {
            return _context.Equipments.FirstOrDefault(i => i.Id == id);
        }

        public Equipments FindByProductId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Equipments> GetAll()
        {
            return _context.Equipments.ToList();
        }

        public Equipments GetEquipments(int id)
        {
            return _context.Equipments.Find(id);
        }

        public Equipments UpdateEquipments(Equipments equipments)
        {
            _context.Equipments.Update(equipments);
            _context.SaveChanges();
            return equipments;
        }
    }
}
