using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Mappers;
using WebAPI.Dtos.Stock;
using WebAPI.Helpers;
using WebAPI.Interfaces;

namespace WebAPI.Controllers;

[Route("stocks")]
[ApiController]
public class StockController : ControllerBase
{
    private readonly IStockRepository _stockRepo;
    public StockController(IStockRepository stockRepo)
    {
        _stockRepo = stockRepo;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] GetAllStocksQuery GetAllStocksQuery)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState); 
        
        var stocks = await _stockRepo.GetAllAsync(GetAllStocksQuery);
        var stockDto = stocks.Select(s => s.ToStockDto());
        
        return Ok(stocks);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var stock = await _stockRepo.GetByIdAsync(id);

        if (stock == null)
            return NotFound();

        return Ok(stock);
    }

    // Creates new record in the database table
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateStockRequestDto stockDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var stockModel = stockDto.ToStockFromCreateDTO();
        await _stockRepo.CreateAsync(stockModel); 

        return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel.ToStockDto());
    }

    // Updates an existing record in the database
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        // EF Core starts tracking it from here!
        var stockModel = await _stockRepo.UpdateAsync(id, updateDto);

        if (stockModel == null)
            return NotFound();

        return Ok(stockModel.ToStockDto());
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var stockModel = await _stockRepo.DeleteAsync(id);
        
        if (stockModel == null)
            return NotFound();
        
        return NoContent();
    }
}