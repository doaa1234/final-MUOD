using Grid.Model;
using Grid.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Grid.ViewModel
{
    public class CategoriesPageViewModel : BaseViewModel
    {
        public CategoriesPageViewModel()
        {
            drinks = GetDrinks();
        }

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

        private Drink selectedDrink;
        public Drink SelectedDrink
        {
            get { return selectedDrink; }
            set
            {
                selectedDrink = value;
                OnPropertyChanged();
            }
        }

        public ICommand SelectionCommand => new Command(DisplayDrinks);

        private void DisplayDrinks()
        {
            //display the drinks of the category
        }

        private ObservableCollection<Drink> GetDrinks()
        {
            return new ObservableCollection<Drink>
            {
                new Drink { Name = "CLASSIC", Image = "Smoothie.png", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},
                new Drink { Name = "DOUBLE", Image = "smoothie2.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},
                new Drink { Name = "SHARK", Image = "drink3.png", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},
                new Drink { Name = "CHICKEN", Image = "drink4.png", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},
                new Drink { Name = "MEAT", Image = "drink5.png", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"},
                new Drink { Name = "BBQ", Image = "drink6.png", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies"}
            };
        }
    }
}
