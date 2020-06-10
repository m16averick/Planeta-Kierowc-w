using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Planeta_Kierowców.Data;

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

        public void OnGet()
        {

        }

        public IActionResult OnGetFindAllEvents()
        {
            var przedzialy = _db.Przedzials.Select(e => new
            {
                e.ID_Przedzial,
                title = e.Kierowca_ID,
                description = "",
                start = e.Od.ToString("MM/dd/yyyy"),
                end = e.Do.ToString("MM/dd/yyyy")
            }).ToList();
            return new JsonResult(przedzialy);
        }
    }
}