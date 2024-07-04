using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.SendModels.AccountSendModels;
using Application.SendModels.Authentication;
using Application.SendModels.Post;
using Application.ViewModels.AccountViewModels;
using Application.ViewModels.ReportViewModels;
using AutoMapper;
using Domain.Models;
using Infracstructures.ViewModels.PostViewModels;

namespace Application.Mappers;
public partial class MapperConfigs : Profile
{
    partial void AddReportMapperConfig()
    {
        CreateMap<Report, AddReportViewModel>().ReverseMap()
            .ForMember(x => x.CreatedBy, x => x.MapFrom(x => x.CurrentUserId));
        CreateMap<Report, UpdateReportViewModel>().ReverseMap()
            .ForMember(x => x.UpdatedBy, x => x.MapFrom(x => x.CurrentUserId));
        CreateMap<Report, ReportViewModel>().ReverseMap();
    }
}
