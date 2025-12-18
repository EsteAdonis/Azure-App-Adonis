using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using azure_app_adonis.Data;

namespace azure_app_adonis.Pages_Persons
{
	public class IndexModel(AppDbContext context) : PageModel
	{
		private readonly AppDbContext _context = context;

    public IList<Person> Person { get; set; } = default!;

		public async Task OnGetAsync()
		{
			Person = await _context.Persons.ToListAsync();
		}
	}
}
