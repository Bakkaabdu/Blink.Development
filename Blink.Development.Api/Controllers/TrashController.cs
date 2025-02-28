using AutoMapper;
using Blink.Development.Entities.Dtos.Request.Trash;
using Blink.Development.Entities.Dtos.Response.Trash;
using Blink.Development.Entities.Entities;
using Blink.Development.Repository.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Blink.Development.Api.Controllers
{
    public class TrashController : CommonController
    {
        public TrashController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }


        [HttpPost("")]
        public async Task<IActionResult> CreateTrash([FromBody] CreateTrashRequestDto request)
        {
            if (!ModelState.IsValid)

                return BadRequest(ModelState);

            var trash = _mapper.Map<Trash>(request);

            await _unitOfWork.Trashes.Create(trash);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetTrash), new { trashId = trash.Id }, trash);
        }

        [HttpGet("{trashId:guid}")]
        public async Task<IActionResult> GetTrash(Guid trashId)
        {
            var street = await _unitOfWork.Trashes.GetById(trashId);
            if (street == null)
            {
                return NotFound("Trash not Found");
            }

            var result = _mapper.Map<CreateTrashResponseDto>(street);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetTrashs()
        {
            var trashes = await _unitOfWork.Trashes.GetAll();
            return Ok(trashes);
        }

        [HttpDelete]
        [Route("{trashId:guid}")]
        public async Task<IActionResult> DeleteTrash(Guid trashId)
        {
            var trash = await _unitOfWork.Trashes.GetById(trashId);
            if (trash == null)
            {
                return NotFound("Trash not Found");
            }
            await _unitOfWork.Trashes.Delete(trashId);
            await _unitOfWork.CompleteAsync();
            return NoContent();
        }

    }
}
