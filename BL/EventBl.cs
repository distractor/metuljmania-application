using AutoMapper;
using MetuljmaniaDatabase.DAL;
using MetuljmaniaDatabase.Models.BlModel;
using MetuljmaniaDatabase.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace MetuljmaniaDatabase.BL
{
    public class EventBl : BaseBl, IEventBl
    {
        private readonly IBaseDAL _baseDAL;

        public EventBl(IMapper mapper, IPrincipal principal, IBaseDAL baseDAL) : base(mapper, principal)
        {
            _baseDAL = baseDAL;
        }

        #region Public methods.

        ///<inheritdoc/>
        public async Task<List<EventBlModel>> GetEventsAsync()
        {
            _logger.Info($"Get events.");

            var eventDbModels = await _baseDAL.GetEventsAsync();
            var eventBlModels = _mapper.Map<List<EventBlModel>>(eventDbModels);

            return eventBlModels;
        }

        ///<inheritdoc/>
        public async Task<EventBlModel> GetEventAsync(int id)
        {
            _logger.Info($"Get event with id {id}.");

            var eventDbModel = await _baseDAL.GetEventAsync(id);
            if (eventDbModel is null)
            {
                throw new Exception($"Event with id {id} not found.");
            }

            var eventBlModel = _mapper.Map<EventBlModel>(eventDbModel);

            return eventBlModel;
        }

        ///<inheritdoc/>
        public async Task<EventBlModel> PostEventAsync(EventBlModel newEvent)
        {
            // Post.
            var eventDbModel = _mapper.Map<Event>(newEvent);
            var insertedEventDbModel = await _baseDAL.PostEventAsync(eventDbModel);
            var insertedEventBlModel = await GetEventAsync(insertedEventDbModel.Id);

            return insertedEventBlModel;
        }

        #endregion

    }
}
