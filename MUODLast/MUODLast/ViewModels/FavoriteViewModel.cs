using MUODLast.Models;
using MUODLast.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace MUODLast.ViewModels
{
    public class FavoriteViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public bool IsFavorate { get; set; }

        public ObservableCollection<Drink> FavoriteDrinks { get; set; }
        public FavoriteViewModel()
        {


            FavoriteDrinks = new ObservableCollection<Drink>();
            GetDrinks();
        }


        private async void GetDrinks()
        {
            try
            {
                var drinks = await new FavoriteService().GetFavoriteDrinks();
            FavoriteDrinks.Clear();
            foreach (var drink in drinks)
            {
                FavoriteDrinks.Add(drink);
            }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("error", "No Internet", "OK");
            }
        }
    }
}
