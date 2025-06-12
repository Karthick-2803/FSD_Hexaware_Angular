using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.DataAccess
{
    public class EventDetailsRepo : IEventDetailsRepo<EventDetails>
    {
        public EventDetails AddEvent(EventDetails eventDetails)
        {
            using (EventDetailsContext dbContext = new EventDetailsContext())
            {
                dbContext.Events.Add(eventDetails);
                dbContext.SaveChanges();
                return eventDetails;
            }
        }

        public EventDetails UpdateEvent(EventDetails eventDetails)
        {
            using (EventDetailsContext dbContext = new EventDetailsContext())
            {
                var existing = dbContext.Events.Where(ev => ev.EventId.Equals(eventDetails.EventId)).FirstOrDefault();
                if (existing != null)
                {
                    existing.EventName = eventDetails.EventName;
                    existing.EventCategory = eventDetails.EventCategory;
                    existing.EventDate = eventDetails.EventDate;
                    existing.Description = eventDetails.Description;
                    existing.Status = eventDetails.Status;
                    dbContext.SaveChanges();
                    return existing;
                }
                return null;
            }
        }

        public EventDetails DeleteEvent(int eventId)
        {
            using (EventDetailsContext dbContext = new EventDetailsContext())
            {
                var evt = dbContext.Events.Where(ev => ev.EventId.Equals(eventId)).FirstOrDefault();
                if (evt != null)
                {
                    dbContext.Events.Remove(evt);
                    dbContext.SaveChanges();
                    return evt;
                }
                return null;
            }
        }

        public EventDetails GetEventById(int eventId)
        {
            using (EventDetailsContext dbContext = new EventDetailsContext())
            {
                var existing = dbContext.Events.Where(ev => ev.EventId.Equals(eventId)).FirstOrDefault();

                return existing;
            }
        }

        public List<EventDetails> GetAllEvents()
        {
            using (EventDetailsContext dbContext = new EventDetailsContext())
            {
                return dbContext.Events.ToList();
            }
        }
    }
}
       