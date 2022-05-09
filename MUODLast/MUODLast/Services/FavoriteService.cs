using Firebase.Database;
using MUODLast.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MUODLast.Services
{
    public class FavoriteService
    {
        FirebaseClient client;

        public FavoriteService()
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
        public async Task<List<Drink>> getDrinksAsync()
        {

            var AllDrinks = (await client.Child("Drinks").OnceAsync<Drink>()).Select(d => new Drink
            {
                Id = d.Object.Id,
                Name = d.Object.Name,
                Description = d.Object.Description,
                Image = d.Object.Image,
                ParentId = d.Object.ParentId,
                IsFavorate = d.Object.IsFavorate,
                Benefits = d.Object.Benefits,
            }).ToList();

            return AllDrinks;
        }

        public async Task<ObservableCollection<Drink>> GetFavoriteDrinks()
        {
            var FavoriteDrinks = new ObservableCollection<Drink>();
            var Drinks = (await getDrinksAsync()).Where(a => a.IsFavorate == true).ToList();
            foreach (var drink in Drinks)
            {
                FavoriteDrinks.Add(drink);
            }
            return FavoriteDrinks;
        }
    }
}
