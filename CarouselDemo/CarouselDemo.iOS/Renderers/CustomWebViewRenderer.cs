using CarouselDemo.iOS;
using WebKit;
using CarouselDemo.Custom;
using CarouselDemo.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomWebView), typeof(CustomWebViewRenderer))]
namespace CarouselDemo.iOS.Renderers
{
    public class CustomWebViewRenderer : WkWebViewRenderer
    {
        CustomWebView webView;

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                webView = Element as CustomWebView;

                this.NavigationDelegate = new NavigationDelegate(webView);
                this.ScrollView.Bounces = false;
                this.ScrollView.ScrollEnabled = false;
            }
        }
    }

    public class NavigationDelegate : WKNavigationDelegate
    {
        CustomWebView wv;
        public NavigationDelegate(CustomWebView wv)
        {
            this.wv = wv;
        }

        public override async void DidFinishNavigation(WKWebView webView, WKNavigation navigation)
        {
            await System.Threading.Tasks.Task.Delay(300);
            wv.HeightRequest = (double)webView.ScrollView.ContentSize.Height;
        }
    }
}
