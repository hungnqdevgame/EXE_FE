using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IService
{
    public interface ISessionService
    {
        Task<Session> CreateSession(Session session);
        Task<Session> GetSessionById(int sessionId);
        Task<bool> DeleteSession(int sessionId);
        Task<Session> UpdateSession(Session session);
    }
}
