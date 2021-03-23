using System;
using System.Collections.Generic;
using uipractice.ViewModels;
using Xamarin.Forms;

namespace uipractice.Views
{
    public partial class Page2Page : ContentPage
    {
        public Page2Page()
        {
            InitializeComponent();
            BindingContext = new Page2ViewModel(Navigation);
        }

        void DreamListView_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            (sender as ListView).SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (!(BindingContext is Page2ViewModel viewModel)) return;

            viewModel.OnAppearing();
        }
    }
}
