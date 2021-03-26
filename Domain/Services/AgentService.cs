using InventorySystem.Interface.Repository;
using InventorySystem.Interface.Services;
using InventorySystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventorySystem.Domain.Services
{
    public class AgentService : IAgentService
    {
        private readonly IAgentRepository _agentRepository;


        public AgentService(IAgentRepository agentRepository)
        {
            _agentRepository = agentRepository;
        }
        public Agent AddAgent(Agent agent)
        {
            Agent ag = _agentRepository.AddAgent(agent);
            return ag;
        }

        public void DeleteAgent(int id)
        {
            _agentRepository.DeleteAgent(id);
        }

        public Agent FindById(int id)
        {
            return _agentRepository.FindById(id);
        }

        public Agent FindByUserName(string userName)
        {
          return  _agentRepository.FindByUserName(userName);
        }

        //public Agent FindByUserName(string userName)
        //{
        //   retu
        //}

        public Agent GetAgent(int id)
        {
           return _agentRepository.GetAgent(id);
        }

        public Agent GetAgentByEmail(string email)
        {
            return _agentRepository.GetAgentByEmail(email);
        }

        public List<Agent> GetAll()
        {
           return _agentRepository.GetAll();
        }

        public Agent Login(string username, string password)
        {
            var agent = _agentRepository.FindByEmail(username);
            if (agent == null || agent.Password != password)
            {
                return null;
            }

            return agent;
        }

        public Agent UpdateAgent(Agent agent)
        {
            return _agentRepository.UpdateAgent(agent);
        }
    }
}
