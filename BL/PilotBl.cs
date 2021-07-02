using AutoMapper;
using MetuljmaniaDatabase.DAL;
using MetuljmaniaDatabase.Models.BlModel;
using MetuljmaniaDatabase.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Threading.Tasks;

namespace MetuljmaniaDatabase.Bl
{
    public class PilotBl : BaseBl, IPilotBl
    {
        private readonly IBaseDAL _baseDAL;

        public PilotBl(IMapper mapper, IPrincipal principal, IBaseDAL baseDAL) : base(mapper, principal)
        {
            _baseDAL = baseDAL;
        }

        #region Public methods.

        ///<inheritdoc/>
        public async Task<List<PilotBlModel>> GetPilotsAsync()
        {
            _logger.Info($"Get pilots.");

            var pilotsDbModel = await _baseDAL.GetPilotsAsync();
            var pilotsBlModel = _mapper.Map<List<PilotBlModel>>(pilotsDbModel);

            return pilotsBlModel;
        }

        ///<inheritdoc/>
        public async Task<PilotBlModel> GetPilotAsync(int id)
        {
            _logger.Info($"Get pilot with id {id}.");

            var pilotDbModel = await _baseDAL.GetPilotAsync(id);
            if (pilotDbModel is null)
            {
                throw new Exception($"Pilot with id {id} not found.");
            }

            var pilotModel = _mapper.Map<PilotBlModel>(pilotDbModel);

            return pilotModel;
        }

        ///<inheritdoc/>
        public async Task PutPilotAsync(int id, PilotBlModel editPilotModel)
        {
            if (id != editPilotModel.Id)
            {
                throw new Exception("Conflict on given pilot id and pilot object.");
            }

            // Get pilotto check if exists.
            await GetPilotAsync(editPilotModel.Id);
            // Map to DB model.
            var updatePilotDbModel = _mapper.Map<Pilot>(editPilotModel);
            // Update pilot.
            await _baseDAL.PutPilotAsync(updatePilotDbModel);
        }

        ///<inheritdoc/>
        public async Task<PilotBlModel> PostPilotAsync(PilotBlModel pilot)
        {
            // Post.
            var pilotDbModel = _mapper.Map<Pilot>(pilot);
            var insertedPilotDbModel = await _baseDAL.PostPilotAsync(pilotDbModel);
            var insertedPilotModel = await GetPilotAsync(insertedPilotDbModel.Id);

            return insertedPilotModel;
        }

        #endregion
    }
}
