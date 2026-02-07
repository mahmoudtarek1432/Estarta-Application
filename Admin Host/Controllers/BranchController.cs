using Admin_Host.Model.Base;
using Application.DTOs.BranchDtos;
using Application.Service.Abstraction;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Admin_Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranchService _branchService;

        public BranchController(IBranchService branchService)
        {
            _branchService = branchService;
        }

        [HttpPost]
        public async Task<ResponseBase<BranchReadDto>> createBranch(BranchCreateDto model) 
        {
            var resModel = await _branchService.CreateBranch(model);
            return ResponseBase<BranchReadDto>.Success(resModel);
        }

        [HttpPatch]
        public async Task<ResponseBase<BranchReadDto>> UpdateBranch(BranchUpdateDto model)
        {
            var resModel = await _branchService.UpdateBranch(model);
            return ResponseBase<BranchReadDto>.Success(resModel);
        }

        [HttpGet("{id}")]
        public async Task<ResponseBase<BranchReadDto>> GetBranch(string id)
        {
            var resModel = await _branchService.GetBranch(id);

            return ResponseBase<BranchReadDto>.Success(resModel);
        }

        [HttpGet("merchant/{merchantId}")]
        public async Task<ResponseBase<IEnumerable<BranchReadDto>>> GetMerchantBranches(string merchantId)
        {
            var resModel = await _branchService.GetMerchantBranches(merchantId);
            return ResponseBase<IEnumerable<BranchReadDto>>.Success(resModel);
        }
    }
}
