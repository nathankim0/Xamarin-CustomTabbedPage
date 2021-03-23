using System;
using System.Collections.Generic;
using System.Linq;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Views;
using Android.Widget;
using Google.Android.Material.BottomNavigation;
using uipractice.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(TabbedPage), typeof(NTabbedPageRenderer))]
namespace uipractice.Droid.Renderers
{
    public class NTabbedPageRenderer : TabbedPageRenderer
    {
        //private BottomNavigationView _bottomNavigationView;

        public NTabbedPageRenderer(Context context) : base(context)
        {
        }

        
        protected override void OnElementChanged(ElementChangedEventArgs<TabbedPage> e)
        {
            base.OnElementChanged(e);

            var childViews = GetAllChildViews(ViewGroup);

            var scale = Resources.DisplayMetrics.Density;
            var paddingDp = 9;
            var dpAsPixels = (int)(paddingDp * scale + 0.5f);

            //if (e.NewElement != null)
            //{
            //    _bottomNavigationView = ((Android.Widget.RelativeLayout)GetChildAt(0)).GetChildAt(1) as BottomNavigationView;
            //}

            foreach (var childView in childViews)
            {
                if (childView is BottomNavigationItemView tab)
                {
                    tab.SetPadding(tab.PaddingLeft, dpAsPixels, tab.PaddingRight, tab.PaddingBottom);
                }
                else if (childView is TextView textView)
                {
                    textView.SetTextColor(Android.Graphics.Color.Transparent);
                }
            }
        }

        List<Android.Views.View> GetAllChildViews(Android.Views.View view)
        {
            if (!(view is ViewGroup group))
            {
                return new List<Android.Views.View> { view };
            }

            var result = new List<Android.Views.View>();

            for (int i = 0; i < group.ChildCount; i++)
            {
                var child = group.GetChildAt(i);

                var childList = new List<Android.Views.View> { child };
                childList.AddRange(GetAllChildViews(child));

                result.AddRange(childList);
            }

            return result.Distinct().ToList();
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);
            //// Create a Gradient Stroke as the new top border. (Set alpha if needed.)
            //GradientStrokeDrawable topBorderLine = new GradientStrokeDrawable { Alpha = 0x33 };
            //// Change it to the color you want.
            //topBorderLine.SetStroke(1, Color.FromRgb(0x00, 0x00, 0x00).ToAndroid());
            //LayerDrawable layerDrawable = new LayerDrawable(new Drawable[] { topBorderLine });
            //layerDrawable.SetLayerInset(0, 0, 0, 0, _bottomNavigationView.Height - 2);
            //_bottomNavigationView.SetBackground(layerDrawable);
        }


    }
}
