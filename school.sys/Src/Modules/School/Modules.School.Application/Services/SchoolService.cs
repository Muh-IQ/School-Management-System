using Modules.School.Domain.IRepositories;
using Modules.School.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Modules.School.Application.Common.Results;
using Modules.School.Domain.DTOs;
using Modules.School.Application.IServices;

namespace Modules.School.Application.Services
{
    public class SchoolService : ISchoolService
    {
        private readonly IGenericRepository<Domain.Entities.School> _Repository;

        public SchoolService(IGenericRepository<Domain.Entities.School> repository)
        {
            _Repository = repository; 
        }

        public async Task<Result>CreateAsync(Domain.Entities.School school)
        {
            var exist = await _Repository.AnyAsync(s => s.Name == school.Name);

            if (exist)
            {
                return Result.Failure(ErrorType.Conflict, "School Is Already Exists.");
            }

            var added = await _Repository.AddAsync(school);

            if (!added)
            {
                return Result.Failure(ErrorType.InternalServerError, "Faild To Create School.");
            }

            return Result.Success();
        }


        public async Task<Result>GetByIdAsync(Guid Id)
        {  
            var school=await _Repository.GetByIdAsync(Id);
            
            if(school == null)
            {
                return Result.Failure(ErrorType.NotFound, "School Not Found.");
            }
            
            return Result.Success();
        }

        public async Task<Result<IEnumerable<Domain.Entities.School>>> GetAllAsync()
        {
            var School = await _Repository.GetAllAsync();
            if(School == null)
            {
                return Result<IEnumerable<Domain.Entities.School>>.Failure(ErrorType.NotFound, "Schools Not Found.");
            }
             return Result<IEnumerable<Domain.Entities.School>>.Success(School);           
        }
        
        public async Task<Result<IEnumerable<Domain.Entities.School>>>GetAllAsync(int pageing=1,int pageSize = 10)
        {
            var School = await _Repository.GetAllAsync(pageing,pageSize);
            if (School == null)
            {
                return Result<IEnumerable<Domain.Entities.School>>.Failure(ErrorType.NotFound, "Schools Not Found");
            }
            return Result<IEnumerable<Domain.Entities.School>>.Success(School);
        }

        public async Task<Result> UpdateAsync(Domain.Entities.School school)
        {
            var exist=await _Repository.AnyAsync(s => s.Id == school.Id);

            if (!exist)
            {
                return Result.Failure(ErrorType.NotFound, $"School With ID {school.Id} Not Found.");
            }

            var updated= await _Repository.UpdateAsync(school);
            
            if (!updated)
            {
                return Result.Failure(ErrorType.InternalServerError, "Updated Failed.");
            }

            return Result.Success();

        }

        public async Task<Result> DeleteAsync(Guid id)
        {
            var school = await _Repository.GetByIdAsync(id);

            if (school == null)
            {
                return Result.Failure(ErrorType.NotFound, $"School With ID ;{id} Not Found");
            }
            var delete = await _Repository.DeleteAsync(school);

            if (!delete)
            {
                return Result.Failure(ErrorType.InternalServerError, "Delete Failed.");
            }
            return Result.Success();
        }       
    }
}
