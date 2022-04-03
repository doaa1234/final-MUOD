using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppProjectMVVM.Views;

namespace AppProjectMVVM
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MinPageView();
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
