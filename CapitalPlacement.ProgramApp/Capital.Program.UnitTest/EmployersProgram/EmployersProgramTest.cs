
namespace Capital.Program.UnitTest.EmployersProgram
{
    public class EmployersProgramTest
    {
        private readonly Mock<IEmployerProgramService> employerServiceMock;


        public EmployersProgramTest()
        {
            employerServiceMock = new Mock<IEmployerProgramService>();
        }

        [Fact]
        public async Task GetAllProgram_ShouldReturnAllPrograms()
        {
            var programs = new List<EmployerProgram>
            {
                new EmployerProgram
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Test",
                    Description = "Test running"
                },

                new EmployerProgram
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Banking Induction",
                    Description = "Training youth for future"
                },
            };

            employerServiceMock.Setup(src => src.GetProgramsAsync()).ReturnsAsync(programs);
        }


        [Fact]
        public async Task GetProgramById_ShouldReturnSingleProgram()
        {
            var program = new EmployerProgram
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Test",
                Description = "Test running"
            };

            employerServiceMock.Setup(src => src.GetProgramAsync(program.Id)).ReturnsAsync(program);
        }

        [Fact]
        public async Task AddProgramAsync_ShouldCallCreateProgramService()
        {
            var program = new EmployerProgram
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Law firm",
                Description = "Challenges of the judiciary"
            };

            employerServiceMock.Setup(src => src.CreateProgramAsync(program)).ReturnsAsync(program);
        }
    }
}
