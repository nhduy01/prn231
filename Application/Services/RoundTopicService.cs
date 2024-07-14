using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.IService;
using Application.SendModels.RoundTopic;
using Application.SendModels.Topic;
using AutoMapper;
using Domain.Enums;
using Domain.Models;
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

        #region Add Topic To Round

        public async Task<bool> AddTopicToRound(RoundTopicRequest roundTopicRequest)
        {
            var listRoundTopic = new List<RoundTopic>();
            foreach(var topic in roundTopicRequest.ListTopicId)
            {
                var roundtopic = new RoundTopic();
                roundtopic.TopicId = topic;
                roundtopic.RoundId= roundTopicRequest.RoundId;
                listRoundTopic.Add(roundtopic);
            }
            await _unitOfWork.RoundTopicRepo.AddRangeAsync(listRoundTopic);

            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        #endregion

        #region Delete Topic In Round

        public async Task<bool> DeleteTopicInRound(Guid id)
        {
            var roundtopic = await _unitOfWork.RoundTopicRepo.GetByIdAsync(id);
            if (roundtopic == null) throw new Exception("Khong tim thay RoundTopic");
            await _unitOfWork.RoundTopicRepo.DeleteAsync(roundtopic);

            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        #endregion
    }
}
