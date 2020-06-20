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
    public partial class TodoP : ContentPage
    {
        public TodoVM TodoVM { get; set; }

        public TodoP(TodoVM todoVM)
        {
            InitializeComponent();

            BindingContext = this.TodoVM = todoVM;
        }

        public TodoP()
        {
            InitializeComponent();

            var todo = new Todo
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Todo 1",
                Description = "This is an item description"
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            TodoVM.TodoListVM.Subscribe();
        }


        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            TodoVM.TodoListVM.Unsubscribe();
        }

        async void Delete_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "DeleteTodo", TodoVM.Todo.Id);

            await Navigation.PopAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        async void OnDoneToggled(object sender, ToggledEventArgs e)
        {
           // MessagingCenter.Send(this, "ToggleTodoDone", TodoVM.Todo.Id);

            await Navigation.PopAsync();
        }

        private void OnIncreaseQuantity(object sender, EventArgs e)
        {
            TodoVM.Todo.Quantity++;
        }

        private void OnDecreaseQuantity(object sender, EventArgs e)
        {
            TodoVM.Todo.Quantity--;
        }
    }
}