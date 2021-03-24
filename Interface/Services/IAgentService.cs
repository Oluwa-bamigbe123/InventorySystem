using InventorySystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventorySystem.Interface.Services
{
    public interface IAgentService
    {
        public Agent AddAgent(Agent agent);
        public Agent GetAgent(int id);

        public void DeleteAgent(int id);
        public List<Agent> GetAll();
        public Agent UpdateAgent(Agent agent);
        public Agent Login(string username, string password);
        public Agent GetAgentByEmail(string email);

        public Agent FindByUserName(string userName);

    }
}
