using System;
using System.Collections.Generic;
using System.Text;

namespace xamarinFormsExamenOpdrachtJune12.Models
{
    public class TodoList
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public List<Todo> Todos { get; set; }
    }
}
