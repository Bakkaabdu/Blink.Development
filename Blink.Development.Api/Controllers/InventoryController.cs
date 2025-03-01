using AutoMapper;
using Blink.Development.Entities.Dtos.Request.Inventory;
using Blink.Development.Entities.Dtos.Response.Inventory;
using Blink.Development.Entities.Entities;
using Blink.Development.Repository.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Blink.Development.Api.Controllers
{
    public class InventoryController : CommonController
    {
        public InventoryController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

        [HttpPost("")]
        public async Task<IActionResult> CreateInventory([FromBody] CreateInventoryRequestDto request)
        {
            if (!ModelState.IsValid)

                return BadRequest(ModelState);

            var branch = _mapper.Map<Inventory>(request);

            await _unitOfWork.Inventories.Create(branch);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetInventory), new { inventoryId = branch.Id }, branch);
        }

        [HttpGet("{inventoryId:guid}")]
        public async Task<IActionResult> GetInventory(Guid inventoryId)
        {
            var inventory = await _unitOfWork.Inventories.GetById(inventoryId);
            if (inventory == null)
            {
                return NotFound("Inventory not Found");
            }

            var result = _mapper.Map<CreateInventoryResponseDto>(inventory);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetInventories(int page = 1, int pageSize = 10)
        {
            var inventories = await _unitOfWork.Inventories.GetAll();
            var totalCount = inventories.Count();
            var totalPages = (int)Math.Ceiling((decimal)totalCount / pageSize);
            var perPage = inventories
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return Ok(perPage);
        }

        [HttpPatch("")]
        public async Task<IActionResult> UpdateInventory([FromBody] UpdateInventoryRequestDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var inventory = await _unitOfWork.Inventories.GetById(request.Id);

            if (inventory == null)
            {
                return NotFound("Inventory not Found");
            }
            var result = _mapper.Map<Inventory>(request);

            await _unitOfWork.Inventories.Update(result);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        [HttpDelete]
        [Route("{inventoryId:guid}")]
        public async Task<IActionResult> DeleteInventory(Guid inventoryId)
        {
            var department = await _unitOfWork.Inventories.GetById(inventoryId);
            if (department == null)
            {
                return NotFound("Inventory not Found");
            }
            await _unitOfWork.Inventories.Delete(inventoryId);
            await _unitOfWork.CompleteAsync();
            return NoContent();
        }
    }
}
