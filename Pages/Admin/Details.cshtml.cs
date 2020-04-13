using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Music_Tracks.Models;
using Microsoft.AspNetCore.Authorization; //libreria che mi permette di utilizzare i decoratore [Authorize]

namespace Music_Tracks.Pages.Admin
{
    [Authorize] //solo l'utente autorizzato può laccedere a questa pagina
    public class DetailsModel : PageModel
    {
        private readonly Music_Tracks.Models.UserContext _context;

        public DetailsModel(Music_Tracks.Models.UserContext context)
        {
            _context = context;
        }
        public IList<User> Userl { get; set; }
        public User User { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Userl = await _context.User.ToListAsync();
     
            if (id == null)
            {
                return NotFound();
            }

            User = await _context.User.FirstOrDefaultAsync(m => m.Id == id);

            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
