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
        private readonly IRepository<Schools> _Repository;

        public SchoolService(IRepository<Schools> repository)
        {
            _Repository = repository; 
        }

        public async Task<Result<Schools>>CreateAsync(Schools school)
        {
            if (school == null)
            {
                return Result<Schools>.Failure(ErrorType.BadRequest, "School is Required.");
            }

            var result=Result<Schools>.Success(school);

            if (string.IsNullOrWhiteSpace(school.Name))
            {
                return result.WithError(ErrorType.Validation, "School Name is Reqierd.");         
            }

            if (school.ContactInfo == null)
            {
                return result.WithError(ErrorType.Validation, "Contact Info Reqiered."); 
            }
            
            else
            {
                if (string.IsNullOrWhiteSpace(school.ContactInfo.Phone))
                {
                    return result.WithError(ErrorType.Validation, "School Phone is Reqierd.");
                }

                if (string.IsNullOrWhiteSpace(school.ContactInfo.Email))
                {
                    return result.WithError(ErrorType.Validation, "School Email is Reqierd.");
                }
            }

            if (!result.IsSuccess)
            {
                return result;
            }

            var exist=(await _Repository.GetAllAsync()).Any(s =>s.Name==school.Name);

            if (exist)
            {
                return Result<Schools>.Failure(ErrorType.Conflict, "School Already Exists.");
            }

            await _Repository.AddAsync(school);
            
            return Result<Schools>.Success(school);
        
        }


        public async Task<Result<Schools>>GetByIdAsync(Guid Id)
        {
            if (Id == Guid.Empty)
            {
                return Result<Schools>.Failure(ErrorType.BadRequest,"Invalid School ID.");
            }
          
            var school=await _Repository.GetByIdAsync(Id);
            
            if(school == null)
            {
                return Result<Schools>.Failure(ErrorType.NotFound, "School Not Found.");
            }
            
            return Result<Schools>.Success(school);
        }

        public async Task<Result<IEnumerable< Schools>>> GetAllAsync()
        {
            var School = await _Repository.GetAllAsync();
            if(School == null)
            {
                return Result<IEnumerable<Schools>>.Failure(ErrorType.NotFound, "Schools Not Found.");
            }
             return Result<IEnumerable<Schools>>.Success(School);           
        }
        
        public async Task<Result<IEnumerable<Schools>>>GetAllAsync(int pageing=1,int pageSize = 10)
        {
            if(pageing <= 0 || pageSize <= 0)
            {
                return Result<IEnumerable<Schools>>.Failure(ErrorType.Validation, "Invalid Paging Values");
            }
            var School = await _Repository.GetAllAsync(pageing,pageSize);
            if (School == null)
            {
                return Result<IEnumerable<Schools>>.Failure(ErrorType.NotFound, "Schools Not Found");
            }
            return Result<IEnumerable<Schools>>.Success(School);
        }

        public async Task<Result<Schools>> UpdateAsync(Schools school)
        {

            if (school == null)
            {
                return Result<Schools>.Failure(ErrorType.BadRequest, "School is Empty.");
            }
            
            if (school.Id == Guid.Empty)
            {
                return Result<Schools>.Failure(ErrorType.NotFound, "Invalid School ID.");
            }

            var oldSchool = await _Repository.GetByIdAsync(school.Id);
            

            if (oldSchool == null)
            {
                return Result<Schools>.Failure(ErrorType.NotFound, $"School With ID :{school.Id} not Found.");
            }

            var result = Result<Schools>.Success(school);


            if (string.IsNullOrWhiteSpace(school.Name))
            {
                return result.WithError(ErrorType.Validation, "School Name Reqiered.");
            }

            if (school.ContactInfo == null)
            {
                return result.WithError(ErrorType.Validation, "Contact Info Reqiered.");
              
            }

            else
            {
                if (string.IsNullOrWhiteSpace(school.ContactInfo.Phone))
                {
                    return result.WithError(ErrorType.Validation, "School Phone Reqiered.");
                }

                if (string.IsNullOrWhiteSpace(school.ContactInfo.Email))
                {
                    return result.WithError(ErrorType.Validation, "School Email Reqiered.");
                }
            }

            if (string.IsNullOrWhiteSpace(school.TimeZone))
            {
                return result.WithError(ErrorType.Validation, "Time Zone Reqiered.");
            }

            if (!result.IsSuccess)
            {
                return result;
            }

            await _Repository.UpdateAsync(school);
            return Result<Schools>.Success(school);

        }

        public async Task<Result<Schools>> DeleteAsync(Schools school)
        {
            if (school == null)
            {
                return Result<Schools>.Failure(ErrorType.BadRequest, "School is Reqiered.");
            }

            var MarkSchool = await _Repository.GetByIdAsync(school.Id);
           
            if (MarkSchool == null)
            {
                return Result<Schools>.Failure(ErrorType.NotFound, "School Not Found.");
            }

            await _Repository.DeleteAsync(MarkSchool);
            return Result<Schools>.Success(MarkSchool);
        }       
    }
}
