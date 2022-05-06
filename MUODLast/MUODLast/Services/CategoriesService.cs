using Firebase.Database;
using Firebase.Database.Query;
using MUODLast.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MUODLast.Services
{
    public class CategoriesService
    {
        FirebaseClient client;

        public CategoriesService()
        {
            try
            {
                client = new FirebaseClient("https://last-muod-default-rtdb.firebaseio.com/");
            }
            catch (Exception ex)
            {
                 Application.Current.MainPage.DisplayAlert("error", "No Internet", "OK");
            }
        }
       
         
        public async Task<List<Category>> GetCategoriesAsync()
        {

            var Categories = (await client.Child("Categories").OnceAsync<Category>()).Select(C => new Category
            {
             CategoryName = C.Object.CategoryName,
             Id = C.Object.Id,
             Image = C.Object.Image,
            }).ToList();

            return Categories;
        }

    }
}

