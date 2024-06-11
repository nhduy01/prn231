using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModels.ContestViewModels;
using AutoMapper;
using Domain.Models;

namespace Application.Mappers
{
    public partial class MapperConfigs : Profile
    {
        partial void AddContestMapperConfig()
        {
            CreateMap<Contest, ContestViewModel>().ReverseMap();
            CreateMap<Contest, AddContestViewModel>().ReverseMap();
            CreateMap<Contest, UpdateContestViewModel>().ReverseMap();
        }
    }
}
