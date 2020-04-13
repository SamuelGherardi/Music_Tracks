using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; //libreria che mi occorre per utilizzarei decoratori [Key] e [Required]
using System.Linq;
using System.Threading.Tasks;

namespace Music_Tracks.Models
{
    public class Track
    {
        [Key] //attributo chiave della traccia musicale
        public int Id { get; set; } //identificatore univoco della traccia musicale
        [Required] //questo attributo è necessario
        public string name { get; set; } //nome della traccia musicale
        [Required] //questo attributo è necessario
        public string album { get; set; } //nome dell'album a cui appartiene la traccia musicale
        [Required] //questo attributo è necessario
        public string singer { get; set; } //cantante/band che canta la traccia musicale
        [Required] //questo attributo è necessario
        public float length { get; set; } //lunghezza in minuti della traccia musicale
        [Required] //questo attributo è necessario
        public string category { get; set; } //categoria a cui appartiene la traccia musicale
    }
}
