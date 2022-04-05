using AppProjectMVVM.Services;
using AppProjectMVVM.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AppProjectMVVM.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        private string _Useremail;
        public string Useremail
        {
            get
            {
                return this._Useremail;
            }
            set
            {
                this._Useremail = value;
                OnPropertyChanged();
            }

        }

        private string _Password;
        public string Password
        {  
            get
            {
                return this._Password;
            }
            set
            {
                this._Password = value;
                OnPropertyChanged();
            }

        }

        private bool _Result;
        public bool Result
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
        private bool _IsBusy;
        public bool IsBusy
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
        public Command SignUpCommand { get; set; }

        public LoginPageViewModel()
        {
            LoginCommand = new Command(async () => await LoginCommandAsync());
            SignUpCommand = new Command(async () => await RegisterCommandAsync());
        }



        private async Task RegisterCommandAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var userService = new UserService();
                Result = await userService.RegisterUser(Useremail, Password);
                if (Result)
                    await Application.Current.MainPage.DisplayAlert("Success", "Registered User", "Ok");
                else
                    await Application.Current.MainPage.DisplayAlert("Error", "Failed to register user", "Ok");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
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
                Result = await userService.LoginUser(Useremail, Password);
                if (Result)
                {
                    Preferences.Set("Useremail", Useremail);
                    await Application.Current.MainPage.Navigation.PushAsync(new MinPageView());
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Invalid Email/Password(s)", "Ok");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
            }
            finally
            {
                IsBusy = false;
            }
        }









        /* private string _errorMessage;
         private Color _PageColor;

         public event PropertyChangedEventHandler PropertyChanged;

         public string ErrorMessage
         {
             get { return this._errorMessage; }
             set
             {
                 this._errorMessage = value;
                 PropertyChanged(this, new PropertyChangedEventArgs("ErrorMessage"));
             }
         }
         public Color PageColor
         {
             get { return _PageColor; }
             set {
                 _PageColor = value;
                 PropertyChanged(this, new PropertyChangedEventArgs("PageColor"));

             }

         }
         public string Email { get; set; }
         public string Password { get; set; }

         public ICommand LoginCommand { get; set; }
         public LoginPageViewModel()
         {
             LoginCommand = new Command(() => Login());
         }

         private void Login()
         {
             if(string.IsNullOrEmpty(Email))
             {
                 ErrorMessage = "Email is Empty";
                 PageColor = Color.LightPink;
             }
             else if(string.IsNullOrEmpty(Password))
             {
                 ErrorMessage = "Password is Empty";
                 PageColor = Color.LightPink;

             }
             else
             {
                 PageColor = Color.LightGreen;
                 ErrorMessage = String.Empty;
                 App.Current.MainPage.DisplayAlert("Welcom", "Hey" + Email, "ok");

             }

         }
        */



    }
}
