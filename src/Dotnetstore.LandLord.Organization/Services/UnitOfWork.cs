using Dotnetstore.LandLord.Organization.Data;
using Dotnetstore.LandLord.Organization.Offices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Dotnetstore.LandLord.Organization.Services;

internal class UnitOfWork(
    OrganizationDataContext context,
    IOfficeRepository officeRepository)
    : IUnitOfWork, IDisposable
{
    private IDbContextTransaction? _objTran;
    
    public IOfficeRepository Offices { get; } = officeRepository;

    public void CreateTransaction()
    {
        _objTran = context.Database.BeginTransaction();
    }
        
    public void Commit()
    {
        _objTran?.Commit();
    }
        
    public void Rollback()
    {
        _objTran?.Rollback();
        _objTran?.Dispose();
    }
        
    public async ValueTask<int> Save()
    {
        try
        {
            return await context.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
        
    public void Dispose()
    {
        context.Dispose();
    }
}