﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AspCore_Angular_SqlServer.Models
{
    public partial class Lesson
    {
        public Lesson()
        {
            Document = new HashSet<Document>();
            LessonEleve = new HashSet<LessonEleve>();
            Video = new HashSet<Video>();
        }

        public int Id { get; set; }
        public string Titre { get; set; }
        public string Descrption { get; set; }
        public int? ChapitreId { get; set; }
        public int? EnsegnantId { get; set; }

        public virtual Chapitre Chapitre { get; set; }
        public virtual Enseignant Ensegnant { get; set; }
        public virtual ICollection<Document> Document { get; set; }
        public virtual ICollection<LessonEleve> LessonEleve { get; set; }
        public virtual ICollection<Video> Video { get; set; }
    }
}
