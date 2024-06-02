using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Commons;
using AutoMapper;

namespace Infracstructures.Mappers
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
    }

}
