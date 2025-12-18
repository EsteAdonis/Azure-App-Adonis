using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace azure_app_adonis.Pages
{
	public class DeploymentSlots : PageModel
	{
		private readonly ILogger<DeploymentSlots> _logger;

		public DeploymentSlots(ILogger<DeploymentSlots> logger)
		{
			_logger = logger;
		}

		public void OnGet()
		{
		}
	}
}