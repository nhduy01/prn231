using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Models;
using Application.SendModels.Authentication;

namespace Application.Mappers
{
    public partial class MapperConfigs : Profile
    {
        partial void AddAccountMapperConfig()
        {
            CreateMap<CreateAccountRequest, Account>();
        }
    }
}
