using PersonalFinance.Common.Dtos;
using PersonalFinance.Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalFinance.Domain.Interfaces
{
    public interface IBudgetTypeService
    {
        Task<BudgetTypeDto> GetByIdAsync(int id);
        Task<IEnumerable<BudgetTypeDto>> GetAllAsync(int page, int limit, string orderBy, bool ascending = true);
        (bool status, int id) Post(BudgetTypeDto entity);
        Task<bool> PutAsync(int id, BudgetTypeDto entity);
        Task<bool> DeleteAsync(int id);
        Task<bool> DeleteLogicAsync(DeletedInfo<int> entity);
    }
}
