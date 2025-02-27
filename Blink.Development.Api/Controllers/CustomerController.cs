using AutoMapper;
using Blink.Development.Entities.Dtos.Request.Customer;
using Blink.Development.Entities.Dtos.Response.Customer;
using Blink.Development.Entities.Entities;
using Blink.Development.Repository.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Blink.Development.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : CommonController
    {
        public CustomerController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

        [HttpPost("")]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerRequestDto request)
        {
            if (!ModelState.IsValid)

                return BadRequest(ModelState);

            var customer = _mapper.Map<Customer>(request);

            await _unitOfWork.Customers.Create(customer);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetCustomer), new { customerId = customer.Id }, customer);
        }

        [HttpGet("{customerId:guid}")]
        public async Task<IActionResult> GetCustomer(Guid customerId)
        {
            var customer = await _unitOfWork.Branchs.GetById(customerId);
            if (customer == null)
            {
                return NotFound("Customer not Found");
            }

            var result = _mapper.Map<CreateCustomerResponseDto>(customer);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _unitOfWork.Customers.GetAll();
            return Ok(customers);
        }

        [HttpPatch("")]
        public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomerRequestDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var customer = await _unitOfWork.Customers.GetById(request.Id);

            if (customer == null)
            {
                return NotFound("Customer not Found");
            }
            var result = _mapper.Map<Customer>(request);

            await _unitOfWork.Customers.Update(result);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        [HttpDelete]
        [Route("{customerId:guid}")]
        public async Task<IActionResult> DeleteBranch(Guid customerId)
        {
            var customers = await _unitOfWork.Customers.GetById(customerId);
            if (customers == null)
            {
                return NotFound("Customer not Found");
            }
            await _unitOfWork.Customers.Delete(customerId);
            await _unitOfWork.CompleteAsync();
            return NoContent();
        }
    }
}
