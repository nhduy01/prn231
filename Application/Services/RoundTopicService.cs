using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.IService;
using AutoMapper;
using Infracstructures;

namespace Application.Services
{
    public class RoundTopicService : IRoundTopicService
    {
        private readonly IMapper _mapper;

        private readonly IUnitOfWork _unitOfWork;

        public RoundTopicService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    }
}
