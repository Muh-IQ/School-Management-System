using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.IdP.Infrastructure.Presistent.Seeds
{
    public interface ISeeder
    {
     void Seed(ModelBuilder modelBuilder);

    }
}
