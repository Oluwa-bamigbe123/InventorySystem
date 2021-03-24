using InventorySystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventorySystem.Interface.Repository
{
    public interface IManagerRepository
    {
        public string CreateManager(Manager manager);
        public Manager AddManager(Manager manager);
        public Manager GetManager(int id);
        public Manager FindById(int id);
        public Manager FindByProductId(int id);
        public void DeleteManager(int id);
        public List<Manager> GetAll();
        public Manager UpdateManager(Manager manager);
        public Manager FindByEmail(string email);
    }
}
