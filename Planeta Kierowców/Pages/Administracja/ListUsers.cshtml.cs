using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Planeta_Kierowców.Data;

namespace Planeta_Kierowców.Pages.Administracja
{
    [Authorize(Roles = "Admin")]
    public class ListUsersModel : PageModel
    {


        public void OnGet()
        {

        }
    }
}