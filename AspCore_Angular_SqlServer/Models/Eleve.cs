using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AspCore_Angular_SqlServer.Models
{
    public partial class Eleve
    {
        public Eleve()
        {
            LessonEleve = new HashSet<LessonEleve>();
        }
     
        public int Id { get; set; }
        [Required]
        public string Nom { get; set; }
        [Required]
        public string Prenom { get; set; }
        [Required]
        public string Niveau { get; set; }

        [Required]
        public string password { get; set; }

        public string Token { get; set; }
        [Required]
        public int? Tel { get; set; }
        [Required]
        public string Email { get; set; }

       /* [Display(Name="choose your photo")]
        [Required] */
        public string Image { get; set; } 

        public virtual ICollection<LessonEleve> LessonEleve { get; set; }
    }
}
