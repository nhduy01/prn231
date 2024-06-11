using System.Collections.Generic;
using Application.IService;
using Application.ResponseModels;
using Application.ViewModels.AwardViewModels;
using Domain.Models;
using FluentAssertions.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace WebAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/award/")]
    public class AwardController : Controller
    {
        private readonly IAwardService _awardService;

        public AwardController(IAwardService awardService)
        {
            _awardService = awardService;
        }
        #region Create Award
        [HttpPost()]
        public async Task<IActionResult> CreateAward(AddAwardViewModel award)
        {
            try
            {
                var result = await _awardService.AddAward(award);
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

        #region Update Award
        [HttpPut()]
        public async Task<IActionResult> UpdateAward(UpdateAwardViewModel updateAward)
        {
            var result = await _awardService.UpdateAward(updateAward);
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

        #region Delete Award
        [HttpPatch()]
        public async Task<IActionResult> DeleteAward(Guid id)
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

        #region Get All Award
        [HttpGet()]
        public async Task<IActionResult> GetAllAward(ListAwardModel listAwardModel)
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

        #region Get Award By Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAwardById(Guid id)
        {
            try
            {
                var result = await _awardService.GetAwardById(id);
                return Ok(new BaseResponseModel
                {
                    Status = Ok().StatusCode,
                    Message = "Get Inventory Success",
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

    }
}
