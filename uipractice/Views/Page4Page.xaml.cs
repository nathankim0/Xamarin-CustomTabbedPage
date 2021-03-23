using System;
using System.Collections.Generic;
using uipractice.ViewModels;
using Xamarin.Forms;

namespace uipractice.Views
{
    public partial class Page4Page : ContentPage
    {
        public Page4Page()
        {
            InitializeComponent();
            BindingContext = new Page4ViewModel(Navigation);
        }
    }
}
