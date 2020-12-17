﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Game
{
    public class GameCreate
    {
        [Required]
        [MinLength(1, ErrorMessage = "Please enter at least 1 characters.")]
        [MaxLength(50, ErrorMessage = "There are too many characters in this field.")]
        public string Title { get; set; }
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(50, ErrorMessage = "There are too many characters in this field.")]
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool IsReleased { get; set; }
        public bool EarlyAccess { get; set; }
        [Url]
        public Uri GameWebsite { get; set; }
        public bool IsOwned { get; set; }
    }
}
