using System;
using System.Collections.Generic;
using uipractice.ViewModels;
using Xamarin.Forms;

namespace uipractice.Views
{
    public partial class Page1Page : ContentPage
    {
        public Page1Page()
        {
            InitializeComponent();
            BindingContext = new Page1ViewModel(Navigation);
        }
    }
}
