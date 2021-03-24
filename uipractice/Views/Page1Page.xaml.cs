using System;
using System.Collections.Generic;
using Acr.UserDialogs;
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

        protected override void OnAppearing()
        {
            base.OnAppearing();

            UserDialogs.Instance.Toast(new ToastConfig("hello i'm Nathan.")
                .SetDuration(TimeSpan.FromSeconds(3))
                .SetPosition(ToastPosition.Top)
                .SetAction(x => x
                    .SetText("OK")
                    .SetAction(() => UserDialogs.Instance.Alert("You clicked the primary toast button"))
                )
            );
        }
    }
}
