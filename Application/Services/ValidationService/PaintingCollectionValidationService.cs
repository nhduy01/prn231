﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.IService.IValidationService;
using Infracstructures;

namespace Application.Services.ValidationService
{
    public class PaintingCollectionValidationService : IPaintingCollectionValidationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PaintingCollectionValidationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //Check Id is Exist
        public async Task<bool> IsExistedId(Guid id)
        {
            return await _unitOfWork.PaintingCollectionRepo.IsExistIdAsync(id);
        }
    }
}
