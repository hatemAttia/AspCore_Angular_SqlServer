using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AspCore_Angular_SqlServer.Models
{
    public partial class Niveau
    {
        public Niveau()
        {
            Matiere = new HashSet<Matiere>();
        }

        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public int? SectionId { get; set; }

        public virtual Section Section { get; set; }
        public virtual ICollection<Matiere> Matiere { get; set; }
    }
}
