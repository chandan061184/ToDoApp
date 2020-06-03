﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(32)]
        public string FristName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(32)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        //One to one relationship with UserProfile
        public UserProfile UserProfile { get; set; }

        //One to many relationship with Todo
        public ICollection<Todo> Todos { get; set; }
    }
}
