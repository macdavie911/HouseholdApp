using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xamarinFormsExamenOpdrachtJune12.Models;

namespace xamarinFormsExamenOpdrachtJune12.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewTodoListP : ContentPage
    {
        public TodoList TodoList { get; set; }

        public NewTodoListP()
        {
            InitializeComponent();

            TodoList = new TodoList
            {
                Title = "Title",
                Todos = new List<Todo>()
            };

            BindingContext = this;
        }
        
        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddTodoList", TodoList);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}