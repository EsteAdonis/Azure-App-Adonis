using azure_app_adonis.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace azure_app_adonis.Pages.Engineers
{
	public class Details(IEngineerService engineerService,   ILogger<Details> logger) : PageModel
	{
		private readonly IEngineerService engineerService = engineerService;
		private readonly ILogger<Details> _logger = logger;

		[BindProperty]
		public Engineer Engineer { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(string id)
		{
			try
			{
				var engineer = await engineerService.GetEngineerDetailsById(id, id);
				if (engineer == null)
				{
					return NotFound();
				}
				Engineer = engineer;				
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error retrieving engineer details");
			}
			return Page();
		}
	}
}