
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
using Cirrious.MvvmCross.Droid.FullFragging.Fragments;
using Cirrious.MvvmCross.Binding.Droid.BindingContext;

namespace ChildFragBug.Views
{
	public class ParentFragmentView : MvxFragment
	{
		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			var ignore = base.OnCreateView (inflater, container, savedInstanceState);
			var view = this.BindingInflate(Resource.Layout.ParentFragment, null, false);

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

