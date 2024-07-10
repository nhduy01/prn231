using Application.BaseModels;
using Application.SendModels.Post;
using Infracstructures.ViewModels.PostViewModels;

namespace Application.IService;

public interface IPostService
{
    public Task<bool> CreatePost(PostRequest Post);
    public Task<(List<PostViewModel>, int)> GetListPost(ListModels listModels);
    public Task<List<PostViewModel>> Get10Post();
    public Task<PostViewModel?> GetPostById(Guid id);
    public Task<bool> UpdatePost(PostUpdateRequest updatePost);
    public Task<bool> DeletePost(Guid id);
    Task<(List<PostViewModel>, int)> GetPosByStaffId(ListModels listModels, Guid staffId);
    Task<(List<PostViewModel>, int)> ListPostByCategoryId(ListModels listPostModel, Guid categoryId);

    Task<(List<PostViewModel>, int)> SearchByTitleDescription(ListModels listModels, string searchString);
}