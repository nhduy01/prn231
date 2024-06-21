using Application.BaseModels;
using Application.SendModels.Post;
using Infracstructures.ViewModels.PostViewModels;

namespace Application.IService;

public interface IPostService
{
    public Task<bool> CreatePost(PostRequest Post);
    public Task<(List<PostViewModel>, int)> GetListPost(ListModels listModels);
    public Task<PostViewModel?> GetPostById(Guid id);
    public Task<bool> UpdatePost(PostUpdateRequest updatePost);
    public Task<bool> DeletePost(Guid id);
}