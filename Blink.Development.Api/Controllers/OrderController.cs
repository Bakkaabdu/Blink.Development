using AutoMapper;
using Blink.Development.Entities.Dtos.Request.Order;
using Blink.Development.Entities.Dtos.Response;
using Blink.Development.Entities.Entities;
using Blink.Development.Repository.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Blink.Development.Api.Controllers
{
    public class OrderController : CommonController
    {
        public OrderController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequestDto request)
        {
            if (!ModelState.IsValid)

                return BadRequest(ModelState);

            var order = _mapper.Map<Order>(request);

            await _unitOfWork.Orders.Create(order);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetOrder), new { orderId = order.Id }, order);
        }

        [HttpGet("{orderId:guid}")]
        public async Task<IActionResult> GetOrder(Guid orderId)
        {
            var order = await _unitOfWork.Orders.GetById(orderId);
            if (order == null)
            {
                return NotFound("Order not Found");
            }

            var result = _mapper.Map<CreateOrderResponseDto>(order);

            return Ok(result);
        }

        [HttpPatch("UpdateOrder")]
        public async Task<IActionResult> UpdateOrder([FromBody] UpdateOrderRequestDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var order = await _unitOfWork.Orders.GetById(request.Id.Value);

            if (order == null)
            {
                return NotFound("Order not Found");
            }
            var result = _mapper.Map<Order>(request);

            await _unitOfWork.Orders.Update(result);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }
        [HttpGet("GetOrders")]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _unitOfWork.Orders.GetAll();
            return Ok(orders);
        }
        [HttpDelete]
        [Route("{orderId:guid}")]
        public async Task<IActionResult> DeleteOrder(Guid orderId)
        {
            var order = await _unitOfWork.Orders.GetById(orderId);
            if (order == null)
            {
                return NotFound("Order not Found");
            }
            await _unitOfWork.Orders.Delete(orderId);
            await _unitOfWork.CompleteAsync();
            return NoContent();
        }

    }
}
