using Capital.Program.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capital.Program.Application.Interfaces
{
    public interface IEmployerProgramService
    {
        ValueTask<IEnumerable<EmployerProgram>> GetProgramsAsync();
        ValueTask<EmployerProgram> GetProgramAsync(string id);
        ValueTask<EmployerProgram> CreateProgramAsync(EmployerProgram program);
        ValueTask<EmployerProgram> UpdateProgramAsync(EmployerProgram program);
        ValueTask<EmployerProgram> RemoveProgramAsync(EmployerProgram program);

    }
}
