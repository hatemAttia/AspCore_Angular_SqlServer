using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AspCore_Angular_SqlServer.Models
{
    public partial class Section
    {
        public Section()
        {
            Niveau = new HashSet<Niveau>();
        }

        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        public virtual ICollection<Niveau> Niveau { get; set; }
    }
}
