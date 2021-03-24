using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using uipractice.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace uipractice.ViewModels
{
    public class Page2ViewModel : BaseViewModel
    {
        public Page2ViewModel(INavigation navigation)
        {
            Title = "Dream";
            Navigation = navigation;

            DreamCollection = new ObservableCollection<DreamModel>();
        }

        public void OnAppearing()
        {
           
            ExecuteGetDreams();
            
        }

        private bool _isRefreshing = false;
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set
            {
                _isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }

        public Command AppearingCommand => new Command(ExecuteGetDreams);

        public ICommand RefreshCommand
        {
            get
            {
                return new Command(() =>
                {
                    // 리프레시~
                    ExecuteGetDreams();
                });
            }
        }
        
        public ObservableCollection<DreamModel> DreamCollection { get; set; }

        private async void ExecuteGetDreams()
        {
            try
            {
                var connected = _permissionService.CheckNetwork();
                if (connected != NetworkAccess.Internet)
                {
                    await UserDialogs.Instance.AlertAsync("인터넷 연결 실패", "인터넷 연결을 확인해주세요^^", "OK");
                    //await Application.Current.MainPage.DisplayAlert("인터넷 연결 실패", "인터넷 연결을 확인해주세요^^", "OK");
                    return;
                }
                else
                {
                    new Thread(() => GetDreams()).Start();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                await UserDialogs.Instance.AlertAsync("뭔가 이상해", "이상하다구!", "OK");
                //await Application.Current.MainPage.DisplayAlert("뭔가 이상해", "이상하다구!", "OK");
            }
        }

        private void GetDreams()
        {
            IsRefreshing = true;
            using (UserDialogs.Instance.Loading("로딩중..."))
            {
                Thread.Sleep(1000);

                DreamCollection.Clear();

                for (int i = 0; i < 3; i++)
                {
                    DreamCollection.Insert(0, new DreamModel
                    {
                        DreamImage = "https://i.picsum.photos/id/538/200/200.jpg?hmac=oJRLJPsN8ZdWjPpKGEU-oqAZMBKa4JsTnuUSqgRbyP4",
                        DreamText = "Protect myself from Coronavirus Disease 2019"
                    });
                    DreamCollection.Add(new DreamModel
                    {
                        DreamImage = "https://i.picsum.photos/id/108/200/200.jpg?hmac=JbZfKLS2wWv420Eq9HSIstvyiTaniwUcJjhDeOdwc88",
                        DreamText = "Disress/deload (reduce stress on the body and promote recovery"
                    });
                    DreamCollection.Add(new DreamModel
                    {
                        DreamImage = "https://i.picsum.photos/id/114/200/200.jpg?hmac=quI2SDil5gvhyJiPY4KNxdaMtGBybPSvAS7R02lF1vo",
                        DreamText = "Protect myself from Coronavirus Disease 2019"
                    });
                    DreamCollection.Add(new DreamModel
                    {
                        DreamImage = "https://i.picsum.photos/id/1021/200/200.jpg?hmac=5Jzd15OWoPw0fwvsvL05A1BAIN_B543TvjlxqGk1PDU",
                        DreamText = "Protect myself from Coronavirus Disease 2019"
                    });
                    DreamCollection.Add(new DreamModel
                    {
                        DreamImage = "https://i.picsum.photos/id/645/200/200.jpg?hmac=cSCoZuf6WY_fGNCAORxjDRxPwHsSbagPJ1_9SRlugUs",
                        DreamText = "Protect myself from Coronavirus Disease 2019"
                    });
                }
            }

            IsRefreshing = false;

            try
            {
                // Perform click feedback
                //HapticFeedback.Perform(HapticFeedbackType.Click);

                // Or use long press    
                HapticFeedback.Perform(HapticFeedbackType.LongPress);
            }
            catch (FeatureNotSupportedException ex)
            {
                // Feature not supported on device
            }
            catch (Exception ex)
            {
                // Other error has occurred.
            }
        }
    }
}
