using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Planeta_Kierowców.Model;
using Planeta_Kierowców.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace Planeta_Kierowców.Pages.Zamówienia
{
    public class DetailsModel : PageModel
    {
        private ApplicationDbContext _db;

        public DetailsModel(ApplicationDbContext db)
        {
            _db = db;
        }



        [BindProperty]
        public Zlecenia zlecenie { get; set; }


        public IEnumerable<Protokoly> protokolies { get; set; }

        public async Task OnGet(int id)
        {
            zlecenie = await _db.Zlecenia.FindAsync(id);
            protokolies = await _db.Protokoly.Where(s => s.Zlecenie_ID.Equals(id)).ToListAsync();

        }

        public async Task<IActionResult> OnPost()
        {

            return RedirectToPage();
        }
    }
}