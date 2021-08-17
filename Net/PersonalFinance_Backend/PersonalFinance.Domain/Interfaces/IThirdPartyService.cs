using PersonalFinance.Common.Dtos;
using PersonalFinance.Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalFinance.Domain.Interfaces
{
    public interface IThirdPartyService
    {
        Task<ThirdPartyDto> GetByIdAsync(int id);
        Task<IEnumerable<ThirdPartyDto>> GetAllAsync(int page, int limit, string orderBy, bool ascending = true);
        (bool status, int id) Post(ThirdPartyDto entity);
        Task<bool> PutAsync(int id, ThirdPartyDto entity);
        Task<bool> DeleteAsync(int id);
        Task<bool> DeleteLogicAsync(DeletedInfo<int> entity);
    }
}
