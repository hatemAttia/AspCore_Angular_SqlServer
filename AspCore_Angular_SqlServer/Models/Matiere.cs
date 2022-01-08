using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AspCore_Angular_SqlServer.Models
{
    public partial class Matiere
    {
        public Matiere()
        {
            Chapitre = new HashSet<Chapitre>();
        }

        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        public int? NiveauId { get; set; }

        public virtual Niveau Niveau { get; set; }
        public virtual ICollection<Chapitre> Chapitre { get; set; }
    }
}
