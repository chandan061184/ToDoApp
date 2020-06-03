using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.Models
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(192)]
        public string Title { get; set; }
        
        public string Discription { get; set; }

        [Required]        
        public string Status { get; set; }

        //Many to many relationship
        public ICollection<TodoTag> TodoTags { get; set; }


        //Optimistic concurrency
        [Timestamp]
        public byte[] RowVersion { get; set; }

    }
}
