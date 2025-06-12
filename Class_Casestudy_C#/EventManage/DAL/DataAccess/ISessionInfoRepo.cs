using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataAccess
{
    public interface ISessionInfoRepo<T>
    {
        T AddSession(T session);
        T UpdateSession(T session);
        T DeleteSession(int sessionId);
        T GetSessionById(int sessionId);
        List<T> GetSessionsByEventId(int eventId);
        List<T> GetAllSessions();
    }
}
