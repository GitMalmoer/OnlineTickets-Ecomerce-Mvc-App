﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Online_Tickets.Data.Base;
using Online_Tickets.Data.Enums;
using Online_Tickets.Models;

namespace Online_Tickets.Models
{
    public class Movie : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MovieCategory MovieCategory { get; set; }

        //Relations
        public List<Actor_Movie> Actors_Movies { get; set; }
        public Cinema Cinema { get; set; }
        [ForeignKey("CinemaId")]
        public int CinemaId { get; set; }
        [ForeignKey("ProducerId")]
        public Producer Producer { get; set; }
        public int ProducerId { get; set; }
    }
}
