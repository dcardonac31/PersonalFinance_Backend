using PersonalFinance.Common.Dtos;
using PersonalFinance.Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalFinance.Domain.Interfaces
{
    public interface IMonthlyBudgetService
    {
        Task<MonthlyBudgetDto> GetByIdAsync(int id);
        Task<IEnumerable<MonthlyBudgetDto>> GetAllAsync(int page, int limit, string orderBy, bool ascending = true);
        (bool status, int id) Post(MonthlyBudgetDto entity);
        Task<bool> PutAsync(int id, MonthlyBudgetDto entity);
        Task<bool> DeleteAsync(int id);
        Task<bool> DeleteLogicAsync(DeletedInfo<int> entity);
    }
}
