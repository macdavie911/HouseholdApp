using System;
using System.Collections.Generic;
using System.Text;
using xamarinFormsExamenOpdrachtJune12.Models;

namespace xamarinFormsExamenOpdrachtJune12.ViewModels
{
    public class TodoVM : BaseVM
    {
        public Todo Todo { get; set; }
        public TodoListVM TodoListVM { get; set; }


        public TodoVM(Todo todo, TodoListVM todoListVM)
        {
            ViewTitle = todo.Title;

            Todo = todo;
            
            TodoListVM = todoListVM;
        }
    }
}
