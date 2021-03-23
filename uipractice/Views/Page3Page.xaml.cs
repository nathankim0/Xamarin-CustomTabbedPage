using System;
using System.Collections.Generic;
using uipractice.ViewModels;
using Xamarin.Forms;

namespace uipractice.Views
{
    public partial class Page3Page : ContentPage
    {
        public Page3Page()
        {
            InitializeComponent();
            BindingContext = new Page3ViewModel(Navigation);
        }
    }
}
