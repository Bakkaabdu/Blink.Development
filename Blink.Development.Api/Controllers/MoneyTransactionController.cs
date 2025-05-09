﻿using AutoMapper;
using Blink.Development.Entities.Dtos.Request.MoneyTransaction;
using Blink.Development.Entities.Entities;
using Blink.Development.Repository.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Blink.Development.Api.Controllers
{
    public class MoneyTransactionController : CommonController
    {
        public MoneyTransactionController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

        [HttpPost("deliveryTransaction")]
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

        [HttpPost("StoreTransaction")]
        public async Task<IActionResult> StoreTransaction([FromBody] StoreMoneyTrasnactionDto transactionDto)
        {
            if (transactionDto == null)
                return BadRequest("Invalid transaction data.");

            var transaction = _mapper.Map<MoneyTransaction>(transactionDto); // Map DTO to Entity

            try
            {
                await _unitOfWork.MoneyTransactions.HandelStoreTransaction(transaction);
                return Ok(new { message = "Transaction processed successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetTransactions(int page = 1, int pageSize = 10)
        {
            var moneyTransactions = await _unitOfWork.MoneyTransactions.GetAll();
            var totalCount = moneyTransactions.Count();
            var totalPages = (int)Math.Ceiling((decimal)totalCount / pageSize);
            var perPage = moneyTransactions
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return Ok(perPage);
        }



    }
}
