using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataAccess
{
    public interface IEventDetailsRepo<T>
    {
        T AddEvent(T eventDetails);
        T UpdateEvent(T eventDetails);
        T DeleteEvent(int eventId);
        T GetEventById(int eventId);
        List<T> GetAllEvents();
    }
}
