using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;
using AppProjectMVVM.Models;
using Firebase.Database.Query;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace AppProjectMVVM.Services
{
    public class DBFirebase 
    {
        FirebaseClient person;
        public DBFirebase()
        {
            person = new FirebaseClient("https://projectmuod-default-rtdb.firebaseio.com/");


        }
        public ObservableCollection<SignUpPageModel> getPerson()
        {
            var PersonData = person.Child("Users").AsObservable<SignUpPageModel>().AsObservableCollection();
            return PersonData;
        }
        public async Task Addperson(string name, string email, string password)
        {
            SignUpPageModel c = new SignUpPageModel() { Name = name, Email = email, Password = password };
            await person.Child("Users").PostAsync(c);
        }

      //  public async Task<bool> IsUser(string userEmail, string userPassword)
    //    {
      //      var user=(await person.Child("Users")
     //           .OnceAsync<SignUpPageModel>())
      //          .Where()
       // }
    }
}
