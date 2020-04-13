using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization; //libreria che mi permette di utilizzare i decoratore [Authorize]
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Music_Tracks.Models;

namespace Music_Tracks.Pages.Eventi
{
    [Authorize] //solo l'utente autenticato può creare una nuova traccia musicale
    public class CreateModel : PageModel
    {
        private readonly Music_Tracks.Models.Music_TracksContext _context;
        private readonly Music_Tracks.Models.UserContext _context2;

        public CreateModel(Music_Tracks.Models.Music_TracksContext context, Music_Tracks.Models.UserContext context2)
        {
            _context = context;
            _context2 = context2;
        }
        public IList<User> User { get; set; }

        public async Task OnGetAsync()
        {
            User = await _context2.User.ToListAsync();
        }

        [BindProperty]
        public Track Track { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Track.Add(Track);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}