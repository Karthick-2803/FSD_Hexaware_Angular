using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DataAccess;
using DAL.Models;

namespace UIApp
{
    public class EventDetailsBL
    {
        private readonly IEventDetailsRepo<EventDetails> _eventRepo;

        public EventDetailsBL(IEventDetailsRepo<EventDetails> eventRepo)
        {
            this._eventRepo = eventRepo;
        }

        public bool AddEvent(EventDetails eventDetails)
        {
            var added = _eventRepo.AddEvent(eventDetails);
            if (added != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateEvent(EventDetails eventDetails)
        {
            var updated = _eventRepo.UpdateEvent(eventDetails);
            if (updated != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteEvent(int eventId)
        {
            var deleted = _eventRepo.DeleteEvent(eventId);
            if (deleted != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public EventDetails GetEventById(int eventId)
        {
            return _eventRepo.GetEventById(eventId);
        }

        public List<EventDetails> GetAllEvents()
        {
            return _eventRepo.GetAllEvents();
        }
    }
}
