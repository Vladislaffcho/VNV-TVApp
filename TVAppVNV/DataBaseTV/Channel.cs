﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TVAppVNV.DataBaseTV
{
    public class Channel
    {

        public Channel()
        {

        }

        //Mark this field as primary key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //this channel name
        [MinLength(2)]
        [MaxLength(30)]
        [Required]
        public string Name { get; set; }

        //channel price per week
        [Required]
        public double Price { get; set; }

        //true - content for everyone, false - only 18+
        [Required]
        [DefaultValue(true)]
        public bool AgeLimit { get; set; }


    }
}