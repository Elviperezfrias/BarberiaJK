using BarberiaJK.Application.Core;
using BarberiaJK.Application.Dtos;
using BarberiaJK.Application.Dtos.Departament;
using System.Collections.Generic;
using System.Threading.Tasks;


// DEPARTAMENT SERVICE 
namespace BarberiaJK.Application.Contract
{
    public interface IDepartamentService
    {
        Task<IEnumerable<DepartamentDto>> GetAllAsync();
        Task<DepartamentDto?> GetByIdAsync(int id);
        Task<ServiceResult> CreateAsync(DepartamentDto dto);
        Task<ServiceResult> UpdateAsync(DepartamentDto dto);
        Task<ServiceResult> DeleteAsync(int id);
    }
}
