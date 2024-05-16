
namespace Capital.Program.Infrastructure.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly CapitalProgramDbContext context;

        public UserProfileService(CapitalProgramDbContext context)
        {
            this.context = context;
        }

        public async ValueTask<UserProfile> CreateUserAsync(UserProfile profile)
        {
            var result = await context.UserProfiles.AddAsync(profile);
            await context.SaveChangesAsync();

            return result.Entity;
        }

        public async ValueTask<UserProfile> GetUserAsync(string id)
        {
            return await context.UserProfiles
               .FirstOrDefaultAsync(x => x.Id == id);

        }


        public async ValueTask<IEnumerable<UserProfile>> GetUsersAsync()
        {
            return await context.UserProfiles
               .ToListAsync();
        }

        public async ValueTask<UserProfile> RemoveUserAsync(UserProfile profile)
        {
            var result = context.UserProfiles.Remove(profile);
            await context.SaveChangesAsync();

            return result.Entity;
        }

        public async ValueTask<UserProfile> UpdateUserAsync(UserProfile profile)
        {
            var result = context.UserProfiles.Update(profile);
            await context.SaveChangesAsync();

            return result.Entity;
        }
    }
}
