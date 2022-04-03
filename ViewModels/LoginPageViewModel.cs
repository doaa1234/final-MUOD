using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppProjectMVVM.ViewModels
{
    public class LoginPageViewModel : INotifyPropertyChanged
    {
        private string _errorMessage;
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



    }
}
