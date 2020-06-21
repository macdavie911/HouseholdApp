using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TodoApi.Models
{
    public class Todo
    {
        public string Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        public bool Done { get; set; }
        public int Quantity { get; set; }
    }
}