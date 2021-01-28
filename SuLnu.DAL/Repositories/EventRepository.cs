using System;
using System.Collections.Generic;
using System.Text;
using SuLnu.DAL.Entities;
using SuLnu.DAL.EF;
using SuLnu.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SuLnu.DAL.Repositories
{
    class EventRepository : IRepository<Event>
    {
        private SuLnuDbContext db;

        public EventRepository(SuLnuDbContext context)
        {
            this.db = context;
        }

        public IEnumerable<Event> GetAll()
        {
            return db.Events;
        }

        public Event Get(int id)
        {
            return db.Events.Find(id);
        }

        public void Create(Event @event)
        {
            db.Events.Add(@event);
        }

        public void Update(Event @event)
        {
            db.Entry(@event).State = EntityState.Modified;
        }

        public IEnumerable<Event> Find(Func<Event, Boolean> predicate)
        {
            return db.Events.Where(predicate).ToList();
        }

        public void Delete(string id)
        {
            Event @event = db.Events.Find(id);
            if (@event != null)
                db.Events.Remove(@event);
        }
    }
}
