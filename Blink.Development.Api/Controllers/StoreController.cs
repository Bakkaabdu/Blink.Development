using AutoMapper;
using Blink.Development.Entities.Dtos.Request.Strore;
using Blink.Development.Entities.Dtos.Response.Store;
using Blink.Development.Entities.Entities;
using Blink.Development.Repository.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Blink.Development.Api.Controllers;

public class StoreController : CommonController
{

    public StoreController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

    [HttpPost("")]
    public async Task<IActionResult> CreateStore([FromBody] CreateStoreRequestDto request)
    {
        if (!ModelState.IsValid)

            return BadRequest(ModelState);

        var store = _mapper.Map<Store>(request);

        await _unitOfWork.Stores.Create(store);
        await _unitOfWork.CompleteAsync();

        return CreatedAtAction(nameof(GetStore), new { storeId = store.Id }, store);
    }

    [HttpGet("{storeId:guid}")]
    public async Task<IActionResult> GetStore(Guid storeId)
    {
        var store = await _unitOfWork.Stores.GetById(storeId);
        if (store == null)
        {
            return NotFound("Store not Found");
        }

        var result = _mapper.Map<CreateStoreResponseDto>(store);

        return Ok(result);
    }

}
