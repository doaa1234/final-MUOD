using MUOD.Models;
using MUOD.Services;
using MUOD.Views;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Categories = MUOD.Models.Categories;
using Command = MvvmHelpers.Commands.Command;

namespace MUOD.ViewModels
{
    public class CategoriesViewModel : BaseViewModel
    {
        public string CategoryName { get; set; }
        public string Image { get; set; }
        public int Id { get; set; }
        private DBFirebase Services;

        public Command AddCategoryCommand { get; }
        ObservableCollection<Categories> categories;
        public ObservableCollection<Categories> Categories
        {
            get { return categories; }
            set
            {
                categories = value;
                OnPropertyChanged();
            }
        }

        public CategoriesViewModel()
        {
            Services = new DBFirebase();
            Categories = Services.getCategories();
            AddCategoryCommand = new Command(async () => await addCategory(CategoryName, Image, Id));
        }
       

        public async Task addCategory(string CategoryName, string Image, int Id)
        {
            await Services.AddCategory(CategoryName, Image, Id);
        }


        private Categories selectedCategory;
        public Categories SelectedCategory
        {
            get { return selectedCategory; }
            set
            {
                selectedCategory = value;
                OnPropertyChanged();
            }
        }

        public ICommand SelectionCommand => new Command(DisplayDrinks);

        private void DisplayDrinks()
        {
            //display the drinks of the category
            if (selectedCategory != null)
            {
                int catyId = selectedCategory.Id;
                var viewModel = new CategoryDrinksViewModel { CatyId = catyId };
                var categoryDrinks = new CategoryDrinks { BindingContext = viewModel };

                var navigation = Application.Current.MainPage as NavigationPage;
                navigation.PushAsync(categoryDrinks, true);
            }
        }


    }
}

