using MUODLast.Services;
using MUODLast.Models;
using MUODLast.Views;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Command = MvvmHelpers.Commands.Command;


namespace MUODLast.ViewModels
{
    public class CategoryDrinksViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public bool IsFavorate { get; set; }

     
        private Category _SelectedCategory;
        public Category SelectedCategory
        {
             get { return _SelectedCategory; }
            set
            {
                _SelectedCategory = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Drink> DrinksByCategory { get; set; }
        public CategoryDrinksViewModel(Category category)
        {
            SelectedCategory = category;
            DrinksByCategory = new ObservableCollection<Drink>();
            GetDrinks(category.Id);
        }
       

        private async void GetDrinks(int CatId)
        {
            try
            {
                var drinks = await new CategoryDrinksService().GetDrinksByCatygoryId(CatId);
                DrinksByCategory.Clear();
                foreach (var drink in drinks)
                {
                    DrinksByCategory.Add(drink);
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("error", "No Internet", "OK");
            }
        }

    
    }
}

