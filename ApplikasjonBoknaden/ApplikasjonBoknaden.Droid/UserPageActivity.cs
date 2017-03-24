using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V4.View;
using ApplikasjonBoknaden.Droid.TreePager;
using TreePager;

namespace ApplikasjonBoknaden.Droid
{
    //https://developer.xamarin.com/guides/android/user_interface/viewpager/part-1-viewpager-and-views/
    [Activity(Label = "UserPageActivity")]
    public class UserPageActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.UserPageLayout);

            ViewPager viewPager = FindViewById<ViewPager>(Resource.Id.viewpager);
            TreeCatalog treeCatalog = new TreeCatalog();
            viewPager.Adapter = new TreePagerAdapter(this, treeCatalog);

            // Create your application here
        }
    }
}