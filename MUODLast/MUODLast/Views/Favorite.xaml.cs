using MUODLast.Models;
using MUODLast.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MUODLast.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Favorite : ContentPage
    {
        public Favorite()
        {
            InitializeComponent();
            BindingContext = new FavoriteViewModel();
        }

        async void CollectionView_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            var selectedDrink = e.CurrentSelection.FirstOrDefault() as Drink;
            if (selectedDrink == null)
                return;


            await Navigation.PushAsync(new DrinkDetails(selectedDrink));

            ((CollectionView)sender).SelectedItem = null;

        }
    }
}