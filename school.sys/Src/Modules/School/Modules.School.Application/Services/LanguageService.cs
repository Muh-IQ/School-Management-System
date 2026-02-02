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
    public class LanguageService : ILanguageService
    {
        private readonly IRepository<Languages> _Repository;

        public LanguageService(IRepository<Languages> repository)
        {
            _Repository = repository;
        }
        public async Task<Result<Languages>> CreateAsync(Languages language)
        {
            if (language == null)
            {
                return Result<Languages>.Failure(ErrorType.BadRequest, "Language Is Reqiered.");
            }
            
            var result=Result<Languages>.Success(language);

            if (language.Name == null)
            {
                return result.WithError(ErrorType.Validation, "Lanuage Name Is Reqiered.");
            }

            if (language.Code == null)
            {
                return result.WithError(ErrorType.Validation, "Language Code Is reqiered.");
            }

            if (!result.IsSuccess)
            {
                return result;
            }

            var exist = (await _Repository.GetAllAsync()).Any(s => s.Name == language.Name);

            if (exist)
            {
                return Result<Languages>.Failure(ErrorType.Conflict, "Language Already Exists.");
            }     

            await _Repository.AddAsync(language);
            return result;
        }

        public async Task<Result<Languages>> GetByIdAsync(Guid Id)
        {
            if (Id == Guid.Empty)
            {
                return Result<Languages>.Failure(ErrorType.BadRequest, "Invalid Language ID.");
            }

            var lang = await _Repository.GetByIdAsync(Id);

            if (lang == null)
            {
                return Result<Languages>.Failure(ErrorType.NotFound, "Language Not Found.");
            }

            return Result<Languages>.Success(lang);
        }

        public async Task<Result<IEnumerable<Languages>>> GetAllAsync()
        {
            var lang = await _Repository.GetAllAsync();
            
            if (lang == null)
            {
                return Result<IEnumerable<Languages>>.Failure(ErrorType.NotFound, "Schools Not Found.");
            }

            return Result<IEnumerable<Languages>>.Success(lang);
        }

        public async Task<Result<IEnumerable<Languages>>> GetAllAsync(int pageing = 1, int pageSize = 10)
        {
            if (pageing <= 0 || pageSize <= 0)
            {
                return Result<IEnumerable<Languages>>.Failure(ErrorType.Validation, "Invalid Paging Values");
            }
          
            var lang = await _Repository.GetAllAsync(pageing, pageSize);
            
            if (lang == null)
            {
                return Result<IEnumerable<Languages>>.Failure(ErrorType.NotFound, "Language Not Found");
            }
            
            return Result<IEnumerable<Languages>>.Success(lang);
        }

        public async Task<Result<Languages>> UpdateAsync(Languages language)
        {
            if(language == null)
            {
                return Result<Languages>.Failure(ErrorType.BadRequest, "Language Not Found.");
            }

            if (language.Id == Guid.Empty)
            {
                return Result<Languages>.Failure(ErrorType.NotFound, "Invalid Language ID.");
            }

            var oldLang = await _Repository.GetByIdAsync(language.Id);


            if (oldLang == null)
            {
                return Result<Languages>.Failure(ErrorType.NotFound, $"School With ID :{language.Id} not Found.");
            }

            var result = Result<Languages>.Success(language);


            if (string.IsNullOrWhiteSpace(language.Name))
            {
                return result.WithError(ErrorType.Validation, "Language Name Reqiered.");
            }

            if (string.IsNullOrWhiteSpace(language.Code))
            {
                return result.WithError(ErrorType.Validation, "Language Code Reqiered.");
            }

            if (!result.IsSuccess)
            {
                return result;
            }

            await _Repository.UpdateAsync(language);
            return Result<Languages>.Success(language);

        }

        public async Task<Result<Languages>> DeleteAsync(Languages language)
        {
            if (language == null)
            {
                return Result<Languages>.Failure(ErrorType.BadRequest, "Language is Reqiered.");
            }

            var markLang = await _Repository.GetByIdAsync(language.Id);

            if (markLang == null)
            {
                return Result<Languages>.Failure(ErrorType.NotFound, "Language Not Found.");
            }

            await _Repository.DeleteAsync(markLang);
            return Result<Languages>.Success(markLang);
        }
    }
}
