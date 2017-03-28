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

using System.Net;
using System.IO;
using System.Diagnostics;
using System.Net.Http;
using System.Timers;
using Android.Support.V4.App;
using ApplikasjonBoknaden.Droid.DialogFragments;

namespace ApplikasjonBoknaden.Droid
{
    [Activity(Label = "LoginActivity")]
    public class MainMenuActivity : CustomFragmentActivity
    {

        protected Android.Support.V4.App.Fragment UserPageFragment = null;

        protected Android.Support.V4.App.Fragment NewestFragment = null;
        protected Android.Support.V4.App.FragmentTransaction FT = null;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.FragmentActivityLayout);
            // ge();

           // AddItems();
            SetButtonValues();

            FT = SupportFragmentManager.BeginTransaction();

            ChangeFragment(new ItemStoreFragment());
        }

        private void ChangeFragment(CostumFragment fragment)
        {
            fragment.SetFragmentActivityCaller(this);
            FT = SupportFragmentManager.BeginTransaction();

            FT.SetCustomAnimations(Resource.Animation.abc_slide_in_bottom, Resource.Animation.abc_slide_out_top);
            // UserPageFragment = new ItemStoreFragment();
            FT.Replace(Resource.Id.FragmentHolderMainMenu, fragment, "details_fragment");
            //  ft.SetTransition(Android.Support.V4.App.FragmentTransaction.TransitFragmentFade);
            FT.Commit();
            NewestFragment = fragment;
        }

        /// <summary>
        /// Finds and sets the values on this activities buttons and other views
        /// </summary>
        protected void SetButtonValues()
        {
            Android.Widget.ImageButton itemStoreImageButton = FindViewById<Android.Widget.ImageButton>(Resource.Id.ItemStoreImageButton);
            itemStoreImageButton.Click += delegate {
                ChangeFragment(new ItemStoreFragment());
                Toast.MakeText(this, "Item", ToastLength.Long).Show();
            };

            Android.Widget.ImageButton UserPageImageButton = FindViewById<Android.Widget.ImageButton>(Resource.Id.UserPageImageButton);
            UserPageImageButton.Click += delegate {
                ChangeFragment(new UserPageActivity());
                Toast.MakeText(this, "User", ToastLength.Long).Show();
            };


            }


 
    }
}