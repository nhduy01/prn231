using Application.BaseModels;
using Application.IService;
using Application.SendModels.Post;
using AutoMapper;
using Domain.Enums;
using Domain.Models;
using Infracstructures;
using Infracstructures.ViewModels.PostViewModels;

namespace Application.Services;

public class PostService : IPostService
{
    private readonly IImageService _imageService;
    private readonly IMapper _mapper;

    private readonly IUnitOfWork _unitOfWork;

    public PostService(IUnitOfWork unitOfWork, IMapper mapper, IImageService imageService)
    {
        _imageService = imageService;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    #region Create

    public async Task<bool> CreatePost(PostRequest post)
    {
        var newPost = _mapper.Map<Post>(post);
        var newImages = _mapper.Map<List<Image>>(post.Images);
        newPost.Images = newImages;
        newPost.Status = PostStatus.Active.ToString();
        await _unitOfWork.PostRepo.AddAsync(newPost);
        var category = await _unitOfWork.CategoryRepo.GetByIdAsync(post.CategoryId);
        category.Status = CategoryStatus.Used.ToString();
        return await _unitOfWork.SaveChangesAsync() > 0;
    }

    #endregion

    #region Get All

    public async Task<(List<PostViewModel>, int)> GetListPost(ListModels listModels)
    {
        var list = await _unitOfWork.PostRepo.GetAllAsync();
        if (list.Count == 0) throw new Exception("Khong tim thay Post nao");

        //page division
        var totalPages = (int)Math.Ceiling((double)list.Count / listModels.PageSize);
        int? itemsToSkip = (listModels.PageNumber - 1) * listModels.PageSize;
        var result = list.Skip((int)itemsToSkip)
            .Take(listModels.PageSize)
            .ToList();
        return (_mapper.Map<List<PostViewModel>>(result), totalPages);
    }
    #endregion

    #region Get 10 Post
    public async Task<List<PostViewModel>> Get10Post()
    {
        var list = await _unitOfWork.PostRepo.Get10Post();
        if (list.Count == 0) throw new Exception("Khong tim thay Post nao");
        return _mapper.Map<List<PostViewModel>>(list);
    }

    #endregion

    #region Get By Id

    public async Task<PostViewModel?> GetPostById(Guid id)
    {
        var Post = await _unitOfWork.PostRepo.GetByIdAsync(id);
        if (Post == null) throw new Exception("Khong tim thay Post");
        return _mapper.Map<PostViewModel>(Post);
    }

    #endregion

    #region Get By Staff Id

    public async Task<(List<PostViewModel>, int)> GetPosByStaffId(ListModels listModels, Guid staffId)
    {
        var staff = await _unitOfWork.AccountRepo.GetByIdAsync(staffId);
        if (staff == null) throw new Exception("Khong tim thay Staff");

        var list = await _unitOfWork.PostRepo.GetPostByStaffId(staffId);
        if (list.Count == 0) throw new Exception("Khong tim thay Post nao");
        //page division
        var totalPages = (int)Math.Ceiling((double)list.Count / listModels.PageSize);
        int? itemsToSkip = (listModels.PageNumber - 1) * listModels.PageSize;
        var result = list.Skip((int)itemsToSkip)
            .Take(listModels.PageSize)
            .ToList();
        return (_mapper.Map<List<PostViewModel>>(result), totalPages);
    }

    #endregion

    #region List Post By Category Id

    public async Task<(List<PostViewModel>, int)> ListPostByCategoryId(ListModels listPostModel, Guid categoryId)
    {
        var category = await _unitOfWork.CategoryRepo.GetByIdAsync(categoryId);
        if (category == null) throw new Exception("Khong tim thay Category");

        var listPost = await _unitOfWork.PostRepo.GetPostByCategory(categoryId);
        if (listPost.Count == 0) throw new Exception("Khong co Post nao trong Category");

        var result = _mapper.Map<List<PostViewModel>>(listPost);

        #region pagination
        var totalPages = (int)Math.Ceiling((double)result.Count / listPostModel.PageSize);
        int? itemsToSkip = (listPostModel.PageNumber - 1) * listPostModel.PageSize;
        result = result.Skip((int)itemsToSkip)
            .Take(listPostModel.PageSize)
            .ToList();
        #endregion

        return (result, totalPages);
    }

    #endregion

    #region Update

    public async Task<bool> UpdatePost(PostUpdateRequest updatePost)
    {
        var post = await _unitOfWork.PostRepo.GetByIdAsync(updatePost.Id);
        if (post == null) throw new Exception("Khong tim thay Post");
        _mapper.Map(updatePost, post);

        if (updatePost.NewImages != null)
        {
            var newImages = _mapper.Map<List<Image>>(updatePost.NewImages);
            foreach (var image in newImages) post.Images.Add(image);
        }

        if (updatePost.DeleteImages != null)
            foreach (var image in updatePost.DeleteImages)
            {
                var deleteImage = post.Images.FirstOrDefault(x => x.Id == image);
                post.Images.Remove(deleteImage);
            }


        return await _unitOfWork.SaveChangesAsync() > 0;
    }

    #endregion

    #region Delete

    public async Task<bool> DeletePost(Guid id)
    {
        var Post = await _unitOfWork.PostRepo.GetByIdAsync(id);
        if (Post == null) throw new Exception("Khong tim thay Post");

        Post.Status = PostStatus.Inactive.ToString();

        return await _unitOfWork.SaveChangesAsync() > 0;
    }

    #endregion

    #region Search By Title Description

    public async Task<(List<PostViewModel>, int)> SearchByTitleDescription(ListModels listModels, string searchString)
    {
        var list = await _unitOfWork.PostRepo.SearchTitleDescription(searchString);
        if (list.Count == 0) throw new Exception("Khong tim thay Post nao");
        //page division
        var totalPages = (int)Math.Ceiling((double)list.Count / listModels.PageSize);
        int? itemsToSkip = (listModels.PageNumber - 1) * listModels.PageSize;
        var result = list.Skip((int)itemsToSkip)
            .Take(listModels.PageSize)
            .ToList();
        return (_mapper.Map<List<PostViewModel>>(result), totalPages);
    }
    #endregion

}