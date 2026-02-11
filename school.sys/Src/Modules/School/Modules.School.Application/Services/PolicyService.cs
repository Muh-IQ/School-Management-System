using Modules.School.Application.IServices;
using Modules.School.Domain.Common.Results;
using Modules.School.Domain.Entities;
using Modules.School.Domain.IRepositories;

namespace Modules.School.Application.Services
{
    public class PolicyService : IPolicyService
    {
        private readonly IGenericRepository<Policy> _Repository;

        public PolicyService(IGenericRepository<Policy> repository)
        {
            _Repository = repository;
        }
        public async Task<Result> CreateAsync(Policy policy)
        {
            var exist = await _Repository.AnyAsync(s => s.Title == policy.Title);

            if (exist)
            {
                return Result.Failure(ErrorType.Conflict, "Policy Is Already Exists.");
            }

            var added = await _Repository.AddAsync(policy);

            if (!added)
            {
                return Result.Failure(ErrorType.InternalServerError, "Faild To Create Policy.");
            }

            return Result.Success();
        }

        public async Task<Result> GetByIdAsync(Guid Id)
        {
            var policy = await _Repository.GetByIdAsync(Id);

            if (policy == null)
            {
                return Result<Policy>.Failure(ErrorType.NotFound, "Policy Not Found.");
            }

            return Result.Success();
        }
        public async Task<Result<IEnumerable<Policy>>> GetAllAsync()
        {
            var policy = await _Repository.GetAllAsync();

            if (policy == null)
            {
                return Result<IEnumerable<Policy>>.Failure(ErrorType.NotFound, "Policy Not Found.");
            }

            return Result<IEnumerable<Policy>>.Success(policy);
        }

        public async Task<Result<IEnumerable<Policy>>> GetAllAsync(int pageing = 1, int pageSize = 10)
        {
            var policy = await _Repository.GetAllAsync(pageing, pageSize);

            if (policy == null)
            {
                return Result<IEnumerable<Policy>>.Failure(ErrorType.NotFound, "Policy Not Found");
            }

            return Result<IEnumerable<Policy>>.Success(policy);
        }

        public async Task<Result> UpdateAsync(Policy policy)
        {
            var exist = await _Repository.AnyAsync(s => s.Id == policy.Id);

            if (!exist)
            {
                return Result.Failure(ErrorType.NotFound, $"Policy With ID {policy.Id} Not Found.");
            }

            var updated = await _Repository.UpdateAsync(policy);

            if (!updated)
            {
                return Result.Failure(ErrorType.InternalServerError, "Updated Failed.");
            }

            return Result.Success();

        }

        public async Task<Result> DeleteAsync(Guid id)
        {
            var policy = await _Repository.GetByIdAsync(id);

            if (policy == null)
            {
                return Result.Failure(ErrorType.NotFound, $"Policy With ID ;{id} Not Found");
            }
            var delete = await _Repository.DeleteAsync(policy);

            if (!delete)
            {
                return Result.Failure(ErrorType.InternalServerError, "Delete Failed.");
            }
            return Result.Success();
        }

    }
}
