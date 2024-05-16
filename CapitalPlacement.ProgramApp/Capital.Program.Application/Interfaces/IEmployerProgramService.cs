


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
