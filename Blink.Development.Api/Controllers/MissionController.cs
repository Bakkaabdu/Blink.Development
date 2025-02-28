using AutoMapper;
using Blink.Development.Entities;
using Blink.Development.Entities.Dtos.Request.Mission;
using Blink.Development.Entities.Dtos.Response.Street;
using Blink.Development.Repository.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Blink.Development.Api.Controllers
{
    public class MissionController : CommonController
    {
        public MissionController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

        [HttpPost("")]
        public async Task<IActionResult> CreateMission([FromBody] CreateMissionRequestDto request)
        {
            if (!ModelState.IsValid)

                return BadRequest(ModelState);

            var mission = _mapper.Map<Mission>(request);

            await _unitOfWork.Missions.Create(mission);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetMission), new { missionId = mission.Id }, mission);
        }

        [HttpGet("{missionId:guid}")]
        public async Task<IActionResult> GetMission(Guid missionId)
        {
            var mission = await _unitOfWork.Missions.GetById(missionId);
            if (mission == null)
            {
                return NotFound("Mission not Found");
            }

            var result = _mapper.Map<CreateStreetResponseDto>(mission);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetMissions()
        {
            var missions = await _unitOfWork.Missions.GetAll();
            return Ok(missions);
        }

        [HttpDelete]
        [Route("{missionId:guid}")]
        public async Task<IActionResult> DeleteMission(Guid missionId)
        {
            var mission = await _unitOfWork.Missions.GetById(missionId);
            if (mission == null)
            {
                return NotFound("Mission not Found");
            }
            await _unitOfWork.Missions.Delete(missionId);
            await _unitOfWork.CompleteAsync();
            return NoContent();
        }
    }
}
