﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppProjectMVVM.ViewModels;

namespace AppProjectMVVM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoriesDetailsPageView : ContentPage
    {
        public CategoriesDetailsPageView()
        {
            InitializeComponent();
            BindingContext = new CategoriesDetailsPageViewModel();
        }
    }
}