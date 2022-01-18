using System.Threading.Tasks;
using Events.Application.Interfaces;
using Events.Persistence.Interfaces;
using Events.Domain;
using System;
using Events.Application.DTOs;
using AutoMapper;

namespace Events.Application
{
    public class EventService : IEventService
    {
        private readonly IGeneralProtocols _generalPersistence;
        private readonly IEventProtocols _eventPersistence;
        private readonly IMapper _mapper;

        public EventService(IGeneralProtocols generalPersistence, IEventProtocols eventPersistence, IMapper mapper)
        {
            _eventPersistence = eventPersistence;
            _mapper = mapper;
            _generalPersistence = generalPersistence;
        }
        public async Task<EventDto> AddEvents(EventDto model)
        {
            try
            {
                var eventt = _mapper.Map<Event>(model);

                _generalPersistence.Add<Event>(eventt);

                if (await _generalPersistence.SaveChangesAsync())
                {
                    var dtoReturn = await _eventPersistence.GetEventByIdAsync(eventt.Id, false);
                    return _mapper.Map<EventDto>(dtoReturn);

                }

                return null;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<EventDto> UpdateEvent(int eventId, EventDto model)
        {
            try
            {
                var getEvent = await _eventPersistence.GetEventByIdAsync(eventId, false);
                if (getEvent == null) return null;

                model.Id = eventId;

                _mapper.Map(model, getEvent);

                _generalPersistence.Update<Event>(getEvent);

                if (await _generalPersistence.SaveChangesAsync())
                {
                    var dtoReturn = await _eventPersistence.GetEventByIdAsync(getEvent.Id, false);
                    return _mapper.Map<EventDto>(dtoReturn);
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
                if (getEvent == null) throw new Exception("Event for delete not found");


                _generalPersistence.Delete<Event>(getEvent);
                return await _generalPersistence.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<EventDto[]> GetEventsAsync(bool includePanelist = false)
        {
            try
            {
                var events = await _eventPersistence.GetEventsAsync(includePanelist);
                if (events == null) return null;

                var result = _mapper.Map<EventDto[]>(events);

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<EventDto[]> GetEventsByThemeAsync(string theme, bool includePanelist = false)
        {
            try
            {
                var events = await _eventPersistence.GetEventsByThemeAsync(theme, includePanelist);
                if (events == null) return null;

                var result = _mapper.Map<EventDto[]>(events);

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<EventDto> GetEventByIdAsync(int eventId, bool includePanelist = false)
        {
            try
            {
                var events = await _eventPersistence.GetEventByIdAsync(eventId, includePanelist);
                if (events == null) return null;

                var result = _mapper.Map<EventDto>(events);

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}