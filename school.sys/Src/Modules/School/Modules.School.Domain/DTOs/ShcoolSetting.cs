using Modules.School.Domain.Entities;

namespace Modules.School.Domain.DTOs
{
    public class ShcoolSetting
    {
        public Language? Languages { get; set; }
        public Policy? Policies { get; set; }
    }
}