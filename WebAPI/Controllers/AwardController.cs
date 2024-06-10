using System.Collections.Generic;
using Application.IService;
using Application.ResponseModels;
using Application.ViewModels.AwardViewModels;
using Domain.Models;
using FluentAssertions.Common;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/award/")]
    public class AwardController : Controller
    {
        private readonly IAwardService _awardService;

        public AwardController(IAwardService awardService)
        {
            _awardService = awardService;
        }
        #region Create 
        [HttpPost()]
        public async Task<IActionResult> CreateAward(AddAwardViewModel award, Guid id)
        {
            try
            {
                var result = await _awardService.AddAward(award,id);
                return Ok(new BaseResponseModel
                {
                    Status = Ok().StatusCode,
                    Message = "Create Award Success",
                    Result = result
                });

            }
            catch (Exception ex)
            {
                return BadRequest(new BaseFailedResponseModel
                {
                    Status = BadRequest().StatusCode,
                    Message = ex.Message,
                    Errors = ex
                });

            }
        }
        #endregion

        #region Update
        [HttpPut()]
        public async Task<IActionResult> UpdateAward(Guid id, UpdateAwardViewModel updateAward)
        {
            var result = await _awardService.UpdateAward(updateAward, id);
            if (result == null) return NotFound();
            else
            {
                return Ok(new BaseResponseModel
                {
                    Status = Ok().StatusCode,
                    Result = result,
                    Message = "Update Successfully"
                });
            }
        }
        #endregion

        #region Delete
        [HttpPatch()]
        public async Task<IActionResult> DeleteStatus(Guid id)
        {
            var result = await _awardService.DeleteAward(id);
            if (result == null) return NotFound();
            else
            {
                return Ok(new BaseResponseModel
                {
                    Status = Ok().StatusCode,
                    Result = result,
                    Message = "Delete Successfully"
                });
            }
        }
        #endregion

        #region GetAll
        [HttpGet()]
        public async Task<IActionResult> GetAllInventory(ListAwardModel listAwardModel)
        {
            try
            {
                var (list, totalPage) = await _awardService.GetListAward(listAwardModel);
                return Ok(new BaseResponseModel
                {
                    Status = Ok().StatusCode,
                    Message = "Get Inventory Success",
                    Result = new
                    {
                        List = list,
                        TotalPage = totalPage
                    }

                });
            }
            catch (Exception ex)
            {
                return BadRequest(new BaseFailedResponseModel
                {
                    Status = BadRequest().StatusCode,
                    Message = ex.Message,
                    Errors = ex
                });
            }
        }
        #endregion


    }
}
