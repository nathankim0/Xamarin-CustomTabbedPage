using System;
using uipractice.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace uipractice
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainTabbedPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        public class PermissionService : IPermissionService
        {
            public NetworkAccess CheckNetwork()
            {
                return Connectivity.NetworkAccess;
            }
        }

        public interface IPermissionService
        {
            NetworkAccess CheckNetwork();
        }
    }
}
