﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.IService.ICommonService;
using Application.IService.IValidationService;
using AutoMapper;
using Infracstructures;
using Microsoft.Extensions.Configuration;

namespace Application.Services.ValidationService
{
    public class AccountValidationService : IAccountValidationService 
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountValidationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //Check Id is Exist
        public async Task<bool> IsExistedId(Guid id)
        {
            return await _unitOfWork.AccountRepo.IsExistIdAsync(id);
        }
    }
}
