using System.Collections.Generic;
using System.Threading.Tasks;

namespace BarberiaJK.Application.Core

//IBASE SERVICE 
{
    public interface IBaseService<TDto>
    {
        Task<IEnumerable<TDto>> GetAllAsync();
        Task<TDto?> GetByIdAsync(int id);   
        Task<ServiceResult> AddAsync(TDto dto);
        Task<ServiceResult> UpdateAsync(TDto dto);
        Task<ServiceResult> DeleteAsync(int id);
    }
}
