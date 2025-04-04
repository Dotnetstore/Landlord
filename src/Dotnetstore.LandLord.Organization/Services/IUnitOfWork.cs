using Dotnetstore.LandLord.Organization.Offices;

namespace Dotnetstore.LandLord.Organization.Services;

internal interface IUnitOfWork
{
    IOfficeRepository Offices { get; }
    void CreateTransaction();
    void Commit();
    void Rollback();
    ValueTask<int> Save();
}