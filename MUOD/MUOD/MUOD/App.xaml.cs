using MUOD.Services;
using MUOD.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MUOD
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Categories());

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
