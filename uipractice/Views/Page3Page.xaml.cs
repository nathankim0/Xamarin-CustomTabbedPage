using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Acr.UserDialogs;
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

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var cancelled = false;
            using (var dlg = UserDialogs.Instance.Progress("Test Progress", () => cancelled = true))
            {
                while (!cancelled && dlg.PercentComplete < 100)
                {
                    await Task.Delay(TimeSpan.FromMilliseconds(500));
                    dlg.PercentComplete += 2;
                }
            }
            UserDialogs.Instance.Alert(cancelled ? "Progress Cancelled" : "Progress Complete");
        }
    }
}
