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
    public partial class NewTodoP : ContentPage
    {
        public Todo Todo { get; set; }

        public TodoListVM TodoListVM { get; set; }
  
        public NewTodoP(TodoListVM todoListVM)
        {
            InitializeComponent();

            TodoListVM = todoListVM;

            Todo = new Todo
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Item name",
                Description = "This is an item description."
            };

            BindingContext = this;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            TodoListVM.Subscribe();
        }


        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            TodoListVM.Unsubscribe();
        }


        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddTodo", new Tuple<string, Todo>(TodoListVM.Id, Todo));
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

    }
}