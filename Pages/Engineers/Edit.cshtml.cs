using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using azure_app_adonis.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Logging;

namespace azure_app_adonis.Pages.Engineers
{
	public class Edit(IEngineerService engineerService, ILogger<Edit> logger) : PageModel
	{
		private readonly IEngineerService engineerService = engineerService;
		private readonly ILogger<Edit> _logger = logger;

		[Parameter]
		public string id { get; set; } = default!; 

		[BindProperty]
		public Engineer Engineer { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(string id)
		{
			Console.WriteLine($"OnGetAsync called with id: {id}");
 		  if (!ModelState.IsValid)
			{
				return Page();
			}
			var engineer = await engineerService.GetEngineerDetailsById(id, id);
			if (engineer == null)
			{
				return NotFound();
			}
			Engineer = engineer;
			return Page();
		}

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			try
			{
				await engineerService.UpdateEngineer(Engineer);
				return RedirectToPage("./Index");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error updating engineer");
				ModelState.AddModelError(string.Empty, "An error occurred while updating the engineer.");
				return Page();
			}
		}
	}
}