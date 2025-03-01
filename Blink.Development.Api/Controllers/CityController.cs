using AutoMapper;
using Blink.Development.Entities.Dtos.Request.City;
using Blink.Development.Entities.Dtos.Response.City;
using Blink.Development.Entities.Entities;
using Blink.Development.Repository.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Blink.Development.Api.Controllers
{
    public class CityController : CommonController
    {
        public CityController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

        [HttpPost("")]
        public async Task<IActionResult> CreateCity([FromBody] CreateCityRequestDto request)
        {
            if (!ModelState.IsValid)

                return BadRequest(ModelState);

            var city = _mapper.Map<City>(request);

            await _unitOfWork.Cities.Create(city);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetCity), new { cityId = city.Id }, city);
        }

        [HttpGet("{cityId:guid}")]
        public async Task<IActionResult> GetCity(Guid cityId)
        {
            var city = await _unitOfWork.Cities.GetById(cityId);
            if (city == null)
            {
                return NotFound("City not Found");
            }

            var result = _mapper.Map<CreateCityResponseDto>(city);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetCities(int page = 1, int pageSize = 10)
        {
            var cities = await _unitOfWork.Cities.GetAll();
            var totalCount = cities.Count();
            var totalPages = (int)Math.Ceiling((decimal)totalCount / pageSize);
            var perPage = cities
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return Ok(perPage);
        }

        [HttpPatch("")]
        public async Task<IActionResult> UpdateCity([FromBody] UpdateCityRequestDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var city = await _unitOfWork.Cities.GetById(request.Id);

            if (city == null)
            {
                return NotFound("City not Found");
            }
            var result = _mapper.Map<City>(request);

            await _unitOfWork.Cities.Update(result);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        [HttpDelete]
        [Route("{cityId:guid}")]
        public async Task<IActionResult> DeleteBranch(Guid cityId)
        {
            var city = await _unitOfWork.Cities.GetById(cityId);
            if (city == null)
            {
                return NotFound("City not Found");
            }
            await _unitOfWork.Cities.Delete(cityId);
            await _unitOfWork.CompleteAsync();
            return NoContent();
        }
    }
}
