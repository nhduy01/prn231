using System.Net.Mime;
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
    
    public async Task<Guid?> CreatePost(PostRequest post)
    {
        var newPost = _mapper.Map<Post>(post);
        var newImages = _mapper.Map<List<Image>>(post.Images);
        newPost.Images = newImages;
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
        list = (List<Post>)list.Where(x => x.Status == "ACTIVE").OrderByDescending(x=>x.CreatedTime);

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

    #region Get 10 Post

    public async Task<(List<PostViewModel>, int)> GetList10Post(ListModels listModels)
    {
        var list = await _unitOfWork.PostRepo.GetAllAsync();
        list = (List<Post>)list.Where(x => x.Status == "ACTIVE").OrderByDescending(x => x.CreatedTime).Take(10);

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
        var post = await _unitOfWork.PostRepo.GetByIdAsync(updatePost.Id);
        if (post == null) return null;
        _mapper.Map(updatePost, post);

        if (updatePost.NewImages != null)
        {
            var newImages = _mapper.Map<List<Image>>(updatePost.NewImages);
            foreach (var image in newImages)
            {
                post.Images.Add(image);
            }
        }
        if (updatePost.DeleteImages != null)
        {
            foreach (var image in updatePost.DeleteImages)
            {
                post.Images.FirstOrDefault(img => img.Id == image)!.Status = ImageStatus.INACTIVE.ToString();
            }
        }
        
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<PostViewModel>(post);
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