using PersonalFinance.Common.Dtos;
using PersonalFinance.Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalFinance.Domain.Interfaces
{
    public interface ISavingService
    {
        Task<SavingDto> GetByIdAsync(int id);
        Task<IEnumerable<SavingDto>> GetAllAsync(int page, int limit, string orderBy, bool ascending = true);
        (bool status, int id) Post(SavingDto entity);
        Task<bool> PutAsync(int id, SavingDto entity);
        Task<bool> DeleteAsync(int id);
        Task<bool> DeleteLogicAsync(DeletedInfo<int> entity);
    }
}
