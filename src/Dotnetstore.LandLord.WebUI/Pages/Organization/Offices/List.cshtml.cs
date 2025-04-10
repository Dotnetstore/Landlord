using Dotnetstore.LandLord.SDK.Clients.Organization;
using Dotnetstore.LandLord.SDK.Responses.Organization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dotnetstore.LandLord.WebUI.Pages.Organization.Offices;

public class List(IOfficeClient officeClient) : PageModel
{
    public List<OfficeResponse> Offices { get; set; } = [];
    public HttpResponseMessage HttpResponseMessage { get; set; } = new();

    public async Task OnGetAsync(CancellationToken cancellationToken)
    {
        var (offices, httpResponseMessage) = await officeClient.GetAllAsync(cancellationToken);
        HttpResponseMessage = httpResponseMessage;
        Offices = offices.ToList();
    }
    
    public async Task<IActionResult> OnPostDeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var (success, httpResponseMessage) = await officeClient.DeleteAsync(id, cancellationToken);

        if (success)
        {
            return RedirectToPage();
        }

        return Page();
    }
}