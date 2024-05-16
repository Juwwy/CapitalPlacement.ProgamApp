
namespace Capital.Program.Infrastructure.Services
{
    public class EmployerProgramService : IEmployerProgramService
    {
        private readonly CapitalProgramDbContext context;

        public EmployerProgramService(CapitalProgramDbContext context)
        {
            this.context = context;
        }

        public async ValueTask<EmployerProgram> CreateProgramAsync(EmployerProgram program)
        {
            var result = await context.EmployerPrograms.AddAsync(program);
            await context.SaveChangesAsync();

            return result.Entity;
        }

        public async ValueTask<EmployerProgram> GetProgramAsync(string id)
        {
            return await context.EmployerPrograms
                .FirstOrDefaultAsync(x => x.Id == id);
            
        }

        public async ValueTask<IEnumerable<EmployerProgram>> GetProgramsAsync()
        {
            return context.EmployerPrograms.ToList();

        }

        public async ValueTask<EmployerProgram> RemoveProgramAsync(EmployerProgram program)
        {
            var result = context.EmployerPrograms.Remove(program);
            await context.SaveChangesAsync();

            return result.Entity;
        }

        public async ValueTask<EmployerProgram> UpdateProgramAsync(EmployerProgram program)
        {
            var result = context.EmployerPrograms.Update(program);
            await context.SaveChangesAsync();

            return result.Entity;
        }
    }
}
