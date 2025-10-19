using BLL.IService;
using DAL.IRepository;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class SessionService : ISessionService
    {
        private readonly ISessionRepository _sessionRepository;
        public SessionService(ISessionRepository sessionRepository)
        {
           _sessionRepository = sessionRepository;
        }
        public Task<Session> CreateSession(Session session)
      =>  _sessionRepository.CreateSession(session);

        public Task<bool> DeleteSession(int sessionId)
        => _sessionRepository.DeleteSession(sessionId);

        public Task<Session> GetSessionById(int sessionId)
     =>   _sessionRepository.GetSessionById(sessionId);

        public Task<Session> UpdateSession(Session session)
       => _sessionRepository.UpdateSession(session);
    }
}
