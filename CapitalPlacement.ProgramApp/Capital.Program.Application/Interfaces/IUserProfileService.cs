using Capital.Program.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capital.Program.Application.Interfaces
{
    public interface IUserProfileService
    {
        ValueTask<IEnumerable<UserProfile>> GetUsersAsync();
        ValueTask<UserProfile> GetUserAsync(string id);
        ValueTask<UserProfile> CreateUserAsync(UserProfile profile);
        ValueTask<UserProfile> UpdateUserAsync(UserProfile profile);
        ValueTask<UserProfile> RemoveUserAsync(UserProfile profile);
    }
}
