﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MusicStore.Models
{
    public class Song
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public string Genre { get; set; }

        public int ArtistId { get; set; }
        public virtual Artist Artist { get; set; }

        public int AlbumId { get; set; }
        public virtual Album album { get; set; }
    }
}
