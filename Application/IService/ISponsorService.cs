using Application.BaseModels;
using Application.ViewModels.SponsorViewModels;
using Infracstructures.SendModels.Sponsor;

namespace Application.IService;

public interface ISponsorService
{
    public Task<Guid?> CreateSponsor(SponsorRequest sponsor);
    public Task<(List<SponsorViewModel>, int)> GetListSponsor(ListModels listModels);
    public Task<SponsorViewModel?> GetSponsorById(Guid id);
    public Task<SponsorViewModel?> UpdateSponsor(SponsorUpdateRequest updateSponsor);
    public Task<bool?> DeleteSponsor(Guid id);
}