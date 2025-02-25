using AutoMapper;
using Blink.Development.Entities.Dtos.Request.Delivery;
using Blink.Development.Entities.Dtos.Response.Delivery;
using Blink.Development.Entities.Entities;
using Blink.Development.Repository.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Blink.Development.Api.Controllers;

public class DeliveryController : CommonController
{
    public DeliveryController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

    [HttpPost("")]
    public async Task<IActionResult> CreateDelivery([FromBody] CreateDeliveryRequestDto request)
    {
        if (!ModelState.IsValid)

            return BadRequest(ModelState);

        var delivery = _mapper.Map<Delivery>(request);

        await _unitOfWork.Deliveries.Create(delivery);
        await _unitOfWork.CompleteAsync();

        return CreatedAtAction(nameof(GetBranch), new { deliveryId = delivery.Id }, delivery);
    }


    [HttpGet("{deliveryId:guid}")]
    public async Task<IActionResult> GetBranch(Guid deliveryId)
    {
        var delivery = await _unitOfWork.Deliveries.GetById(deliveryId);
        if (delivery == null)
        {
            return NotFound("Branch not Found");
        }

        var result = _mapper.Map<CreateDeliveryResponseDto>(delivery);

        return Ok(result);
    }

    [HttpDelete]
    [Route("{deliveryId:guid}")]
    public async Task<IActionResult> DeleteDelivery(Guid deliveryId)
    {
        var department = await _unitOfWork.Deliveries.GetById(deliveryId);
        if (department == null)
        {
            return NotFound("delivery not Found");
        }
        await _unitOfWork.Deliveries.Delete(deliveryId);
        await _unitOfWork.CompleteAsync();
        return NoContent();
    }

}
