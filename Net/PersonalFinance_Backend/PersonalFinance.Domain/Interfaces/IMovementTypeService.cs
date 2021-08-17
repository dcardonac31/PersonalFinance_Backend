using PersonalFinance.Common.Dtos;
using PersonalFinance.Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalFinance.Domain.Interfaces
{
    public interface IMovementTypeService
    {
        Task<MovementTypeDto> GetByIdAsync(int id);
        Task<IEnumerable<MovementTypeDto>> GetAllAsync(int page, int limit, string orderBy, bool ascending = true);
        (bool status, int id) Post(MovementTypeDto entity);
        Task<bool> PutAsync(int id, MovementTypeDto entity);
        Task<bool> DeleteAsync(int id);
        Task<bool> DeleteLogicAsync(DeletedInfo<int> entity);
    }
}
