using Modules.School.Application.Common.Results;
using Modules.School.Application.IServices;
using Modules.School.Domain.Entities;
using Modules.School.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.School.Application.Services
{
    public class PolicyService : IPolicyService
    {
        private readonly IRepository<Policies> _Repository;

        public PolicyService(IRepository<Policies> repository)
        {
            _Repository = repository;
        }
        public async Task<Result<Policies>> CreateAsync(Policies policy)
        {
            if (policy == null)
            {
                return Result<Policies>.Failure(ErrorType.BadRequest,"Policy is Reqiered.");
            }
            
            var result=Result<Policies>.Success(policy);

            if (policy.Title == null)
            {
                return result.WithError(ErrorType.Validation,"Title Reqiered.");
            }
            
            if (policy.Description == null)
            {
                return result.WithError(ErrorType.Validation, "Description Reqiered.");
            }

            if (policy.PloicyType == null)
            {
                return result.WithError(ErrorType.Validation, "Policy Type Reqiered.");
            }

            if (!result.IsSuccess)
            {
                return result;
            }

            var exist = (await _Repository.GetAllAsync()).Any(s => s.Title == policy.Title);

            if (exist)
            {
                return Result<Policies>.Failure(ErrorType.Conflict,"Policy Is Already Exists.");
            }

            await _Repository.AddAsync(policy);
            return Result<Policies>.Success(policy);
        }

        public async Task<Result<Policies>> GetByIdAsync(Guid Id)
        {
            if (Id == Guid.Empty)
            {
                return Result<Policies>.Failure(ErrorType.BadRequest, "Invalid Policy ID.");     
            }
            
            var policy = await _Repository.GetByIdAsync(Id);
            
            if (policy == null)
            {
                return Result<Policies>.Failure(ErrorType.NotFound, "Policy Not Found.");
            }
            
            return Result<Policies>.Success(policy);
        }
        public async Task<Result<IEnumerable<Policies>>> GetAllAsync()
        {
            var policy = await _Repository.GetAllAsync();
            
            if (policy == null)
            {
                return Result<IEnumerable<Policies>>.Failure(ErrorType.NotFound, "Policy Not Found.");
            }
            
            return Result<IEnumerable<Policies>>.Success(policy);
        }

        public async Task<Result<IEnumerable<Policies>>> GetAllAsync(int pageing = 1, int pageSize = 10)
        {
            if (pageing <= 0 || pageSize <= 0)
            {
                return Result<IEnumerable<Policies>>.Failure(ErrorType.Validation, "Invalid Paging Values");
            }
            var policy = await _Repository.GetAllAsync(pageing, pageSize);
            if (policy == null)
            {
                return Result<IEnumerable<Policies>>.Failure(ErrorType.NotFound, "Policy Not Found");
            }
            return Result<IEnumerable<Policies>>.Success(policy);
        }

        public async Task<Result<Policies>> UpdateAsync(Policies policy)
        {
            if (policy == null)
            {
                return Result<Policies>.Failure(ErrorType.NotFound, "Policy Not Found.");
            }
            
            if (policy.Id == Guid.Empty)
            {
                return Result<Policies>.Failure(ErrorType.NotFound, $"Policy ID :{policy.Id} Not Found.");
            }
            
            var oldPolicy=await _Repository.GetByIdAsync(policy.Id);

            if (policy == null)
            {
                return Result<Policies>.Failure(ErrorType.NotFound, "Policy Not Found.");
            }

            var result=Result<Policies>.Success(policy);

            if (string.IsNullOrWhiteSpace(policy.Title))
            {
                return result.WithError(ErrorType.Validation, "Policy Title Is Reqiered.");
            }

            if (string.IsNullOrWhiteSpace(policy.PloicyType))
            {
                return result.WithError(ErrorType.Validation, "Policy Type IS Reqiered.");
            }

            if (string.IsNullOrWhiteSpace(policy.Description))
            {
                return result.WithError(ErrorType.Validation, "Policy Description Is Resqiered.");
            }

            if (!result.IsSuccess)
            {
                return result;
            }

            await _Repository.UpdateAsync(policy);
            return Result<Policies>.Success(policy);
        }

        public async Task<Result<Policies>> DeleteAsync(Policies policy)
        {
            if (policy == null)
            {
                return Result<Policies>.Failure(ErrorType.BadRequest, "Policy is Reqiered.");
            }

            var MarkPolicy = await _Repository.GetByIdAsync(policy.Id);

            if (MarkPolicy == null)
            {
                return Result<Policies>.Failure(ErrorType.NotFound, "Policy Not Found.");
            }

            await _Repository.DeleteAsync(MarkPolicy);
            return Result<Policies>.Success(MarkPolicy);
        }

    }
}
