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
        private readonly IRepository<Language> _Repository;

        public LanguageService(IRepository<Language> repository)
        {
            _Repository = repository;
        }
        public async Task<Result> CreateAsync(Language language)
        {
            var exist = await _Repository.AnyAsync(s => s.Name == language.Name);
            
            if (exist)
            {
                return Result.Failure(ErrorType.Conflict, "Language Already Exists.");
            }               
            
            var added= await _Repository.AddAsync(language);

            if (!added)
            {
                return Result.Failure(ErrorType.InternalServerError, "Faild To Create Language.");
            }

            return Result.Success();
        }

        public async Task<Result> GetByIdAsync(Guid Id)
        {
            var lang = await _Repository.GetByIdAsync(Id);

            if (lang == null)
            {
                return Result.Failure(ErrorType.NotFound, "Language Not Found.");
            }

            return Result.Success();
        }

        public async Task<Result<IEnumerable<Language>>> GetAllAsync()
        {
            var lang = await _Repository.GetAllAsync();
            
            if (lang == null)
            {
                return Result<IEnumerable<Language>>.Failure(ErrorType.NotFound, "Schools Not Found.");
            }

            return Result<IEnumerable<Language>>.Success(lang);
        }

        public async Task<Result<IEnumerable<Language>>> GetAllAsync(int pageing = 1, int pageSize = 10)
        {
            var lang = await _Repository.GetAllAsync(pageing, pageSize);
            
            if (lang == null)
            {
                return Result<IEnumerable<Language>>.Failure(ErrorType.NotFound, "Language Not Found");
            }
            
            return Result<IEnumerable<Language>>.Success(lang);
        }

        public async Task<Result> UpdateAsync(Language language)
        {
            var exist = await _Repository.AnyAsync(s => s.Id == language.Id);

            if (!exist)
            {
                return Result.Failure(ErrorType.NotFound, $"Language With ID {language.Id} Not Found.");
            }

            var updated = await _Repository.UpdateAsync(language);

            if (!updated)
            {
                return Result.Failure(ErrorType.InternalServerError, "Updated Failed.");
            }

            return Result.Success();
        }

        public async Task<Result> DeleteAsync(Guid id)
        {
            var lang= await _Repository.GetByIdAsync(id);

            if(lang == null)
            {
                return Result.Failure(ErrorType.NotFound, $"Language With ID :{id} Not Found");
            }
            var delete=await _Repository.DeleteAsync(lang);

            if (!delete)
            {
                return Result.Failure(ErrorType.InternalServerError, "Delete Failed.");
            }
            return Result.Success();
        }
    }
}
