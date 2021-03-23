using System;
using CoreGraphics;
using UIKit;
using uipractice.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(TabbedPage), typeof(NTabbedPageRenderer))]
namespace uipractice.iOS.Renderers
{
    public class NTabbedPageRenderer : TabbedRenderer
    {
        readonly nfloat imageYOffset = 7.0f;

        public NTabbedPageRenderer()
        {
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            if (TabBar.Items != null)
            {
                foreach (var item in TabBar.Items)
                {
                    item.Title = null;
                    item.ImageInsets = new UIEdgeInsets(imageYOffset, 0, -imageYOffset, 0);
                }
            }
        }

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                // 상단 보더 지우기
                UITabBar.Appearance.BackgroundImage = new UIImage();
                UITabBar.Appearance.ShadowImage = new UIImage();
                //UITabBar.Appearance.ItemSpacing = UIScreen.MainScreen.Bounds.Width / 5 - 50;
                //SetBorder();
            }
        }

        private void SetBorder()
        {
            // 새로운 보더를 만들자. (색 설정 가능) 
            var view = new UIView(new CGRect(0, 0, TabBar.Frame.Width, 1))
            {
                BackgroundColor = Color.FromRgb(0x00, 0x00, 0x00).ToUIColor(),
                Alpha = (System.nfloat)0.2
            };
            // 새로만든 뷰를 탭바에 추가.
            TabBar.AddSubview(view);
        }
    }
}
