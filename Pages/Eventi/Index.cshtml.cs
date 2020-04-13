using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization; //libreria che occorre per utilizzare il decoratore [Authorize]
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Music_Tracks.Models;

namespace Music_Tracks.Pages.Eventi
{
    [Authorize] //solo gli utent che eseguito l'accesso possono visualizzare questa pagina
    public class IndexModel : PageModel
    {
        private readonly Music_Tracks.Models.Music_TracksContext _context;

        public IndexModel(Music_Tracks.Models.Music_TracksContext context)
        {
            _context = context;
        }

        public IList<Track> Track { get;set; }

        public async Task OnGetAsync()
        {
            Track = await _context.Track.ToListAsync();
        }
    }
}
