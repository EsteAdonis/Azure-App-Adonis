using azure_app_adonis.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace azure_app_adonis.Pages.Engineers
{
	public class Create(IEngineerService engineerService, ILogger<Create> logger) : PageModel
	{
		private readonly IEngineerService _engineerService = engineerService;
		private readonly ILogger<Create> _logger = logger;

		public IActionResult OnGet() => Page();

		[BindProperty]
		public Engineer Engineer { get; set; } = new();

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			try
			{
				await _engineerService.AddEngineer(Engineer);
				return RedirectToPage("./Index");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error adding engineer");
				ModelState.AddModelError(string.Empty, "An error occurred while adding the engineer.");
				return Page();
			}
		}
  }
}