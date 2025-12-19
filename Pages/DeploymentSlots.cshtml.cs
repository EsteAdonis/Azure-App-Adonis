using Microsoft.AspNetCore.Mvc.RazorPages;

namespace azure_app_adonis.Pages
{
	public class DeploymentSlots(ILogger<DeploymentSlots> logger) : PageModel
	{
		private readonly ILogger<DeploymentSlots> _logger = logger;

		public void OnGet()
		{
		}
	}
}