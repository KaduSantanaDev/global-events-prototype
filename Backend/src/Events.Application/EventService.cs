using System.Threading.Tasks;
using Events.Application.Interfaces;
using Events.Persistence.Interfaces;
using Events.Domain;
using System;

namespace Events.Application
{
    public class EventService : IEventService
    {
        private readonly IGeneralProtocols _generalPersistence;
        private readonly IEventProtocols _eventPersistence;

        public EventService(IGeneralProtocols generalPersistence, IEventProtocols eventPersistence)
        {
            _eventPersistence = eventPersistence;
            _generalPersistence = generalPersistence;
        }
        public async Task<Event> AddEvents(Event model)
        {
            try
            {
                _generalPersistence.Add<Event>(model);
                if(await _generalPersistence.SaveChangesAsync()) {
                    return await _eventPersistence.GetEventByIdAsync(model.Id, false);
                }
                
                return null;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }
               
        public async Task<Event> UpdateEvent(int eventId, Event model)
        {
            try
            {
                var getEvent = await _eventPersistence.GetEventByIdAsync(eventId, false);
                if(getEvent == null) return null;
                
                model.Id = eventId;
                
                _generalPersistence.Update(model);
                if(await _generalPersistence.SaveChangesAsync()) {
                    return await _eventPersistence.GetEventByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> DeleteEvent(int eventId)
        {
            try
            {
                var getEvent = await _eventPersistence.GetEventByIdAsync(eventId, false);
                if(getEvent == null) throw new Exception("Event for delete not found");
                
                
                _generalPersistence.Delete<Event>(getEvent);
                return await _generalPersistence.SaveChangesAsync();
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }
        
        public async  Task<Event[]> GetEventsAsync(bool includePanelist = false)
        {
            try
            {
                var events = await _eventPersistence.GetEventsAsync(includePanelist);
                if(events == null) return null;
                
                return events;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        
        public async Task<Event[]> GetEventsByThemeAsync(string theme, bool includePanelist = false)
        {
            try
            {
                var events = await _eventPersistence.GetEventsByThemeAsync(theme, includePanelist);
                if(events == null) return null;
                
                return events;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Event> GetEventByIdAsync(int eventId, bool includePanelist = false)
        {
            try
            {
                var events = await _eventPersistence.GetEventByIdAsync(eventId, includePanelist);
                if(events == null) return null;
                
                return events;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}