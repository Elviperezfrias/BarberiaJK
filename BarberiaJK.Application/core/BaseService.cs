using System.Collections.Generic;
using System.Threading.Tasks;


//CORE SERVICE
namespace BarberiaJK.Application.Core
{
    public abstract class BaseService<TEntity, TDto> : IBaseService<TDto>
    {
        public abstract Task<IEnumerable<TDto>> GetAllAsync();

        public abstract Task<TDto?> GetByIdAsync(int id); 


        public abstract Task<ServiceResult> AddAsync(TDto dto);



        public abstract Task<ServiceResult> UpdateAsync(TDto dto);



        public abstract Task<ServiceResult> DeleteAsync(int id);
    }
}
