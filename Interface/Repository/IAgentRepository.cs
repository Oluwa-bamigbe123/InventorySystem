using InventorySystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventorySystem.Interface.Repository
{
    public interface IAgentRepository
    {
        public string CreateAgent(Agent agent);
        public Agent AddAgent(Agent agent);
        public Agent GetAgent(int id);
        public Agent FindById(int id);
        public Agent FindByProductId(int id);
        public void DeleteAgent(int id);
        public List<Agent> GetAll();
        public Agent UpdateAgent(Agent agent);
        public Agent FindByEmail(string email);
        public Agent GetAgentByEmail(string email);
        public Agent FindByUserName(string userName);
      
    }
}
