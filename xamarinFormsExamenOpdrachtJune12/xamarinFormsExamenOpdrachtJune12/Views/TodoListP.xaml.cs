using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xamarinFormsExamenOpdrachtJune12.Models;
using xamarinFormsExamenOpdrachtJune12.ViewModels;

namespace xamarinFormsExamenOpdrachtJune12.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodoListP : ContentPage
    {
        TodoListVM TodoListVM;

        public TodoListP(TodoListVM viewModel)
        {
            InitializeComponent();

            BindingContext = this.TodoListVM = viewModel;
        }

        public TodoListP()
        {
            InitializeComponent();

            var todoList = new TodoList
            {
                Title = "Title",
                Todos = new List<Todo>()
                    {
                        new Todo { Id = Guid.NewGuid().ToString(), Title = "TODOLIST 1 First item", Description="This is an item description." },
                    }
            };

            BindingContext = TodoListVM = new TodoListVM(todoList);
        }

       
        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewTodoP(TodoListVM)));
        }

        async void DeleteTodoList_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "DeleteTodoList", TodoListVM.Id);

            await Navigation.PopToRootAsync();
        }

        private async void OnTodoSelected(object sender, EventArgs e)
        {
            var layout = (BindableObject)sender;
            var todo = (Todo)layout.BindingContext;

            await Navigation.PushModalAsync(new NavigationPage(new TodoP(new TodoVM(todo, TodoListVM))));
           // await Navigation.PushAsync(new TodoP(new TodoVM(todo, TodoListVM)));
        }
    }
}