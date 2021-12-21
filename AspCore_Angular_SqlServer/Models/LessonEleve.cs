using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AspCore_Angular_SqlServer.Models
{
    public partial class LessonEleve
    {
        public int Id { get; set; }
        public int? EleveId { get; set; }
        public int? LessonId { get; set; }

        public virtual Eleve Eleve { get; set; }
        public virtual Lesson Lesson { get; set; }
    }
}
