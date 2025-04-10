using Dotnetstore.LandLord.Organization.Data;
using Dotnetstore.LandLord.SharedKernel.Extensions;
using Dotnetstore.LandLord.SharedKernel.Services;
using Microsoft.EntityFrameworkCore;

namespace Dotnetstore.LandLord.Organization.Offices;

internal sealed class OfficeRepository(OrganizationDataContext context) : GenericRepository<Office>(context), IOfficeRepository
{
    async ValueTask<List<Office>> IOfficeRepository.GetAllOfficesAsync(CancellationToken cancellationToken)
    {
        return await context
            .Offices
            .AsNoTracking()
            .OrderBy(x => x.Name)
            .ThenBy(x => x.CorporateId)
            .ToListAsync(cancellationToken);
    }

    void IOfficeRepository.DetachEntity(Office office)
    {
        context.DetachEntity(office);
    }
}