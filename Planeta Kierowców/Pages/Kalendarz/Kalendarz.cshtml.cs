using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Planeta_Kierowców.Data;
using Planeta_Kierowców.Model;

namespace Planeta_Kierowców.Pages.Kalendarz
{
    [Authorize(Roles = "Admin")]
    public class KalendarzModel : PageModel
    {

        private readonly ApplicationDbContext _db;

        public KalendarzModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Przedzial przedzial { get; set; }

        public void OnGet()
        {
            string currentUserId = User.Identity.GetUserId();
            string currentUserName = User.Identity.GetUserName();
        }

        public async Task<IActionResult> OnPost()
        {
                przedzial.Kierowca_ID = User.Identity.GetUserId();
                przedzial.UserName = User.Identity.GetUserName();
                await _db.Przedzials.AddAsync(przedzial);
                await _db.SaveChangesAsync();
                return RedirectToPage("Kalendarz");

        }

        public IActionResult OnGetFindAllEvents()
        {
            var przedzialy = _db.Przedzials.Select(e => new
            {
                e.ID_Przedzial,
                title = e.UserName,
                description = e.Kierowca_ID,
                start = e.Od.ToString("MM/dd/yyyy"),
                end = e.Do.ToString("MM/dd/yyyy")
            }).ToList();
            return new JsonResult(przedzialy);
        }
    }
}