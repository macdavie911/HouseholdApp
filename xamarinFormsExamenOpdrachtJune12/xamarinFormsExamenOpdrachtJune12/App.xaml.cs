using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xamarinFormsExamenOpdrachtJune12.Services;
using xamarinFormsExamenOpdrachtJune12.Views;

namespace xamarinFormsExamenOpdrachtJune12
{
   

    public partial class App : Application
    {
        

        public App()
        {
            InitializeComponent();

            DependencyService.Register<Store>();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
