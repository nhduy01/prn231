using Application.BaseModels;
using Application.IService;
using Application.SendModels.Post;
using AutoMapper;
using Domain.Enums;
using Domain.Models;
using Infracstructures;
using Infracstructures.SendModels.Image;
using Infracstructures.ViewModels.PostViewModels;

namespace Application.Services;

public class PostService : IPostService
{
        private readonly IMapper _mapper;

    private readonly IUnitOfWork _unitOfWork;
    private readonly IImageService _imageService;

    public PostService(IUnitOfWork unitOfWork, IMapper mapper, IImageService imageService)
    {
        _imageService = imageService;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #region Create

    public async Task<Guid?> CreatePost(PostRequest Post)
    {
        var newPost = _mapper.Map<Post>(Post);
        var image = new ImageRequest();
        foreach (var images in  Post.Image)
        {
            image.Url = images;
            await _imageService.CreateImage(image);
        }
        
        
        
        newPost.Status = PostStatus.ACTIVE.ToString();
        await _unitOfWork.PostRepo.AddAsync(newPost);
        await _unitOfWork.SaveChangesAsync();
        return newPost.Id;
    }

    #endregion

    #region Get All

    public async Task<(List<PostViewModel>, int)> GetListPost(ListModels listModels)
    {
        var list = await _unitOfWork.PostRepo.GetAllAsync();
        list = (List<Post>)list.Where(x => x.Status == "ACTIVE");

        var result = new List<Post>();

        //page division
        var totalPages = (int)Math.Ceiling((double)list.Count / listModels.PageSize);
        int? itemsToSkip = (listModels.PageNumber - 1) * listModels.PageSize;
        result = result.Skip((int)itemsToSkip)
            .Take(listModels.PageSize)
            .ToList();
        return (_mapper.Map<List<PostViewModel>>(result), totalPages);
    }

    #endregion

    #region Get By Id

    public async Task<PostViewModel?> GetPostById(Guid id)
    {
        var Post = await _unitOfWork.PostRepo.GetByIdAsync(id);
        if (Post == null) return null;
        return _mapper.Map<PostViewModel>(Post);
    }

    #endregion

    #region Update

    public async Task<PostViewModel?> UpdatePost(PostUpdateRequest updatePost)
    {
        var Post = await _unitOfWork.PostRepo.GetByIdAsync(updatePost.Id);
        if (Post == null) return null;

        _mapper.Map(updatePost, Post);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<PostViewModel>(Post);
    }

    #endregion

    #region Delete

    public async Task<bool?> DeletePost(Guid id)
    {
        var Post = await _unitOfWork.PostRepo.GetByIdAsync(id);
        if (Post == null) return false;

        Post.Status = "INACTIVE";
        await _unitOfWork.SaveChangesAsync();
        return true;
    }

    #endregion
}