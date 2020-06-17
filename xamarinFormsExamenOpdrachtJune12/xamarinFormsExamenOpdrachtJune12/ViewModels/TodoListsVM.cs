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
    public class TodoListsVM : BaseVM
    {
        public ObservableCollection<TodoList> TodoLists { get; set; }
        public Command LoadTodoListsCommand { get; set; }

        public TodoListsVM()
        {
            Title = "Todolists";
            TodoLists = new ObservableCollection<TodoList>();
            LoadTodoListsCommand = new Command(async () => await ExecuteLoadTodoListsCommand());

            MessagingCenter.Subscribe<NewTodoListP, TodoList>(this, "AddTodoList", async (obj, todoList) =>
            {
                var newTodoList = todoList as TodoList;
                TodoLists.Add(newTodoList);
                await DataStore.AddTodoListAsync(newTodoList);
            });


            MessagingCenter.Subscribe<TodoListP, string>(this, "DeleteTodoList", async (obj, todoListId) =>
            {
                var todoList = TodoLists.Where((TodoList arg) => arg.Id == todoListId).FirstOrDefault();
                
                TodoLists.Remove(todoList);
                await DataStore.DeleteTodoListAsync(todoListId);
            });
        }

        async Task ExecuteLoadTodoListsCommand()
        {
            IsBusy = true;

            try
            {
                TodoLists.Clear();
                var todoLists = await DataStore.GetTodoListsAsync(true);

                foreach (var todoList in todoLists)
                {
                    TodoLists.Add(todoList);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
