using InventorySystem.Interface.Repository;
using InventorySystem.Models;
using InventorySystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventorySystem.Domain.Repository
{
    public class AgentRepository : IAgentRepository
    {
        private readonly InventoryDbContext _context;
        public AgentRepository(InventoryDbContext context)
        {
            _context = context;

        }
        public Agent AddAgent(Agent agent)
        {
            _context.Agents.Add(agent);
            _context.SaveChanges();
            return agent;
        }

        public string CreateAgent(Agent agent)
        {
            try
            {
                _context.Agents.Add(agent);
                _context.SaveChanges();
                return agent.Email;
            }
            catch (Exception ea)
            {
                Console.WriteLine($"err2: {ea.Message}");
            }
            return agent.Email;
        }

        public void DeleteAgent(int id)
        {
            var agent = _context.Agents.Find(id);
            _context.Remove(agent);
            _context.SaveChanges();
        }

        public Agent FindByEmail(string email)
        {
            return _context.Agents.FirstOrDefault(i => i.Email == email);
        }

        public Agent FindById(int id)
        {
            return _context.Agents.FirstOrDefault(i => i.Id == id);
        }

        public Agent FindByProductId(int id)
        {
            throw new NotImplementedException();
        }

        public Agent FindByUserName(string userName)
        {
            return _context.Agents.FirstOrDefault(u => u.UserName == userName);
        }

        public Agent GetAgent(int id)
        {
            return _context.Agents.Find(id);
        }

        public Agent GetAgentByEmail(string email)
        {
            return _context.Agents.Find(email);
        }

        public List<Agent> GetAll()
        {
            return _context.Agents.ToList();
        }

        public Agent UpdateAgent(Agent agent)
        {
            _context.Agents.Update(agent);
            _context.SaveChanges();
            return agent;
        }
    }
}
