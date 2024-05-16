
namespace Capital.Program.UnitTest.UsersProfile
{
    public class UsersProgramTest
    {
        private readonly Mock<IUserProfileService> userProfileServiceMock;

        public UsersProgramTest()
        {
            userProfileServiceMock = new Mock<IUserProfileService>();
        }

        [Fact]
        public async Task GetAllUserProfile_ShouldReturnUsersProfile()
        {
            var profiles = new List<UserProfile>
            {
                new UserProfile
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = "Bola",
                    LastName = "Joshua",
                    EmailAddress = "Bola.joshua23@gmail.com",
                    Gender = "Female",
                    Nationality = "Nigerian",
                    CurrentResidence ="Lagos",
                    DateOfBirth = DateTime.Now,
                    IdNumber = "MB8902GHJ",
                    Phone = "08145627211",
                    EmployerProgramId = Guid.NewGuid().ToString()
                },

                new UserProfile
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = "Yinka",
                    LastName = "Adebiyi",
                    EmailAddress = "adex.billy@gmail.com",
                    Gender = "Male",
                    Nationality = "Nigerian",
                    CurrentResidence ="Lagos",
                    DateOfBirth= DateTime.Now,
                    IdNumber = "BBE2345GF",
                    Phone = "08165627209",
                    EmployerProgramId = Guid.NewGuid().ToString()
                },
            };

            userProfileServiceMock.Setup(src => src.GetUsersAsync()).ReturnsAsync(profiles);
        }


        [Fact]
        public async Task GetProfileById_ShouldReturnSingleProfile()
        {
            var profile = new UserProfile
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "Andrew",
                LastName = "Jacobs",
                EmailAddress = "jayvile45@gmail.com",
                Gender = "Male",
                Nationality = "Ghanian",
                CurrentResidence = "Kumasi",
                DateOfBirth = DateTime.Parse("09-02-1984"),
                IdNumber = "UTE2345LW",
                Phone = "08175627209",
                EmployerProgramId = Guid.NewGuid().ToString()
            };

            userProfileServiceMock.Setup(src => src.GetUserAsync(profile.Id)).ReturnsAsync(profile);
        }

        [Fact]
        public async Task AddProfileAsync_Should_CreateProfile()
        {
            var profile = new UserProfile
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "Andrew",
                LastName = "Jacobs",
                EmailAddress = "jayvile45@gmail.com",
                Gender = "Male",
                Nationality = "Ghanian",
                CurrentResidence = "Kumasi",
                DateOfBirth = DateTime.Parse("09-02-1984"),
                IdNumber = "UTE2345LW",
                Phone = "08175627209",
                EmployerProgramId = Guid.NewGuid().ToString()
            };

            userProfileServiceMock.Setup(src => src.CreateUserAsync(profile)).ReturnsAsync(profile);
        }
    }
}
