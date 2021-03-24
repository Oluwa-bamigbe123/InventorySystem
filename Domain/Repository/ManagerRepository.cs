using InventorySystem.Interface.Repository;
using InventorySystem.Models;
using InventorySystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventorySystem.Domain.Repository
{
    public class ManagerRepository : IManagerRepository
    {
        private readonly InventoryDbContext _context;
        public ManagerRepository(InventoryDbContext context)
        {
            _context = context;

        }
        public Manager AddManager(Manager manager)
        {
            _context.Managers.Add(manager);
            _context.SaveChanges();
            return manager;
        }

        public string CreateManager(Manager manager)
        {
            try
            {
                _context.Managers.Add(manager);
                _context.SaveChanges();
                return manager.Email;
            }
            catch (Exception ea)
            {
                Console.WriteLine($"err2: {ea.Message}");
            }
            return manager.Email;
        }

        public void DeleteManager(int id)
        {
            var manager = _context.Managers.Find(id);
            _context.Remove(manager);
            _context.SaveChanges();
        }

        public Manager FindByEmail(string email)
        {
            
                return _context.Managers.FirstOrDefault(i => i.Email == email);
            
        }

        public Manager FindById(int id)
        {
            return _context.Managers.FirstOrDefault(i => i.Id == id);
        }

        public Manager FindByProductId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Manager> GetAll()
        {
            return _context.Managers.ToList();
        }

        public Manager GetManager(int id)
        {
            return _context.Managers.Find(id);
        }

        public Manager UpdateManager(Manager manager)
        {
            _context.Managers.Update(manager);
            _context.SaveChanges();
            return manager;
        }
    }
}
