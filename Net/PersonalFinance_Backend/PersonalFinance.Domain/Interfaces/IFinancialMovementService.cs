using PersonalFinance.Common.Dtos;
using PersonalFinance.Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalFinance.Domain.Interfaces
{
    public interface IFinancialMovementService
    {
        Task<FinancialMovementDto> GetByIdAsync(int id);
        Task<IEnumerable<FinancialMovementDto>> GetAllAsync(int page, int limit, string orderBy, bool ascending = true);
        (bool status, int id) Post(FinancialMovementDto entity);
        Task<bool> PutAsync(int id, FinancialMovementDto entity);
        Task<bool> DeleteAsync(int id);
        Task<bool> DeleteLogicAsync(DeletedInfo<int> entity);
    }
}
