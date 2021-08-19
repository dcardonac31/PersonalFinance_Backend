using PersonalFinance.Common.Dtos;
using PersonalFinance.Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalFinance.Domain.Interfaces
{
    public interface IDebtDetailService
    {
        Task<DebtDetailDto> GetByIdAsync(int id);
        Task<IEnumerable<DebtDetailDto>> GetAllAsync(int page, int limit, string orderBy, bool ascending = true);
        (bool status, int id) Post(DebtDetailDto entity);
        Task<bool> PutAsync(int id, DebtDetailDto entity);
        Task<bool> DeleteAsync(int id);
        Task<bool> DeleteLogicAsync(DeletedInfo<int> entity);
    }
}
