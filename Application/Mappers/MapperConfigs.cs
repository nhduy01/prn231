using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Commons;
using AutoMapper;

namespace Application.Mappers
{
    public partial class MapperConfigs : Profile
    {
        public MapperConfigs()
        {
            //add map here
            //CreateMap<SourceModel, DestinationModel>();

            // Create mapping between Pagination
            CreateMap(typeof(Pagination<>), typeof(Pagination<>));

            //Add Account Mapper
            AddAccountMapperConfig();

        }

        partial void AddAccountMapperConfig();
        partial void AddAwardMapperConfig();
        partial void AddAwardScheduleMapperConfig();
        partial void AddCollectionMapperConfig();
        partial void AddEducationalLevelMapperConfig();
        partial void AddCompetitorMapperConfig();
        partial void AddImageMapperConfig();
        partial void AddNotificationMapperConfig();
        partial void AddPaintingMapperConfig();
        partial void AddPaintingCollectionMapperConfig();
        partial void AddPostMapperConfig();
        partial void AddPostImageMapperConfig();
        partial void AddResourcesMapperConfig();
        partial void AddRoundMapperConfig();
        partial void AddScheduleMapperConfig();
        partial void AddSponsorMapperConfig();
        partial void AddTopicMapperConfig();
        partial void AddContestMapperConfig();
    }

}
