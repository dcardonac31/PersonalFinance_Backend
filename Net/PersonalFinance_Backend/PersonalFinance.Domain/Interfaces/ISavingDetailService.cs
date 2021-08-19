using PersonalFinance.Common.Dtos;
using PersonalFinance.Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalFinance.Domain.Interfaces
{
    public interface ISavingDetailService
    {
        Task<SavingDetailDto> GetByIdAsync(int id);
        Task<IEnumerable<SavingDetailDto>> GetAllAsync(int page, int limit, string orderBy, bool ascending = true);
        (bool status, int id) Post(SavingDetailDto entity);
        Task<bool> PutAsync(int id, SavingDetailDto entity);
        Task<bool> DeleteAsync(int id);
        Task<bool> DeleteLogicAsync(DeletedInfo<int> entity);
    }
}
