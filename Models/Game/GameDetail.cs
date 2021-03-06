﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Game
{
    public class GameDetail
    {
        public int GameId { get; set; }
        [Display(Name = "Game")]
        public string Title { get; set; }
        public string Genre { get; set; }
        [Display(Name ="Release Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/yyyy}")]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Is it Released?")]
        public bool IsReleased { get; set; }
        [Display(Name = "Is it still Early Access?")]
        public bool EarlyAccess { get; set; }
        [Display(Name = "Game Website Link")]
        public string GameWebsite { get; set; }
        [Display(Name = "Do you own it?")]
        public bool IsOwned { get; set; }
    }
}
