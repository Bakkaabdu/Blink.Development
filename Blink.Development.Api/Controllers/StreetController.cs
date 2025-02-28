using AutoMapper;
using Blink.Development.Entities.Dtos.Request.Street;
using Blink.Development.Entities.Dtos.Response.Street;
using Blink.Development.Entities.Entities;
using Blink.Development.Repository.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Blink.Development.Api.Controllers
{
    public class StreetController : CommonController
    {
        public StreetController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

        [HttpPost("")]
        public async Task<IActionResult> CreateStreet([FromBody] CreateStreetRequestDto request)
        {
            if (!ModelState.IsValid)

                return BadRequest(ModelState);

            var street = _mapper.Map<Street>(request);

            await _unitOfWork.Streets.Create(street);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetStreet), new { streetId = street.Id }, street);
        }

        [HttpGet("{streetId:guid}")]
        public async Task<IActionResult> GetStreet(Guid streetId)
        {
            var street = await _unitOfWork.Streets.GetById(streetId);
            if (street == null)
            {
                return NotFound("Street not Found");
            }

            var result = _mapper.Map<CreateStreetResponseDto>(street);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetStreets()
        {
            var streets = await _unitOfWork.Streets.GetAll();
            return Ok(streets);
        }

        [HttpDelete]
        [Route("{streetId:guid}")]
        public async Task<IActionResult> DeleteStreet(Guid streetId)
        {
            var street = await _unitOfWork.Streets.GetById(streetId);
            if (street == null)
            {
                return NotFound("Street not Found");
            }
            await _unitOfWork.Missions.Delete(streetId);
            await _unitOfWork.CompleteAsync();
            return NoContent();
        }

    }
}
