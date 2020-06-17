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
    public partial class TodoListsP : ContentPage
    {
        TodoListsVM viewModel;

        public TodoListsP()
        {
            InitializeComponent();

            BindingContext = viewModel = new TodoListsVM();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.TodoLists.Count == 0)
                viewModel.IsBusy = true;
        }

        async private void OnTodoListSelected(object sender, EventArgs e)
        {
            var layout = (BindableObject)sender;
            var todoList = (TodoList)layout.BindingContext;

            await Navigation.PushAsync(new TodoListP(new TodoListVM(todoList)));
        }

        private async void AddTodoList_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewTodoListP()));
        }
    }
}