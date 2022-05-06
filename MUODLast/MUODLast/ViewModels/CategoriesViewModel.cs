using MUODLast.Models;
using MUODLast.Services;
using MUODLast.Views;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Category = MUODLast.Models.Category;
using Command = MvvmHelpers.Commands.Command;

namespace MUODLast.ViewModels
{
    public class CategoriesViewModel : BaseViewModel
    {
        public string CategoryName { get; set; }
        public string Image { get; set; }
        public int Id { get; set; }
        public ObservableCollection<Category> Categories { get; set; }
  
        public CategoriesViewModel()
        {
            Categories = new ObservableCollection<Category>();
            GetCategories();
        }

        private async void GetCategories()
        {
            try
            {
                var categories = await new CategoriesService().GetCategoriesAsync();
            Categories.Clear();
            foreach (var category in categories)
            {
                Categories.Add(category);
            }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("error", "No Internet", "OK");
            }
            
        }
    }
}

