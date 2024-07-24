﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.IService.IValidationService;
using Infracstructures;

namespace Application.Services.ValidationService
{
    public class RoundTopicValidationService : IRoundTopicValidationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoundTopicValidationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //Check Id is Exist
        public async Task<bool> IsExistedId(Guid id)
        {
            return await _unitOfWork.RoundTopicRepo.IsExistIdAsync(id);
        }
    }
}
