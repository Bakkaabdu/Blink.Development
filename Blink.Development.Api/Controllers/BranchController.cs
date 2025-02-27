using AutoMapper;
using Blink.Development.Entities.Dtos.Request.Branch;
using Blink.Development.Entities.Dtos.Response.Branch;
using Blink.Development.Entities.Entities;
using Blink.Development.Repository.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blink.Development.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
    public class BranchController : CommonController
    {

        public BranchController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

        [HttpPost("")]
        public async Task<IActionResult> CreateBranch([FromBody] CreateBranchRequestDto request)
        {
            if (!ModelState.IsValid)

                return BadRequest(ModelState);

            var branch = _mapper.Map<Branch>(request);

            await _unitOfWork.Branchs.Create(branch);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetBranch), new { branchId = branch.Id }, branch);
        }

        [HttpGet("{branchId:guid}")]
        public async Task<IActionResult> GetBranch(Guid branchId)
        {
            var branch = await _unitOfWork.Branchs.GetById(branchId);
            if (branch == null)
            {
                return NotFound("Branch not Found");
            }

            var result = _mapper.Map<CreateBranchResponseDto>(branch);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetBranchs()
        {
            var branchs = await _unitOfWork.Branchs.GetAll();
            return Ok(branchs);
        }

        [HttpPatch("")]
        public async Task<IActionResult> UpdateBranch([FromBody] UpdateBranchRequestDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var branch = await _unitOfWork.Branchs.GetById(request.Id);

            if (branch == null)
            {
                return NotFound("Branch not Found");
            }
            var result = _mapper.Map<Branch>(request);

            await _unitOfWork.Branchs.Update(result);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        [HttpDelete]
        [Route("{branchId:guid}")]
        public async Task<IActionResult> DeleteBranch(Guid branchId)
        {
            var department = await _unitOfWork.Branchs.GetById(branchId);
            if (department == null)
            {
                return NotFound("Branch not Found");
            }
            await _unitOfWork.Branchs.Delete(branchId);
            await _unitOfWork.CompleteAsync();
            return NoContent();
        }

    }
}
