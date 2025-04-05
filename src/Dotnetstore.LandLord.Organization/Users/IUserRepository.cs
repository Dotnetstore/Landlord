using Dotnetstore.LandLord.Organization.Offices;
using Dotnetstore.LandLord.SharedKernel.Services;

namespace Dotnetstore.LandLord.Organization.Users;

internal interface IUserRepository : IGenericRepository<User>
{
    ValueTask<User?> GetByOfficeAndUsernameAsync(OfficeId officeId, string username, CancellationToken cancellationToken = default);
}