using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using CarouselDemo.Custom;
using CarouselDemo.Droid.Renderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

using WebView = Android.Webkit.WebView;

[assembly: ExportRenderer(typeof(CustomWebView), typeof(CustomWebViewRenderer))]
namespace CarouselDemo.Droid.Renderers
{
    public class CustomWebViewRenderer : WebViewRenderer
    {
        static CustomWebView custWebView = null;
        WebView webView;

        public CustomWebViewRenderer(Context context) : base(context)
        {
        }

        class CustomWebViewClient : Android.Webkit.WebViewClient
        {
            public override async void OnPageFinished(WebView view, string url)
            {
                if (custWebView != null)
                {
                    int i = 10;
                    while (view.ContentHeight == 0 && i-- > 0)
                        await System.Threading.Tasks.Task.Delay(100); // The time here can be adjusted

                    custWebView.HeightRequest = view.ContentHeight;
                }

                base.OnPageFinished(view, url);
            }

            public override void OnPageCommitVisible(WebView view, string url)
            {
                base.OnPageCommitVisible(view, url);
            }
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.WebView> e)
        {
            base.OnElementChanged(e);

            custWebView = e.NewElement as CustomWebView;
            webView = Control;

            if (e.OldElement == null)
            {
                webView.SetWebViewClient(new CustomWebViewClient());
            }
        }
    }
}
