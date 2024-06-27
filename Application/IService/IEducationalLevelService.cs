using Application.BaseModels;
using Application.SendModels.EducationalLevel;
using Application.ViewModels.EducationalLevelViewModels;

namespace Application.IService;

public interface IEducationalLevelService
{
    Task<bool> CreateEducationalLevel(EducationalLevelRequest EducationalLevel);
    Task<(List<EducationalLevelViewModel>, int)> GetListEducationalLevel(ListModels listModels);
    Task<EducationalLevelViewModel?> GetEducationalLevelById(Guid id);
    Task<bool> UpdateEducationalLevel(EducationalLevelUpdateRequest updateEducationalLevel);
    Task<bool> DeleteEducationalLevel(Guid id);
}