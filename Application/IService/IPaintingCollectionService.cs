﻿using Application.SendModels.PaintingCollection;
using FluentValidation.Results;

namespace Application.IService;

public interface IPaintingCollectionService
{
    Task<bool> AddPaintingToCollection(PaintingCollectionRequest addPaintingCollectionViewModel);

    Task<bool> DeletePaintingInCollection(Guid paintingcollectionId);
    Task<bool> IsExistedId(Guid id);
    Task<ValidationResult> ValidatePaintingCollectionRequest(PaintingCollectionRequest paintingcollection);
}