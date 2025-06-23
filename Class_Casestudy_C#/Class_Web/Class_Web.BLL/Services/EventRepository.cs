using System;
using System.Linq;
using System.Text;
using Class_Web.BLL.Interfaces;
using Class_Web.DAL.Models;
using Class_Web.DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace Class_Web.BLL.Services
{
    public class EventRepository : IEventRepository
    {
        private readonly Class_WebDbContext _context;

        public EventRepository(Class_WebDbContext context) => _context = context;

        public async Task<IEnumerable<EventDetails>> GetAllAsync()
        {
            return await _context.Events.ToListAsync();
        }

        public Task<EventDetails?> GetByIdAsync(int id) =>
            _context.Events.FirstOrDefaultAsync(e => e.EventId == id);

        public async Task AddAsync(EventDetails ev)
        {
            _context.Events.Add(ev);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(EventDetails ev)
        {
            _context.Events.Update(ev);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var e = await GetByIdAsync(id);
            if (e != null)
            {
                _context.Events.Remove(e);
                await _context.SaveChangesAsync();
            }
        }
    }

}
