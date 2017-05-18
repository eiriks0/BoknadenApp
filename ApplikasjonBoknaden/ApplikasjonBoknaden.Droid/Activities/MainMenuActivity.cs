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
using ApplikasjonBoknaden.Droid.Fragments;
using RestSharp;
using Newtonsoft.Json;
using Android.Content.PM;

namespace ApplikasjonBoknaden.Droid
{
    //[Activity(Label = "LoginActivity")]
    [Activity(ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainMenuActivity : CustomFragmentActivity
    {

        protected Android.Support.V4.App.Fragment UserPageFragment = null;

        protected Android.Support.V4.App.Fragment NewestFragment = null;
        protected Android.Support.V4.App.FragmentTransaction FT = null;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            ActionBar.Hide();
            SetContentView(Resource.Layout.ActivityMainMenuLayout);
            // ge();

           // AddItems();
            SetButtonValues();

            FT = SupportFragmentManager.BeginTransaction();

            ChangeFragment(new ItemStoreFragment());
            //Call
            //AdNewAdd();
        }


     

        private void ChangeFragment(CostumFragment fragment)
        {
            if (fragment != NewestFragment)
            {
                fragment.SetFragmentActivityCaller(this);
                FT = SupportFragmentManager.BeginTransaction();
               // FT.SetCustomAnimations(Resource.Animation.abc_slide_in_bottom, Resource.Animation.abc_slide_out_bottom, Resource.Animation.abc_slide_in_bottom, Resource.Animation.abc_slide_out_bottom);
                FT.SetCustomAnimations(Resource.Animation.design_bottom_sheet_slide_in, Resource.Animation.design_bottom_sheet_slide_out);
                // UserPageFragment = new ItemStoreFragment();
                FT.Replace(Resource.Id.FragmentHolderMainMenu, fragment, "details_fragment");
                //  ft.SetTransition(Android.Support.V4.App.FragmentTransaction.TransitFragmentFade);
                FT.Commit();
                NewestFragment = fragment;
            }

        }

        /// <summary>
        /// Finds and sets the values on this activities buttons and other views
        /// </summary>
        protected void SetButtonValues()
        {
            Android.Widget.ImageView itemStoreImageButton = FindViewById<Android.Widget.ImageView>(Resource.Id.ItemStoreImage);
            itemStoreImageButton.Touch += (object sender, View.TouchEventArgs e) =>
            {
                if (e.Event.Action == MotionEventActions.Up)
                {
                    itemStoreImageButton.Alpha = 1.0f;
                    ChangeFragment(new ItemStoreFragment());
                }
                if (e.Event.Action == MotionEventActions.Down)
                {
                    itemStoreImageButton.Alpha = 0.4f;
                }
            };

            Android.Widget.ImageView chatPageImageButton = FindViewById<Android.Widget.ImageView>(Resource.Id.ChatPageImage);
            chatPageImageButton.Touch += (object sender, View.TouchEventArgs e) =>
            {
                if (e.Event.Action == MotionEventActions.Up)
                {
                    chatPageImageButton.Alpha = 1.0f;
                    ChangeFragment(new ChatPageFragment());
                }
                if (e.Event.Action == MotionEventActions.Down)
                {
                    chatPageImageButton.Alpha = 0.4f;
                }
            };

            Android.Widget.ImageView UserPageImageButton = FindViewById<Android.Widget.ImageView>(Resource.Id.UserPageImage);
            UserPageImageButton.Touch += (object sender, View.TouchEventArgs e) =>
            {
                if (e.Event.Action == MotionEventActions.Up)
                {
                    UserPageImageButton.Alpha = 1.0f;
                    ChangeFragment(new UserPageActivity());
                }
                if (e.Event.Action == MotionEventActions.Down)
                {
                    UserPageImageButton.Alpha = 0.4f;
                }
            };


            }


 
    }
}