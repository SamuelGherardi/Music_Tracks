using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; //libreria che occorre per utilizzare il decoratore [Key]
using System.Linq;
using System.Threading.Tasks;

namespace Music_Tracks.Models
{
    public class User //classe utente per la gestione dei ruoli
    {
        [Key] //Id è la Primary Key della classe User
        public int Id { get; set; }
        public string role { get; set; }
        public string Email { get; set; }
    }
}
