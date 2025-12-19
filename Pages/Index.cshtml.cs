using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace azure_app_adonis.Pages;

public class IndexModel(ILogger<IndexModel> logger, IConfiguration config) : PageModel
{
	private readonly ILogger<IndexModel> _logger = logger;
	private readonly IConfiguration _config = config;

  public void OnGet()
	{
		ViewData["Greeting"] = _config["Greeting"];
	}
}
