using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Events
{
    public record UserVerifyIntegrationEvent(string email,string otp) : IntegrationEvent(Guid.NewGuid());

}
