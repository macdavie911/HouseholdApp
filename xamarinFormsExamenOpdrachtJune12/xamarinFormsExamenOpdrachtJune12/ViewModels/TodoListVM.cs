using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using xamarinFormsExamenOpdrachtJune12.Models;
using xamarinFormsExamenOpdrachtJune12.Views;

namespace xamarinFormsExamenOpdrachtJune12.ViewModels
{
    public class TodoListVM : BaseVM
    {
        public ObservableCollection<Todo> Todos { get; set; }
        public string Id { get; set; }

       
        public TodoListVM(TodoList todoList = null)
        {
            ViewTitle = todoList?.Title;
            Id = todoList.Id;
            
            Todos = new ObservableCollection<Todo>();

            foreach (var todo in todoList.Todos)
            {
                Todos.Add(todo);
            }
        }



        public void Subscribe()
        {
            MessagingCenter.Subscribe<NewTodoP, Tuple<string, Todo>>(this, "AddTodo", async (obj, todoTuple) =>
            {
                string todoListId = todoTuple.Item1;
                Todo todo = todoTuple.Item2;

                if (Id == todoListId) // Id check is unecessary. Get rid of tuple
                    Todos.Add(todo);
                await DataStore.AddTodoAsync(todoListId, todo);
            });


            MessagingCenter.Subscribe<TodoP, string>(this, "DeleteTodo", async (obj, todoId) =>
            {
                var todo = Todos.Where((Todo arg) => arg.Id == todoId).FirstOrDefault();
                Todos.Remove(todo);
                await DataStore.DeleteTodoAsync(Id, todo);
            });

            /*
            MessagingCenter.Subscribe<TodoP, string>(this, "ToggleTodoDone", async (obj, todoId) =>
            {
                var todo = Todos.Where((Todo arg) => arg.Id == todoId).FirstOrDefault();

                int todoIdx = Todos.IndexOf(todo);

                Todos.Remove(todo);

                todo.Done = !todo.Done;

                Todos.Insert(todoIdx, todo);
   
                await DataStore.ToggleTodoDoneAsync(Id, todoId);           
            });
            */
            
        }

        public void Unsubscribe()
        {
            MessagingCenter.Unsubscribe<NewTodoP, Tuple<string, Todo>>(this, "AddTodo");

            MessagingCenter.Unsubscribe<TodoP, string>(this, "DeleteTodo");

           // MessagingCenter.Unsubscribe<TodoP, string>(this, "ToggleTodoDone");
        }
    }
}