using Modules.School.Application.IServices;
using Modules.School.Domain.Common.Results;
using Modules.School.Domain.Common.StaticError;
using Modules.School.Domain.Entities;
using Modules.School.Domain.IRepositories;

namespace Modules.School.Application.Services
{
    public class PolicyService : IPolicyService
    {
        private readonly IGenericRepository<Policy> _Repository;
        private readonly ISchoolRepository _SchoolRepository;

        public PolicyService(IGenericRepository<Policy> repository, ISchoolRepository schoolRepository)
        {
            _Repository = repository;
            _SchoolRepository = schoolRepository;
        }
        public async Task<Result> CreateAsync(Policy policy)
        {
            var exist = await _Repository.AnyAsync(s => s.Title == policy.Title);

            if (exist)
            {
                return Result.Failure(ErrorType.Conflict,UserErrors.ConflictMessage());
            }

            var added = await _Repository.AddAsync(policy);

            if (!added)
            {
                return Result.Failure(ErrorType.InternalServerError, UserErrors.InternalServerErrorMessage());
            }
            
            return Result.Success();
        }

        public async Task<Result<Policy>> GetByIdAsync(Guid Id)
        {
            var policy = await _Repository.GetByIdAsync(Id);

            if (policy == null)
            {
                return Result<Policy>.Failure(ErrorType.NotFound, UserErrors.NotFoundMessage());
            }

            return Result<Policy>.Success(policy);
        }
        public async Task<Result<IEnumerable<Policy>>> GetAllAsync()
        {
            var policy = await _Repository.GetAllAsync();

            if (policy == null)
            {
                return Result<IEnumerable<Policy>>.Failure(ErrorType.NotFound, UserErrors.NotFoundMessage());
            }

            return Result<IEnumerable<Policy>>.Success(policy);
        }

        public async Task<Result<IEnumerable<Policy>>> GetPagedAsync(int pageing = 1, int pageSize = 10)
        {
            var policy = await _Repository.GetPagedAsync(pageing, pageSize);

            if (policy == null)
            {
                return Result<IEnumerable<Policy>>.Failure(ErrorType.NotFound, UserErrors.NotFoundMessage());
            }

            return Result<IEnumerable<Policy>>.Success(policy);
        }

        public async Task<Result> UpdateAsync(Policy policy)
        {
            var exist = await _Repository.AnyAsync(s => s.Id == policy.Id);

            if (!exist)
            {
                return Result.Failure(ErrorType.NotFound, UserErrors.NotFoundMessage());
            }

            var updated = await _Repository.UpdateAsync(policy);

            if (!updated)
            {
                return Result.Failure(ErrorType.InternalServerError, UserErrors.InternalServerErrorMessage());
            }

            return Result.Success();

        }

        public async Task<Result> SoftDeleteAsync(Guid Id)
        {
            var Policy = await _Repository.GetByIdAsync(Id);
            if (Policy == null)
                return Result.Failure(ErrorType.NotFound, UserErrors.NotFoundMessage(Id));
            if (Policy.IsDeleted)
                return Result.Failure(ErrorType.Conflict, UserErrors.ConflictMessage());
            if (!Policy.IsActive)
                return Result.Failure(ErrorType.Conflict, UserErrors.ConflictMessage());

            Policy.IsDeleted = true;
            Policy.IsActive = false;

            var updated = await _Repository.UpdateAsync(Policy);
            if (!updated)
                return Result.Failure(ErrorType.InternalServerError, UserErrors.InternalServerErrorMessage());

            return Result.Success();
        }

    }
}
