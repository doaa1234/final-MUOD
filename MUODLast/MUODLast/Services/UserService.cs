using Firebase.Database;
using Firebase.Database.Query;
using MUODLast.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUODLast.Services
{
    public class UserService
    {
        FirebaseClient client;

        public UserService()
        {
            client = new FirebaseClient("https://last-muod-default-rtdb.firebaseio.com/");

        }

        public async Task<bool> IsUserExists(string uname)
        {
            var user = (await client.Child("Users")
                .OnceAsync<User>()).Where(a => a.Object.Username == uname).FirstOrDefault();
            return (user != null);

        }

        public async Task<bool> RegisterUser(string uname, string password)
        {
            if (await IsUserExists(uname) == false)
            {
                await client.Child("Users").PostAsync(new User()
                {
                    Username = uname,
                    Password = password

                });
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> LoginUser(string uname, string password)
        {
            var user = (await client.Child("Users")
                .OnceAsync<User>()).Where(a => a.Object.Username == uname)
                .Where(a => a.Object.Password == password).FirstOrDefault();
            return (user != null);

        }

    }
}
