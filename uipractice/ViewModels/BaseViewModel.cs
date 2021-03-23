using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Essentials;
using Xamarin.Forms;
using static uipractice.App;

namespace uipractice.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private string _title { get; set; }
        public INavigation Navigation { get; set; }
        public PermissionService _permissionService;

        public BaseViewModel()
        {
            _permissionService = new PermissionService();
            Connectivity.ConnectivityChanged += ConnectivityOnConnectivityChanged;
            IsNotConnected = Connectivity.NetworkAccess != NetworkAccess.Internet;
        }

        ~BaseViewModel()
        {
            Connectivity.ConnectivityChanged -= ConnectivityOnConnectivityChanged;
        }

        private void ConnectivityOnConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            IsNotConnected = e.NetworkAccess != NetworkAccess.Internet;
        }

        private bool _isNotConnected { get; set; }
        public bool IsNotConnected
        {
            get => _isNotConnected;
            set
            {
                _isNotConnected = value;
                OnPropertyChanged();
            }
        }

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}