using Dotnetstore.LandLord.SDK.Clients.Organization;
using Dotnetstore.LandLord.SDK.Requests.Organization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dotnetstore.LandLord.WebUI.Pages.Organization.Offices;

public class Create(IOfficeClient officeClient) : PageModel
{
    [BindProperty]
    public CreateOfficeRequest OfficeRequest { get; set; } = new();

    public IActionResult OnGet()
    {
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(CancellationToken cancellationToken)
    {
        var result = await officeClient.CreateAsync(OfficeRequest, cancellationToken);

        if (result.httpResponseMessage.IsSuccessStatusCode) return Redirect("~/Organization/Offices/");
        ModelState.AddModelError(string.Empty, "Failed to create office. Please try again.");
        return Page();
    }
}