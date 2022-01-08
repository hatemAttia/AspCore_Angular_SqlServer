using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AspCore_Angular_SqlServer.Models
{
    public partial class Chapitre
    {
        public Chapitre()
        {
            Lesson = new HashSet<Lesson>();
        }

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public int? MatiereId { get; set; }

    
        public virtual Matiere Matiere { get; }
        public virtual ICollection<Lesson> Lesson { get; }
    }
}
