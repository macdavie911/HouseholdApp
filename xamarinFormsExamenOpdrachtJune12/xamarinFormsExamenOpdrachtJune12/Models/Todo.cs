using System;
using System.Collections.Generic;
using System.Text;

namespace xamarinFormsExamenOpdrachtJune12.Models
{
    public class Todo
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; } = false;
    }
}
