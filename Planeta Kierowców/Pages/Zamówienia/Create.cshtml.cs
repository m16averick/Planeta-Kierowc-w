using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Planeta_Kierowców.Data;
using Planeta_Kierowców.Model;




namespace Planeta_Kierowców.Pages.Zamówienia
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public order order { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _db.order.AddAsync(order);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }

            else
            {
                return Page();
            }
        }
    }
}