﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Music_Tracks.Models;
using Microsoft.AspNetCore.Authorization; //libreria che mi permette di utilizzare i decoratore [Authorize]

namespace Music_Tracks.Pages.Eventi
{
    [Authorize] //solo l'utente autenticato può modificare una traccia musicale
    public class EditModel : PageModel
    {
        private readonly Music_Tracks.Models.Music_TracksContext _context;
        private readonly Music_Tracks.Models.UserContext _context2;

        public EditModel(Music_Tracks.Models.Music_TracksContext context, Music_Tracks.Models.UserContext context2)
        {
            _context = context;
            _context2 = context2;
        }
        public IList<User> User { get; set; }

        [BindProperty]
        public Track Track { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            User = await _context2.User.ToListAsync();

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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Track).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrackExists(Track.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TrackExists(int id)
        {
            return _context.Track.Any(e => e.Id == id);
        }
    }
}
