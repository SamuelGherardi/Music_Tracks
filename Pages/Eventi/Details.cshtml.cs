using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Music_Tracks.Models;
using Microsoft.AspNetCore.Authorization; //libreria che mi permette di utilizzare i decoratore [Authorize]

namespace Music_Tracks.Pages.Eventi
{
    [Authorize] //solo l'utente autenticato può visualizzare i dettagli di una traccia musicale
    public class DetailsModel : PageModel
    {
        private readonly Music_Tracks.Models.Music_TracksContext _context;

        public DetailsModel(Music_Tracks.Models.Music_TracksContext context)
        {
            _context = context;
        }

        public Track Track { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Track = await _context.Track.FirstOrDefaultAsync(m => m.Id == id);

            if (Track == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
