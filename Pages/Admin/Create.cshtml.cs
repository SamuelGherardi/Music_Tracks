using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Music_Tracks.Models;
using Microsoft.AspNetCore.Authorization; //libreria che mi permette di utilizzare i decoratore [Authorize]
using Microsoft.EntityFrameworkCore;

namespace Music_Tracks.Pages.Admin
{
    [Authorize] //solo l'utente autorizzato può laccedere a questa pagina
    public class CreateModel : PageModel
    {
        private readonly Music_Tracks.Models.UserContext _context;

        public CreateModel(Music_Tracks.Models.UserContext context)
        {
            _context = context;
        }
        public IList<User> Userl { get; set; }

        public async Task OnGetAsync()
        {
            Userl = await _context.User.ToListAsync();
        }

        [BindProperty]
        public User User { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.User.Add(User);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}