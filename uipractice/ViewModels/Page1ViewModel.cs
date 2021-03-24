using System;
using System.Collections.ObjectModel;
using uipractice.Models;
using Xamarin.Forms;

namespace uipractice.ViewModels
{
    public class Page1ViewModel : BaseViewModel
    {
        public Page1ViewModel(INavigation navigation)
        {
            Title = "Today";
            Navigation = navigation;

            CategoryList = new ObservableCollection<CategoryCard>
            {
                new CategoryCard
                {
                    title = "Burger",
                    image = "https://i.imgur.com/AzLZX2Q.jpg"
                },
                 new CategoryCard
                {
                    title = "Italian",
                    image = "https://cdn.websites.hibu.com/babfba3513224691a5365395a2b54ede/dms3rep/multi/tablet/home-image-880x415.png"
                },
                  new CategoryCard
                {
                    title = "Asian",
                    image = "https://minvghvl4c.followcdn.com/wp-content/uploads/2017/11/Ramen.png"
                },
                      new CategoryCard
                {
                    title = "Brazilian",
                    image = "https://media.danmurphys.com.au/dmo/product/908288-1.png"
                }
            };
        }

        public ObservableCollection<CategoryCard> CategoryList { get; set; }

    }
}
