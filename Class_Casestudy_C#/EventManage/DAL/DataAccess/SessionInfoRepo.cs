using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using Microsoft.Extensions.Logging;

namespace DAL.DataAccess
{
    public class SessionInfoRepo : ISessionInfoRepo<SessionInfo>
    {
        public SessionInfo AddSession(SessionInfo session)
        {
            using (EventDetailsContext dbContext = new EventDetailsContext())
            {
                dbContext.Sessions.Add(session);
                dbContext.SaveChanges();
                return session;
            }
        }

        public SessionInfo UpdateSession(SessionInfo session)
        {
            using (EventDetailsContext dbContext = new EventDetailsContext())
            {
                var existing = dbContext.Sessions.Where(si => si.SessionId.Equals(session.SessionId)).FirstOrDefault();
                if (existing != null)
                {
                    existing.SessionTitle = session.SessionTitle;
                    existing.SpeakerId = session.SpeakerId;
                    existing.Description = session.Description;
                    existing.SessionStart = session.SessionStart;
                    existing.SessionEnd = session.SessionEnd;
                    existing.SessionUrl = session.SessionUrl;
                    dbContext.SaveChanges();
                    return existing;
                }
                return null;
            }
        }

        public SessionInfo DeleteSession(int sessionId)
        {
            using (EventDetailsContext dbContext = new EventDetailsContext())
            {
                var session = dbContext.Sessions.Where(si => si.SessionId.Equals(sessionId)).FirstOrDefault();
                if (session != null)
                {
                    dbContext.Sessions.Remove(session);
                    dbContext.SaveChanges();
                    return session;
                }
                return null;
            }
        }

        public SessionInfo GetSessionById(int sessionId)
        {
            using (EventDetailsContext dbContext = new EventDetailsContext())
            {
                var existing = dbContext.Sessions.Where(si => si.SessionId.Equals(sessionId)).FirstOrDefault();

                return existing;
            }
        }

        public List<SessionInfo> GetSessionsByEventId(int eventId)
        {
            using (EventDetailsContext dbContext = new EventDetailsContext())
            {
                return dbContext.Sessions
                    .Where(s => s.EventId == eventId)
                    .ToList();
            }
        }

        public List<SessionInfo> GetAllSessions()
        {
            using (EventDetailsContext dbContext = new EventDetailsContext())
            {
                return dbContext.Sessions.ToList();
            }
        }
    }
}
