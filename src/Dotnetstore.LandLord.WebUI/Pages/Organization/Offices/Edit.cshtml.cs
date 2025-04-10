using Dotnetstore.LandLord.SDK.Clients.Organization;
using Dotnetstore.LandLord.SDK.Requests.Organization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dotnetstore.LandLord.WebUI.Pages.Organization.Offices;

public class Edit(IOfficeClient officeClient) : PageModel
{
    [BindProperty]
    public UpdateOfficeRequest OfficeRequest { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(Guid id, CancellationToken cancellationToken)
    {
        var result = await officeClient.GetByIdAsync(id, cancellationToken);
        
        if (!result.httpResponseMessage.IsSuccessStatusCode)
        {
            return NotFound();
        }

        OfficeRequest = new UpdateOfficeRequest
        {
            Name = result.OfficeResponse.Name,
            CorporateId = result.OfficeResponse.CorporateId
        };

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(Guid id, CancellationToken cancellationToken)
    {
        var result = await officeClient.UpdateAsync(
            id,
            OfficeRequest, 
            cancellationToken);

        if (result.httpResponseMessage.IsSuccessStatusCode)
        {
            return Redirect("~/Organization/Offices/");
        }

        ModelState.AddModelError(string.Empty, "Failed to update office. Please try again.");
        return Page();
    }
}