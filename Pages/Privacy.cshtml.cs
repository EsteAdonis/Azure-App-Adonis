using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace azure_app_adonis.Pages;

public class PrivacyModel(ILogger<PrivacyModel> logger) : PageModel
{
	private readonly ILogger<PrivacyModel> _logger = logger;

  public void OnGet()
	{
	}
}

