using System;
using System.Collections.Generic;
using uipractice.ViewModels;
using Xamarin.Forms;

namespace uipractice.Views
{
    public partial class Page5Page : ContentPage
    {
        public Page5Page()
        {
            InitializeComponent();
            BindingContext = new Page5ViewModel(Navigation);
        }
    }
}
