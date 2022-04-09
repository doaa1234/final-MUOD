using MUOD.Models;
using MUOD.Services;
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

namespace MUOD.ViewModels
{
    public class CategoryDrinksViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public bool IsFavorate { get; set; }

        private DBFirebase Services;

        ObservableCollection<Drink> drinks;
        public ObservableCollection<Drink> Drinks
        {
            get { return drinks; }
            set
            {
                drinks = value;
                OnPropertyChanged();
            }
        }

        ObservableCollection<Drink> categorydrinks;
        public ObservableCollection<Drink> Categorydrinks
        {
            get { return categorydrinks; }
            set
            {
                categorydrinks = value;
                OnPropertyChanged();
            }
        }
        // Note should Rename to selected Drink
        private Categories selectedDrink;
        public Categories SelectedDrink
        {
            get { return selectedDrink; }
            set
            {
                selectedDrink = value;
                OnPropertyChanged();
            }
        }
        public int CatyId { get;set; }
        public string DrinkName { get; set; }

        public CategoryDrinksViewModel()
        {
            Services = new DBFirebase();




           Drinks = Services.getDrinks();

            //Drinks = _Drinks;    
            
            

   
        }
    }
}

