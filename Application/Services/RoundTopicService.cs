using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.IService;
using Application.SendModels.RoundTopic;
using Application.SendModels.Topic;
using Application.ViewModels.TopicViewModels;
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

        public  async Task<List<RoundTopicViewModel>> GetListRoundTopic(GetListRoundTopicRequest request)
        {
            var competitor = await _unitOfWork.AccountRepo.GetByIdAsync(request.AccountId);

            int yearOld = DateTime.Today.Year - competitor.Birthday.Value.Year;

            List<RoundTopic> list = new List<RoundTopic>();
            
            if (2 <= yearOld && yearOld <= 5)
            {
                var contest = await _unitOfWork.ContestRepo.GetContestByIdForRoundTopic(request.ContestId);
                var education = contest!.EducationalLevel.FirstOrDefault(e => e.Level.Equals("Bảng A"));
                var round = education.Round.FirstOrDefault(r => r.Name.Equals("Vòng Sơ Khảo"));
                list = round.RoundTopic.ToList();
            }
            else
            {
                var contest = await _unitOfWork.ContestRepo.GetContestByIdForRoundTopic(request.ContestId);
                var education = contest!.EducationalLevel.FirstOrDefault(e => e.Level.Equals("Bảng B"));
                var round = education.Round.FirstOrDefault(r => r.Name.Equals("Vòng Sơ Khảo"));
                list = round.RoundTopic.ToList();
            }
            
            return _mapper.Map<List<RoundTopicViewModel>>(list);
    }

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

        public async Task<bool> DeleteTopicInRound(RoundTopicDeleteRequest roundTopicDeleteRequest)
        {

            var roundtopic = await _unitOfWork.RoundTopicRepo.GetByRoundIdTopicId(roundTopicDeleteRequest.RoundId, roundTopicDeleteRequest.TopicId);
            if (roundtopic == null) throw new Exception("Khong tim thay RoundTopic");
            await _unitOfWork.RoundTopicRepo.DeleteAsync(roundtopic);

            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        #endregion
    }
}
