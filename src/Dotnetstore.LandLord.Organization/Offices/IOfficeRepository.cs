using Dotnetstore.LandLord.SharedKernel.Services;

namespace Dotnetstore.LandLord.Organization.Offices;

internal interface IOfficeRepository : IGenericRepository<Office>
{
    ValueTask<List<Office>> GetAllOfficesAsync(CancellationToken cancellationToken = default);

    void DetachEntity(Office office);
}