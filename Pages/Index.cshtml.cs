using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace azure_app_adonis.Pages;

public class IndexModel(ILogger<IndexModel> logger) : PageModel
{
	private readonly ILogger<IndexModel> _logger = logger;

  public void OnGet()
	{

	}
}
