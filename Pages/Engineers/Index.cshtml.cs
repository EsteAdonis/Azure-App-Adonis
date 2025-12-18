using azure_app_adonis.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace azure_app_adonis.Pages.Engineers
{
	public class Index(IEngineerService engineerService, ILogger<Index> logger) : PageModel
	{
		private readonly ILogger<Index> _logger = logger;
		private readonly IEngineerService _engineerService= engineerService;		

		public List<Engineer> Engineer { get; set; } = default!;
		
		public async Task OnGetAsync()
		{
			Engineer = await _engineerService.GetEngineerDetails();
			if (Engineer == null || Engineer.Count == 0)
			{
				_logger.LogInformation("No engineers found.");
			}
			else
			{
				_logger.LogInformation($"Found {Engineer.Count} engineers.");
			}
		}
	}
}