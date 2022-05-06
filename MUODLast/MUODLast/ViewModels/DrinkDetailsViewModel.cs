using MUODLast.Models;
using MUODLast.Services;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace MUODLast.ViewModels
{

    public class DrinkDetailsViewModel :BaseViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Id { get; set; }
        public int ParentId { get; set; }
        public bool IsFavorate { get; set; }
        public int RatingValue { get; set; }

        private string _ImageSource;
        public string ImageSource
        {
            get { return _ImageSource; }
            set
            {
                _ImageSource = value;
                OnPropertyChanged();
            }
        }
        private Drink _SelectedDrink;
        public Drink SelectedDrink
        {
            get { return _SelectedDrink; }
            set
            {
                _SelectedDrink = value;
                OnPropertyChanged();
            }
        }
        public ICommand FavoriteCommand => new Command(AddFavorite);
        bool isClicked { get; set; }

        private void AddFavorite()
        {
            if (isClicked == false)
            {
                ImageSource = "heart";
                UpdateFavorite(SelectedDrink.Id, SelectedDrink.Name, SelectedDrink.Description, SelectedDrink.Image, SelectedDrink.RatingValue, SelectedDrink.ParentId, SelectedDrink.IsFavorate, SelectedDrink.Benefits);
            }
            else if (isClicked == true)
            {
                ImageSource = "emptyheart";
                UpdateFavorite(SelectedDrink.Id, SelectedDrink.Name, SelectedDrink.Description, SelectedDrink.Image, SelectedDrink.RatingValue, SelectedDrink.ParentId, SelectedDrink.IsFavorate, SelectedDrink.Benefits);

                isClicked = false;
            }
        }
        public DrinkDetailsViewModel(Drink drink)
        {
            SelectedDrink = drink;

        }


        private async void UpdateFavorite(int id, string Name, string Description, string Image, int RatingValue, int ParentId, bool isFavorite,string benefits)
        {

            await new DrinkDetailsService().UpdateFavoriteById(id, Name, Description, Image, RatingValue, ParentId, isFavorite, benefits);

        }

    }
}
