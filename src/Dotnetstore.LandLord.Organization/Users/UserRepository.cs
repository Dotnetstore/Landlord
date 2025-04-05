using Dotnetstore.LandLord.Organization.Data;
using Dotnetstore.LandLord.Organization.Offices;
using Dotnetstore.LandLord.SharedKernel.Services;
using Microsoft.EntityFrameworkCore;

namespace Dotnetstore.LandLord.Organization.Users;

internal sealed class UserRepository(OrganizationDataContext context) : GenericRepository<User>(context), IUserRepository
{
    async ValueTask<User?> IUserRepository.GetByOfficeAndUsernameAsync(OfficeId officeId, string username, CancellationToken cancellationToken)
    {
        return await context
            .Users
            .AsNoTracking()
            .Where(x => x.OfficeId == officeId)
            .Where(x => x.Username == username)
            .FirstOrDefaultAsync(cancellationToken);
    }
}