using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TodoApi.Models
{
    public class TodoList
    {
        public string Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        public List<Todo> Todos { get; set; }
    }
}