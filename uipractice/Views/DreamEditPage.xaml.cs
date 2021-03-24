using System;
using System.Collections.Generic;
using uipractice.Models;
using uipractice.ViewModels;
using Xamarin.Forms;

namespace uipractice.Views
{
    public partial class DreamEditPage : ContentPage
    {
        public DreamEditPage(DreamModel dreamModel)
        {
            InitializeComponent();
            BindingContext = dreamModel;
        }
    }
}
