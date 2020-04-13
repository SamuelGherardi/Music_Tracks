using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization; //libreria che serve per utilizzare il decoratore [Authorize]
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Music_Tracks.Models; //mi colleggo alla cartella Models che contiene il modello News.cs

namespace Music_Tracks.Pages
{
    
    public class NewsModel : PageModel
    {
        private readonly Music_Tracks.Data.NewsContext _context;

        public NewsModel(Music_Tracks.Data.NewsContext context)
        {
            _context = context;
        }

        public IList<News> News { get; set; }

        public async Task OnGetAsync()
        {
            News = await _context.News.ToListAsync();
        }
    }
}