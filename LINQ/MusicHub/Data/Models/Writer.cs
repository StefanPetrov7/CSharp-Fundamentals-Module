﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicHub.Data.Models
{
    public class Writer
    {
        public Writer()
        {
            this.Songs = new HashSet<Song>();
        }

    
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }


        public string Pseudonym { get; set; }


        [InverseProperty("Writer")]
        public ICollection<Song> Songs { get; set; }
    }
}
