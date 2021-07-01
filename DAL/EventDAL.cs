using MetuljmaniaDatabase.Models.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MetuljmaniaDatabase.DAL
{
    public partial class BaseDAL
    {
        ///<inheritdoc/>
        public async Task<List<Event>> GetEventsAsync()
        {
            _logger.Info($"Get events from database.");

            using var dbMetuljmaniaContext = new MetuljmaniaContext(_options);
            var events = dbMetuljmaniaContext.Event
                // Includes.
                .Include(e => e.Pilot)
                .ToListAsync();

            return await events;
        }

        ///<inheritdoc/>
        public async Task<Event> GetEventAsync(int id)
        {
            _logger.Info($"Get event from database with id {id}.");

            using var dbMetuljmaniaContext = new MetuljmaniaContext(_options);
            var eventDbModel = await dbMetuljmaniaContext.Event
                // Includes.
                .Include(e => e.Pilot)
                .FirstOrDefaultAsync(e => e.Id == id);

            return eventDbModel;
        }

        ///<inheritdoc/>
        public async Task<Event> PostEventAsync(Event newEvent)
        {
            _logger.Info($"Insert new event {newEvent.Name} to database.");

            try
            {
                using var dbMetuljmaniaContext = new MetuljmaniaContext(_options);

                // Post.
                dbMetuljmaniaContext.Event.Add(newEvent);
                await dbMetuljmaniaContext.SaveChangesAsync();

                return newEvent;
            }
            catch (Exception ex)
            {
                var msg = $"Something went wrong while posting event to database. Exception: {ex.InnerException}";
                _logger.Error(msg);
                throw new Exception(msg);
            }
        }
    }
}
