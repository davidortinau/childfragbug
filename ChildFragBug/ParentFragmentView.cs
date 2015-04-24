
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace ChildFragBug
{
	public class ParentFragmentView : Fragment
	{
		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your fragment here
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			var ignore = base.OnCreateView (inflater, container, savedInstanceState);
			var view = inflater.Inflate(Resource.Layout.ParentFragment, null, false);

			var textView = (TextView)view.FindViewById(Resource.Id.HeadlineText);

			var childFrag = (ChildFragmentView)ChildFragmentManager.FindFragmentById(Resource.Id.ChildFragmentView);
			if(childFrag == null){
				textView.Text = "Ugh, ChildFragmentManager can't find the subview.";
			}else{
				textView.Text = "ChildFragmentManager found the child frag.";
			}

			var childFragAgain = (ChildFragmentView)FragmentManager.FindFragmentById(Resource.Id.ChildFragmentView);
			if(childFragAgain != null){
				textView.Text += " BUT FragmentManager can.";
			}else{
				textView.Text += " FragmentManager found the child frag.";
			}


			return view;
		}
	}
}

