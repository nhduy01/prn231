using System.Net.WebSockets;
using Application.BaseModels;
using Application.IService;
using Application.SendModels.Round;
using Application.ViewModels.EducationalLevelViewModels;
using Application.ViewModels.RoundViewModels;
using Application.ViewModels.TopicViewModels;
using AutoMapper;
using Domain.Enums;
using Domain.Models;
using Infracstructures;

namespace Application.Services;

public class RoundService : IRoundService
{
    private readonly IMapper _mapper;

    private readonly IUnitOfWork _unitOfWork;

    public RoundService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #region Create

    public async Task<bool> CreateRound(RoundRequest Round)
    {
        var newRound = _mapper.Map<Round>(Round);

        newRound.Status = RoundStatus.Active.ToString();
        await _unitOfWork.RoundRepo.AddAsync(newRound);

        var check = await _unitOfWork.SaveChangesAsync() > 0;
        if (check == false) throw new Exception("Tao Round Fail");
        foreach (var id in Round.ListTopic)
        {
            var roundTopic = new RoundTopic();
            roundTopic.RoundId = newRound.Id;
            roundTopic.TopicId = id;
            _unitOfWork.RoundTopicRepo.AddAsync(roundTopic);
        }
        return await _unitOfWork.SaveChangesAsync() > 0;
    }

    #endregion

    #region Get All Round

    public async Task<(List<RoundViewModel>, int)> GetListRound(ListModels listModels)
    {
        var list = await _unitOfWork.RoundRepo.GetAllAsync();
        if (list.Count == 0) throw new Exception("Khong tim thay Round nao");
        //page division
        var totalPages = (int)Math.Ceiling((double)list.Count / listModels.PageSize);
        int? itemsToSkip = (listModels.PageNumber - 1) * listModels.PageSize;
        var result = list.Skip((int)itemsToSkip)
            .Take(listModels.PageSize)
            .ToList();
        return (_mapper.Map<List<RoundViewModel>>(result), totalPages);
    }

    #endregion

    #region Get By Id

    public async Task<RoundViewModel?> GetRoundById(Guid id)
    {
        var Round = await _unitOfWork.RoundRepo.GetByIdAsync(id);
        if (Round == null) throw new Exception("Khong tim thay Round");

        return _mapper.Map<RoundViewModel>(Round);
    }

    #endregion

    #region Update

    public async Task<bool> UpdateRound(RoundUpdateRequest updateRound)
    {
        var Round = await _unitOfWork.RoundRepo.GetByIdAsync(updateRound.Id);
        if (Round == null) throw new Exception("Khong tim thay Round");
        _mapper.Map(updateRound, Round);

        return await _unitOfWork.SaveChangesAsync() > 0;
    }

    #endregion

    #region Delete

    public async Task<bool> DeleteRound(Guid id)
    {
        var Round = await _unitOfWork.RoundRepo.GetByIdAsync(id);
        if (Round == null) throw new Exception("Khong tim thay Round");
        Round.Status = RoundStatus.Inactive.ToString();

        return await _unitOfWork.SaveChangesAsync() > 0;
    }

    #endregion

    #region Get Topic

    public async Task<(List<TopicViewModel>, int)> GetTopicInRound(Guid id, ListModels listModels)
    {
        var list = await _unitOfWork.RoundRepo.GetTopic(id);
        if (list.Count == 0) throw new Exception("Khong tim thay Topic nao trong Round");
        //page division
        var totalPages = (int)Math.Ceiling((double)list.Count / listModels.PageSize);
        int? itemsToSkip = (listModels.PageNumber - 1) * listModels.PageSize;
        var result = list.Skip((int)itemsToSkip)
            .Take(listModels.PageSize)
            .ToList();
        return (_mapper.Map<List<TopicViewModel>>(result), totalPages);
    }
    #endregion

    #region Get Round By Educational LevelId

    public async Task<(List<RoundViewModel>, int)> GetRoundByEducationalLevelId(ListModels listRoundModel, Guid levelId)
    {
        var list = await _unitOfWork.RoundRepo.GetRoundByLevelId(levelId);
        if (list.Count == 0) throw new Exception("Khong tim thay Round nao");
        //page division
        var totalPages = (int)Math.Ceiling((double)list.Count / listRoundModel.PageSize);
        int? itemsToSkip = (listRoundModel.PageNumber - 1) * listRoundModel.PageSize;
        var result = list.Skip((int)itemsToSkip)
            .Take(listRoundModel.PageSize)
            .ToList();
        return (_mapper.Map<List<RoundViewModel>>(result), totalPages);
    }

    #endregion

}