using Dotnetstore.LandLord.Organization.Offices;
using Dotnetstore.LandLord.Organization.Users;

namespace Dotnetstore.LandLord.Organization.Services;

internal interface IUnitOfWork
{
    IOfficeRepository Offices { get; }
    IUserRepository Users { get; }
    void CreateTransaction();
    void Commit();
    void Rollback();
    ValueTask<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}