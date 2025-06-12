using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DataAccess;
using DAL.Models;

namespace UIApp
{
    public class SessionInfoBL
    {
        private readonly ISessionInfoRepo<SessionInfo> _sessionRepo;

        public SessionInfoBL(ISessionInfoRepo<SessionInfo> sessionRepo)
        {
            this._sessionRepo = sessionRepo;
        }

        public bool AddSession(SessionInfo session)
        {
            var added = _sessionRepo.AddSession(session);
            if (added != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateSession(SessionInfo session)
        {
            var updated = _sessionRepo.UpdateSession(session);
            if (updated != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteSession(int sessionId)
        {
            var deleted = _sessionRepo.DeleteSession(sessionId);
            if (deleted != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public SessionInfo GetSessionById(int sessionId)
        {
            return _sessionRepo.GetSessionById(sessionId);
        }

        public List<SessionInfo> GetSessionsByEventId(int eventId)
        {
            return _sessionRepo.GetSessionsByEventId(eventId);
        }

        public List<SessionInfo> GetAllSessions()
        {
            return _sessionRepo.GetAllSessions();
        }
    }
}

