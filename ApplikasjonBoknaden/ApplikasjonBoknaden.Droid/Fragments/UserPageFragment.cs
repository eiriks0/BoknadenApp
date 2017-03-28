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
using ApplikasjonBoknaden.Droid.ViewPageExpanders.ApplikasjonBoknaden.Droid.ViewPageExpanders;
using ApplikasjonBoknaden.Droid.ViewPageExpanders;
using ApplikasjonBoknaden.Droid.DialogFragments;


namespace ApplikasjonBoknaden.Droid
{
    //https://developer.xamarin.com/guides/android/user_interface/viewpager/part-1-viewpager-and-views/
    [Activity(Label = "UserPageActivity")]
    public class UserPageActivity : CostumFragment
    {

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
          
            // Create your fragment here
        }

 

        // protected override int LayoutSetter()
        //  {
        //     return Resource.Layout.UserPageLayout;
        //  }

        protected override int Layout()
        {
            return Resource.Layout.FragmentUserPageLayout;
        }

        protected override void InitiateFragment()
        {

            ViewPager viewPager = Fragmentview.FindViewById<ViewPager>(Resource.Id.viewpager);
            TreeCatalog treeCatalog = new TreeCatalog();
            viewPager.Adapter = new TreePagerAdapter(this.Context, treeCatalog);

        }

   //     protected override void OnCreate(Bundle savedInstanceState)
     //   {
       //     base.OnCreate(savedInstanceState);
       //     SetContentView(Resource.Layout.UserPageLayout);

        //    ViewPager viewPager = FindViewById<ViewPager>(Resource.Id.viewpager);
         //   TreeCatalog treeCatalog = new TreeCatalog();
         //   viewPager.Adapter = new TreePagerAdapter(this, treeCatalog);

            // Create your application here
      //  }
    }
}