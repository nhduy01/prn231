using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModels.CollectionViewModels;
using AutoMapper;
using Domain.Models;

namespace Application.Mappers
{
    public partial class MapperConfigs : Profile
    {
        partial void AddCollectionMapperConfig()
        {
            CreateMap<Collection,AddCollectionViewModel>().ReverseMap();
            CreateMap<Collection, CollectionViewModel>().ReverseMap();
            CreateMap<Collection, UpdateCollectionViewModel>().ReverseMap();
        }
    }
}
