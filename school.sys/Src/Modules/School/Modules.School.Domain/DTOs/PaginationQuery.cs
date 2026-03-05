using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.School.Domain.DTOs
{
    public class PaginationQuery
    {
        private const int MaxPageSize = 100;

        [Range(1, int.MaxValue, ErrorMessage = "PageNumber must be greater than 0")]
        public int PageNumber { get; set; } = 1;

        [Range(1, MaxPageSize, ErrorMessage = "PageSize must be between 1 and 100")]
        public int PageSize { get; set; } = 100;
    }
}
