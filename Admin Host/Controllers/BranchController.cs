using Application.DTOs;
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
        public async Task<Branch> createBranch(BranchCreateDto model) 
        {
            var entity = await _branchService.CreateBranch(model);
            return entity;
        }

        [HttpGet("{id}")]
        public async Task<BranchReadDto> GetBranch(string id)
        {
            return await _branchService.GetBranch(id);
        }
    }
}
