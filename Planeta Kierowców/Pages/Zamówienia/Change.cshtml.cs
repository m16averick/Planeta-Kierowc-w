using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Planeta_Kierowców.Model;
using Planeta_Kierowców.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Planeta_Kierowców.Pages.Zamówienia
{
    [Authorize(Roles = "Driver")]
    public class ChangeModel : PageModel
    {
       

        private ApplicationDbContext _db;

        IHostingEnvironment _env;
        public ChangeModel(ApplicationDbContext db, IHostingEnvironment environment)
        {
            _db = db;
            _env = environment;
        }
        [BindProperty]
        public Protokoly Protokoly { get; set; }

        [BindProperty]
        public Zlecenia Zlecenia { get; set; }
        public async Task OnGet(int id)
        {

            Zlecenia = await _db.Zlecenia.FindAsync(id);

        }


        public async Task<IActionResult> OnPost(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var imagePath = @"\Upload\Images\";
                var uploadPath = _env.WebRootPath + imagePath;

                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                //Uniq file name
                var uniqFileName = Guid.NewGuid().ToString();
                var filename = Path.GetFileName(uniqFileName + "." + file.FileName.Split(".")[1].ToLower());
                string fullPath = uploadPath + filename;

                imagePath = imagePath + @"\";
                var filePath = @".." + Path.Combine(imagePath, filename);

                using (var fileStream = new FileStream(fullPath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                ViewData["FileLocation"] = filePath;


                Protokoly.filepath = filePath;
                Protokoly.Zlecenie_ID = Zlecenia.ID_Zlecenie;
                await _db.Protokoly.AddAsync(Protokoly);
                await _db.SaveChangesAsync();

            }


            var OrderFromDb = await _db.Zlecenia.FindAsync(Zlecenia.ID_Zlecenie);
                OrderFromDb.Status_zlecenia = Zlecenia.Status_zlecenia;
                await _db.SaveChangesAsync();
                return RedirectToPage("Details", new { id = Zlecenia.ID_Zlecenie });
        }
    }
}