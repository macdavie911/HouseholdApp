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

        /*
        private bool todoDone;

        public bool TodoDone
        {
            get { return todoDone; }
            set { todoDone = value; }
        }
        */


        public TodoVM(Todo todo, TodoListVM todoListVM)
        {
            Title = todo?.Title;
            Todo = todo;
            TodoListVM = todoListVM;
        }
    }
}
