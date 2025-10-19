using DAL.IRepository;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class SessionRepository : ISessionRepository
    {
        private readonly QuizDBContext _context;
        public SessionRepository(QuizDBContext context)
        {
            _context = context;
        }
        
        public async Task<Session> CreateSession(Session session)
        {
            var newSession = new Session
            {
                UserId = session.UserId,
                SetId = session.SetId,
                StartTime = session.StartTime,
                EndTime = session.EndTime,
                Mode = session.Mode
            };
            _context.Sessions.Add(session);
            await _context.SaveChangesAsync();
            return newSession;
        }

        public async Task<Session> GetSessionById(int sessionId)
        {
            return await _context.Sessions.FindAsync(sessionId);
        }

        public async Task<bool> DeleteSession(int sessionId)
        {
            var session = await _context.Sessions.FindAsync(sessionId);
            if (session == null) return false;
            _context.Sessions.Remove(session);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Session> UpdateSession(Session session)
        {
            var existingSession = await _context.Sessions.FindAsync(session.Id);
     
            existingSession.UserId = session.UserId;
            existingSession.SetId = session.SetId;
            existingSession.StartTime = session.StartTime;
            existingSession.EndTime = session.EndTime;
            existingSession.Mode = session.Mode;
            await _context.SaveChangesAsync();
            return existingSession;
        }
    }
}
