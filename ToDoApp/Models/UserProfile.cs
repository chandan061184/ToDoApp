﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.Models
{
    public class UserProfile
    {
        [Key]
        public int Id { get; set; }
        
        public string PictureUrl { get; set; }
        
        public string Address { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Password { get; set; }

        //One to one relationship with User
        //Navigation property
        public int UserId { get; set; }

        public User User  { get; set; }
    }
}
