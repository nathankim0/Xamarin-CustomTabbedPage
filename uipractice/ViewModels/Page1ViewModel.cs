using System;
using Xamarin.Forms;

namespace uipractice.ViewModels
{
    public class Page1ViewModel : BaseViewModel
    {
        public Page1ViewModel(INavigation navigation)
        {
            Title = "Today";
            Navigation = navigation;
        }
    }
}
