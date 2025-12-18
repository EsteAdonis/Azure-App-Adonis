using azure_app_adonis.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace azure_app_adonis.Pages.Engineers
{
	public class Delete(IEngineerService engineerService, ILogger<Delete> logger) : PageModel
	{
		private readonly IEngineerService engineerService = engineerService;
		private readonly ILogger<Delete> _logger = logger;

		[BindProperty]
		public Engineer Engineer { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(string id)
		{
			var engineer = await engineerService.GetEngineerDetailsById(id, id);
			if (engineer == null)
			{
				return NotFound();
			}
			Engineer = engineer;
			return Page();
		}

		public async Task<IActionResult> OnPostAsync(string id)
		{
			if (string.IsNullOrEmpty(id))
			{
				return NotFound();
			}
			try
			{
				await engineerService.DeleteEngineer(id, id);
				return RedirectToPage("./Index");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error deleting engineer");
				ModelState.AddModelError(string.Empty, "An error occurred while deleting the engineer.");
				return Page();
			}
		}
	}
}