using Firebase.Database;
using Firebase.Database.Query;
using MUOD.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUOD.Services
{
    public class DBFirebase
    {
        FirebaseClient client;

        public DBFirebase()
        {
            client = new FirebaseClient("https://last-a8571-default-rtdb.firebaseio.com/");

        }
        public ObservableCollection<Categories> getCategories()
        {
            var CategoriesData = client
                .Child("Categories")
                .AsObservable<Categories>()
                .AsObservableCollection();

            return CategoriesData;
        }

        public async Task AddCategory(string categoryname, string image, int id)
        {
            Categories categorey = new Categories() { CategoryName = categoryname, Image = image, Id = id };
            await client
                .Child("Categories")
                .PostAsync(categorey);
        }

        public ObservableCollection<Drink> getDrinks()
        {
            
            var CategoreyDrinksData = client
                .Child("Drinks")
                .AsObservable<Drink>()
                .AsObservableCollection();

          //  var x = CategoreyDrinksData.Where(a => a.ParentId == CatyId).ToList();
            /*
            var result = (client).Child("Drinks").AsObservable<Drink>().AsObservableCollection().Where(a => a.ParentId == CatyId).ToList();
            return new ObservableCollection<Drink>(result);*/
            return CategoreyDrinksData;
        }
        /*
        public async Task<ObservableCollection<Drink>> GetDrinks()
        {
            var allDrinks =  getDrinks();
            client.Child("Drinks").OnceAsync<Drink>();
            return allDrinks.Where(a => a.ParentId == 0).FirstOrDefault();
             
        }*/


    }
}

