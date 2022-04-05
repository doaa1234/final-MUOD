using System;
using System.Collections.Generic;
using System.Text;
using AppProjectMVVM.Models;
using Xamarin.Forms;
using System.Threading.Tasks;
using AppProjectMVVM.Services;
using Firebase.Database;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using MvvmHelpers;

namespace AppProjectMVVM.ViewModels
{
    public class SignUpPageViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        private DBFirebase Services;
        public Command AddUserCommand { get; }
        private ObservableCollection<SignUpPageModel> _users = new ObservableCollection<SignUpPageModel>();

     

        public ObservableCollection<SignUpPageModel> users
        {
            get { return _users; }
            set
            {
                _users = value;
                OnPropertyChanged();
            }
        }
        public SignUpPageViewModel()
        {
            Services = new DBFirebase();
            users = Services.getPerson();
            AddUserCommand = new Command(async () =>
              await AddUserAsync(Name, Email, Password));
        }

        private async Task AddUserAsync(string name, string email, string password)
        {
           await Services.Addperson(name, email, password);
        }
    }
}
