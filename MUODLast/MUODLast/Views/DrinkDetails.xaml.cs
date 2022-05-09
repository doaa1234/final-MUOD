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
    public partial class DrinkDetails : ContentPage
    {
        DrinkDetailsViewModel ddvm;
        public DrinkDetails(Drink drink)
        {
            ddvm = new DrinkDetailsViewModel(drink);
            this.BindingContext = ddvm;
            InitializeComponent();
        }

        
        /*
private void ShowButton_Clicked(object sender, EventArgs e)
{
   int rating = Rating.SelectedStarValue = 3;
   DisplayAlert("Rating Value", rating.ToString(), "Ok");
}*/
    }
}