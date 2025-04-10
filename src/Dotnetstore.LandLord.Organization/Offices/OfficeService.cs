using Ardalis.Result;
using Dotnetstore.LandLord.Organization.Services;
using Dotnetstore.LandLord.SDK.Requests.Organization;
using Dotnetstore.LandLord.SDK.Responses.Organization;

namespace Dotnetstore.LandLord.Organization.Offices;

internal sealed class OfficeService(IUnitOfWork unitOfWork) : IOfficeService
{
    async ValueTask<IEnumerable<OfficeResponse>> IOfficeService.GetAllAsync(CancellationToken cancellationToken)
    {
        var offices = await unitOfWork
            .Offices
            .GetAllAsync(cancellationToken);
        
        return offices.Select(x => new OfficeResponse(x.Id.Value, x.Name, x.CorporateId)).ToList();
    }

    async ValueTask<Result<OfficeResponse>> IOfficeService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var office = await unitOfWork
            .Offices
            .GetByIdAsync(new OfficeId(id), cancellationToken);
        
        if (office is null)
            return Result<OfficeResponse>.NotFound("Office not found");
        
        return Result<OfficeResponse>.Success(office.ToOfficeResponse());
    }

    async ValueTask<Result<OfficeResponse>> IOfficeService.CreateAsync(CreateOfficeRequest req, CancellationToken cancellationToken)
    {
        var office = OfficeBuilder.Create()
            .WithId(new OfficeId(Guid.CreateVersion7()))
            .WithName(req.Name)
            .WithCorporateId(req.CorporateId)
            .Build();
        
        await unitOfWork.Offices.InsertAsync(office, cancellationToken);
        var result = await unitOfWork.SaveChangesAsync(cancellationToken);
        
        if (result == 0)
            return Result<OfficeResponse>.Error("Failed to create office. Please try again.");

        return Result<OfficeResponse>.Success(office.ToOfficeResponse());
    }

    async ValueTask<Result<OfficeResponse>> IOfficeService.UpdateAsync(Guid id, UpdateOfficeRequest req, CancellationToken cancellationToken)
    {
        var officeId = new OfficeId(id);
        var office = await unitOfWork
            .Offices
            .GetByIdAsync(officeId, cancellationToken);
        
        if (office is null)
            return Result<OfficeResponse>.NotFound("Office not found");
        
        unitOfWork.Offices.DetachEntity(office);
        
        var officeToUpdate = OfficeBuilder.Create()
            .WithId(office.Id)
            .WithName(req.Name)
            .WithCorporateId(req.CorporateId)
            .Build();
        
        unitOfWork.Offices.Update(officeToUpdate);
        var result = await unitOfWork.SaveChangesAsync(cancellationToken);
        
        if (result == 0)
            return Result<OfficeResponse>.Error("Failed to update office. Please try again.");
        
        return Result<OfficeResponse>.Success(office.ToOfficeResponse());
    }

    async ValueTask<Result<bool>> IOfficeService.DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var officeId = new OfficeId(id);
        var office = await unitOfWork
            .Offices
            .GetByIdAsync(officeId, cancellationToken);
        
        if (office is null)
            return Result<bool>.NotFound("Office not found");
        
        await unitOfWork.Offices.DeleteAsync(officeId, cancellationToken);
        var result = await unitOfWork.SaveChangesAsync(cancellationToken);
        
        if (result == 0)
            return Result<bool>.Error("Failed to delete office. Please try again.");
        
        return Result<bool>.Success(true);
    }
}