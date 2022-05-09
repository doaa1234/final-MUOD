using Firebase.Database;
using Firebase.Database.Query;
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
    public class DrinkDetailsService
    {
        FirebaseClient client;
        public DrinkDetailsService()
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

        
        public async Task<ObservableCollection<Drink>> GetDrinkById(int DrinkId)
        {
            var DirnkById = new ObservableCollection<Drink>();
            var Drink = (await getDrinksAsync()).Where(d => d.Id == DrinkId).ToList();
            foreach (var drink in Drink)
            {
                DirnkById.Add(drink);
            }
            return DirnkById;
        }

        public async Task UpdateFavoriteById(int id, string name, string description, string image, int ratingValue, int parentId, bool isFavorite, string benefits)
        {
            
            var toUpdateFavorite = (await client
           .Child("Drinks")
           .OnceAsync<Drink>()).Where(a => a.Object.Id == id).FirstOrDefault();

            await client
           .Child("Drinks")
           .Child(toUpdateFavorite.Key)
           .PutAsync(new Drink() { IsFavorate = !isFavorite, Name = name, Description = description, Image = image, RatingValue = ratingValue, Id = id, ParentId = parentId, Benefits = benefits });

        }
        public async Task UpdateRatingById(int id, string name, string description, string image, int ratingValue, int parentId, bool isFavorite)
        {

            var toUpdateFavorite = (await client
           .Child("Drinks")
           .OnceAsync<Drink>()).Where(a => a.Object.Id == id).FirstOrDefault();

            await client
           .Child("Drinks")
           .Child(toUpdateFavorite.Key)
           .PutAsync(new Drink() { IsFavorate = isFavorite, Name = name, Description = description, Image = image, RatingValue = ratingValue, Id = id, ParentId = parentId });

        }
        
    }
}
