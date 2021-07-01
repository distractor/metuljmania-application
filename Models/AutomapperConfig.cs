using AutoMapper;
using MetuljmaniaDatabase.Models.BlModel;
using MetuljmaniaDatabase.Models.DbModels;
using MetuljmaniaDatabase.Models.DTO;

namespace Glista.Core.Models.Models
{
    /// <summary>
    /// Automapping configuration.
    /// </summary>
    public class AutomapperConfig : Profile
    {

        public AutomapperConfig()
        {
            // Mapping between databse and general models.
            MapDBAndBLConfig();

            // Mapping between general models and DTOs.
            MapperBLAndDTOConfig();
        }

        /// <summary>
        /// Mapping between databse and general models.
        /// </summary>
        private void MapDBAndBLConfig()
        {

            #region File.

            CreateMap<File, FileBlModel>()
                .ReverseMap();

            #endregion

            #region Event.

            CreateMap<Event, EventBlModel>()
                .ReverseMap();

            #endregion

            #region Pilot.

            CreateMap<Pilot, PilotBlModel>()
                .ReverseMap();

            #endregion

        }

        /// <summary>
        /// // Mapping between general models and DTOs.
        /// </summary>
        private void MapperBLAndDTOConfig()
        {

            #region File.

            CreateMap<FileBlModel, BasicInfoDTO>()
                .AfterMap((s, d) => d.Name = s.Path)
                .ReverseMap();

            CreateMap<FileBlModel, FileDTO>()
                .ReverseMap();

            #endregion

            #region Event.

            CreateMap<EventBlModel, BasicInfoDTO>()
                .ReverseMap();

            CreateMap<EventBlModel, EventDTO>()
                .ReverseMap();

            CreateMap<EventBlModel, NewEventDTO>()
                .ReverseMap();

            #endregion

            #region Pilot.

            CreateMap<PilotBlModel, PilotDTO>()
                .ReverseMap();

            CreateMap<PilotBlModel, NewPilotDTO>()
                .ReverseMap();

            CreateMap<PilotBlModel, EditPilotDTO>()
                .ReverseMap();

            #endregion

        }
    }
}
