﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Models;
using Infracstructures.SendModels.Authentication;

namespace Application.Mappers
{
    public partial class MapperConfigs : Profile
    {
        partial void AddCompetitorMapperConfig()
        {
            CreateMap<Competitor, CreateCompetitorRequest>();
        }
        
    }
}