using WebAPI.Dtos.Stock;
using WebAPI.Helpers;
using WebAPI.Models;

namespace WebAPI.Interfaces;

public interface IStockRepository
{
    Task<List<Stock>> GetAllAsync(GetAllStocksQuery GetAllStocksQuery);
    Task<Stock?> GetByIdAsync(int id); //FirstOrDefault can be null.
    Task<Stock> CreateAsync(Stock stockModel);
    Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stockDto);
    Task<Stock?> DeleteAsync(int id);
    Task<bool> StockExists(int id);
}