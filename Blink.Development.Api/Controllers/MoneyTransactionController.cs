using AutoMapper;
using Blink.Development.Entities.Dtos.Request.MoneyTransaction;
using Blink.Development.Entities.Entities;
using Blink.Development.Repository.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Blink.Development.Api.Controllers
{
    public class MoneyTransactionController : CommonController
    {
        public MoneyTransactionController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

        [HttpPost]
        public async Task<IActionResult> DeliveryTransaction([FromBody] DeliveryMoneyTrasnactionDto transactionDto)
        {
            if (transactionDto == null)
                return BadRequest("Invalid transaction data.");

            var transaction = _mapper.Map<MoneyTransaction>(transactionDto); // Map DTO to Entity

            try
            {
                await _unitOfWork.MoneyTransactions.HandelDeliveryTransaction(transaction);
                return Ok(new { message = "Transaction processed successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }


    }
}
