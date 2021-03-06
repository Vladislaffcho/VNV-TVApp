﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TvContext
{
    public class TvShow : CommentedEntity
    {
        public TvShow()
        {
            UserSchedules = new List<UserSchedule>();
        }

        // set show name
        [MinLength(2, ErrorMessage = "Too short name (must be 2-255)")]
        [MaxLength(255)]
        [Required]
        public string Name { get; set; }

        // date of a show broadcasting
        [Column(TypeName = "datetime2")]
        [Required]
        public DateTime Date { get; set; }

        // false if a show does not have age limitations
        [DefaultValue(false)]
        public bool IsAgeLimit { get; set; }

        //original id channel of tvProgramms which gets from xml incoming data file
        [Required]
        public int CodeOriginalChannel { get; set; }
       
        // link with table Channel
        [Required]
        public Channel Channel { get; set; }

        //info about all UserShedule which ordered this show
        public ICollection<UserSchedule> UserSchedules { get; set; }
    }
}