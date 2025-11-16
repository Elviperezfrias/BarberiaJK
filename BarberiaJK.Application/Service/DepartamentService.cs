using BarberiaJK.Application.Contract;
using BarberiaJK.Application.Core;
using BarberiaJK.Application.Dtos.Departament;
using BarberiaJK.Domain.Entities;
using BarberiaJK.Infrastructure.Core;

namespace BarberiaJK.Application.Service
{
    // DEPARTAMENT SERVICE Y HERENCIA DE BASESERVICE
    public class DepartamentService
        : BaseService<Departament, DepartamentDto>, IDepartamentService
    {
        private readonly IBaseRepository<Departament> _repo;

        public DepartamentService(IBaseRepository<Departament> repo)
        {
            _repo = repo;
        }

        public override async Task<IEnumerable<DepartamentDto>> GetAllAsync()
        {
            var entities = await _repo.GetAllAsync();

            return entities.Select(x => new DepartamentDto
            {
                Id = x.Id,
                Name = x.Name
            });
        }

        public override async Task<DepartamentDto?> GetByIdAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null)
                return null;

            return new DepartamentDto
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public override async Task<ServiceResult> AddAsync(DepartamentDto dto)
        {
            var entity = new Departament
            {
                Name = dto.Name
            };

            await _repo.AddAsync(entity);

            return ServiceResult.Ok("Created successfully.");
        }

        public override async Task<ServiceResult> UpdateAsync(DepartamentDto dto)
        {
            var entity = await _repo.GetByIdAsync(dto.Id);
            if (entity == null)
                return ServiceResult.Fail("Not found.");

            entity.Name = dto.Name;

            await _repo.UpdateAsync(entity);

            return ServiceResult.Ok("Updated successfully.");
        }

        public override async Task<ServiceResult> DeleteAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null)
                return ServiceResult.Fail("Not found.");

            await _repo.DeleteAsync(entity);

            return ServiceResult.Ok("Deleted successfully.");
        }

        // Implementación requerida por IDepartamentService
        public Task<ServiceResult> CreateAsync(DepartamentDto dto)
            => AddAsync(dto);
    }
}
