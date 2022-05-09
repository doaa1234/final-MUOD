using MUODLast.Services;
using MUODLast.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MUODLast.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _Username;
        public string Username
        {
            set
            {
                this._Username = value;
                OnPropertyChanged();
            }
            get
            {
                return this._Username;
            }
        }
        private string _Password;
        public string Password
        {
            set
            {
                this._Password = value;
                OnPropertyChanged();
            }
            get { return this._Password; }
        }

        private bool _IsBusy;
        public bool IsBusy
        {
            set
            {
                this._IsBusy = value;
                OnPropertyChanged();


            }
            get
            {
                return this._IsBusy;
            }
        }
        private bool _Result;
        public bool Result
        {
            set
            {
                this._Result = value;
                OnPropertyChanged();


            }
            get
            {
                return this._Result;
            }
        }



        public Command LoginCommand { get; set; }
        public Command RegisterCommand { get; set; }
        public Command SignupCommand { get; set; }
        public Command ChechConnectivity { get; set; }
        public LoginViewModel()
        {
            // ChechConnectivity();
            // LoginCommand = new Command(async () => await ChechConnectivity());
            LoginCommand = new Command(async () => await LoginCommandAsync());

            RegisterCommand = new Command(async () => await RegisterCommandAsync());
            SignupCommand = new Command(async () => await OnSingup());


        }

        private async Task OnSingup()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new SignUpView());
        }

        private async Task RegisterCommandAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var userService = new UserService();
                Result = await userService.RegisterUser(Username, Password);
                if (Result)
                {
                    await Application.Current.MainPage.DisplayAlert("success", "User registred", "OK");
                    await Application.Current.MainPage.Navigation.PushModalAsync(new LoginView());
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("error", "user alredy exists", "OK");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("error", "No Internet", "OK");
                await Application.Current.MainPage.DisplayAlert("error", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }


        private async Task LoginCommandAsync()
        {


            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var userService = new UserService();
                Result = await userService.LoginUser(Username, Password);
                if (Result)
                {
                    Preferences.Set("Username", Username);
                     Application.Current.MainPage = new AppShell();

                    // var route = $"{nameof(Categories)}";
                    //  await Shell.Current.GoToAsync(route);

                    //catigori
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("error", "invalid username or password", "OK");

                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("error", "No Internet", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
