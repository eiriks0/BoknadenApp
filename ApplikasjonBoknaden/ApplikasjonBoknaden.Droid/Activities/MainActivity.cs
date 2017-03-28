using System;
using System.Collections;
using System.Collections.Generic;

using Xamarin.Forms;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics;
using System.IO;

namespace ApplikasjonBoknaden.Droid
{
    // "NoHistory = true" prevents the user to get back to this activity when they press back on their phone
    [Activity (NoHistory = true, Label = "ApplikasjonBoknaden.Droid", MainLauncher = true, Icon = "@drawable/icon")]

	public class MainActivity : Activity
	{
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            ActionBar.Hide();



          //  SavedValues.UserValues.saveStringPrefs("Header", s, sPEditor);
            //System.Diagnostics.Debug.WriteLine(SavedValues.UserValues.getStringPrefs("Header", sP));

         //   if (s != SavedValues.UserValues.getStringPrefs("Header"))
         //   {

         //   }

            //   if (!UserValues.GetUserIsLogedInn())
            //    {
            StartActivity(typeof(LoginActivity));
            //   } else
            //  {
            //      StartActivity(typeof(MainMenuActivity));
            //  }
        }
	}
}


