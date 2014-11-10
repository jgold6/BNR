using System;
using Android.App;
using Android.Widget;
using Android.Views;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Android.Graphics;
using Android.Util;
using Android.Preferences;
using Android.OS;
using Android.Content;
using Android.Webkit;

namespace PhotoGallery
{
	public class PhotoPageFragment : VisibleFragment
    {
		private static readonly string TAG = "PhotoPageFragment";
        
		string mUrl;
		WebView mWebView;
		ProgressBar progressBar;
		TextView titleTextView;

		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			RetainInstance = true;
			// Create your fragment here
			mUrl = Activity.Intent.Data.ToString();
		}

		public override Android.Views.View OnCreateView(Android.Views.LayoutInflater inflater, Android.Views.ViewGroup container, Android.OS.Bundle savedInstanceState)
		{
//			Console.WriteLine("[{0}] OnCreateView Called: {1}", TAG, DateTime.Now.ToLongTimeString());
			View v = inflater.Inflate(Resource.Layout.fragment_photo_page, container, false);

			progressBar = (ProgressBar)v.FindViewById(Resource.Id.progressBar);
			progressBar.Max = 100;
			titleTextView = (TextView)v.FindViewById(Resource.Id.titleTextView);

			mWebView = v.FindViewById<WebView>(Resource.Id.webView);

			mWebView.Settings.JavaScriptEnabled = true;

			mWebView.SetWebViewClient(new PhotoWebViewClient());

			mWebView.SetWebChromeClient(new PhotoWebChromeClient(this));

			mWebView.LoadUrl(mUrl);

			return v;
		}

		public void UpdateProgress(int progress)
		{
			if (progress == 100) {
				progressBar.Visibility = ViewStates.Invisible;
			}
			else {
				progressBar.Visibility = ViewStates.Visible;
				progressBar.Progress = progress;
			}
		}
		public void UpdateTitle(string title)
		{
			titleTextView.Text = title;
		}

    }

	public class PhotoWebViewClient : WebViewClient
	{
		public override bool ShouldOverrideUrlLoading(WebView view, string url)
		{
			return false;
		}
	}

	public class PhotoWebChromeClient : WebChromeClient
	{
		PhotoPageFragment fragment;

		public PhotoWebChromeClient(PhotoPageFragment frag)
		{
			fragment = frag;
		}

		public override void OnProgressChanged(WebView view, int newProgress)
		{
			fragment.UpdateProgress(newProgress);
		}
		public override void OnReceivedTitle(WebView view, string title)
		{
			fragment.UpdateTitle(title);
		}
	}
}

