using System;
using System.Collections.Generic;

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
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Niveau { get; set; }
        public int? Tel { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }

        public virtual ICollection<LessonEleve> LessonEleve { get; set; }
    }
}
