using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Cirrious.MvvmCross.Droid.Views;

namespace ChildFragBug.Views
{
	[Activity (Label = "ChildFragBug", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : MvxActivity
	{
		int count = 1;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Main);
		}
	}
}


