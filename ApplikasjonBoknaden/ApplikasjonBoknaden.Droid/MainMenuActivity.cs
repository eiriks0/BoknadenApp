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
    public class MainMenuActivity : FragmentActivity
    {

        protected TakePictureFragment takePictureFragment = null;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            // ge();

            AddItems();
            SetButtonValues();

        }

        /// <summary>
        /// Finds and sets the values on this activities buttons and other views
        /// </summary>
        protected void SetButtonValues()
        {
            ImageView userPageImage = FindViewById<ImageView>(Resource.Id.UserPageImageButton);
            userPageImage.Touch += (object sender, View.TouchEventArgs e) =>
            {
                if (e.Event.Action == MotionEventActions.Up)
                {
                    userPageImage.Alpha = 1.0f;
                    StartActivity(typeof(UserPageActivity));

                    Toast.MakeText(this, "Key Up", ToastLength.Short).Show();
                }
                if (e.Event.Action == MotionEventActions.Down)
                {
                    userPageImage.Alpha = 0.4f;
                    Toast.MakeText(this, "Key Down", ToastLength.Short).Show();
                }
            };


            Android.Widget.ImageButton newAdImageButton = FindViewById<Android.Widget.ImageButton>(Resource.Id.NewAdImageButton);
            ImageView iv =  FindViewById<ImageView> (Resource.Id.SettingsImage);

            iv.Click += RadioButtonClick;
            iv.Touch += (object sender, View.TouchEventArgs e) =>
            {
                if (e.Event.Action == MotionEventActions.Up)
                {
                    iv.Alpha = 1.0f;
                    StartActivity(typeof(SearchFilterActivity));
                
                    Toast.MakeText(this, "Key Up", ToastLength.Short).Show();
                }
                if (e.Event.Action == MotionEventActions.Down)
                {
                    iv.Alpha = 0.4f;
                    Toast.MakeText(this, "Key Down", ToastLength.Short).Show();
                }
            };

            newAdImageButton.Click += delegate {
                takePictureFragment = new DialogFragments.TakePictureFragment();
                takePictureFragment.Show(SupportFragmentManager, "dialog", this, this);
                //  var dialog = new DialogFragments.AddNewBookFirstFragment();
                //  dialog.Show(SupportFragmentManager, "dialog", this);
                //  StartActivity(typeof(ISBNScanActivity));
            };
        }

        private void RadioButtonClick(object sender, EventArgs e)
        {
            ImageView rb = (ImageView)sender;
           // rb.Alpha = 0.4f;
            rb.ImageAlpha = 0;


            if (rb.Pressed)
            {
              //  rb.Alpha = 0.4f;

          //       Toast.MakeText(this, "yo", ToastLength.Short).Show();
            }
            else
            {
          //      rb.Alpha = 1.0f;
            }

           // Toast.MakeText(this, rb.Text, ToastLength.Short).Show();
          //  SaveSortByRadioButons();
        }

        private void AddItems()
        {
            // var webClient = new WebClient();
            // var json = new WebClient().DownloadString("url");

          //  using (WebClient wc = new WebClient())
          //  {
          //      var json = wc.DownloadString("http://146.185.164.20:57483/ping");
           // }

            Android.Widget.ScrollView s = FindViewById<Android.Widget.ScrollView>(Resource.Id.scrollView2);
            GridLayout g = FindViewById<GridLayout>(Resource.Id.tableLayout1);
            //Makes the scrollview fit the screen with the given floatvalue 
            LinearLayout.LayoutParams scrollParams = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent, 2.0f);
            s.LayoutParameters = scrollParams;


            ImageButton[] btnGreen = new ImageButton[6];

            Android.Widget.RelativeLayout[] lLL = new Android.Widget.RelativeLayout[6];

            for (int i = 0; i < 6; i++)
            {

                lLL[i] = new Android.Widget.RelativeLayout(this);
                //  lLL[i].Orientation = Orientation.Vertical;
                Android.Widget.RelativeLayout.LayoutParams width = new Android.Widget.RelativeLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
                Android.Widget.RelativeLayout.LayoutParams height = new Android.Widget.RelativeLayout.LayoutParams(width.Width, 400);
                lLL[i].LayoutParameters = height;
                //textbox3.setLayoutParams(width);


                // l.LayoutParameters = new TableLayout.LayoutParams(, LayoutParams.WRAP_CONTENT, 1f);


                TextView t = new TextView(this);

                ImageView iv = new ImageView(this);
                iv.SetImageResource(Resource.Drawable.design_fab_background);
                t.Text = "Databaser og krig: Pris: 250kr";
                t.SetTextColor(Android.Graphics.Color.White);
                btnGreen[i] = new ImageButton(this);
                lLL[i].AddView(btnGreen[i]);
                lLL[i].AddView(t);
                lLL[i].AddView(iv);
                // btnGreen[i].SetImageResource(R.drawable.bola_verde);
                Android.Widget.RelativeLayout.LayoutParams heightb = new Android.Widget.RelativeLayout.LayoutParams(width.Width, ViewGroup.LayoutParams.MatchParent);
                btnGreen[i].LayoutParameters = heightb;
                //  btnGreen[i].SetOnClickListener(ClickListener);
                //  btnGreen[i].SetBackgroundColor(Android.Graphics.Color.Transparent);
                //  btnGreen[i].SetTag(i);
                // btnGreen[i].SetId(i);
                //  gridView.AddView(lLL[i]);
                g.AddView(lLL[i]);


            }
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            // Make it available in the gallery

            Intent mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
            Android.Net.Uri contentUri = Android.Net.Uri.FromFile(App._file);
            mediaScanIntent.SetData(contentUri);
            SendBroadcast(mediaScanIntent);

            // Display in ImageView. We will resize the bitmap to fit the display.
            // Loading the full sized image will consume to much memory
            // and cause the application to crash.

            int height = Resources.DisplayMetrics.HeightPixels;
            int width = takePictureFragment._imageView.Height;
            App.bitmap = App._file.Path.LoadAndResizeBitmap(width, height);
            if (App.bitmap != null)
            {
                takePictureFragment._imageView.SetImageBitmap(App.bitmap);
                App.bitmap = null;
            }

            // Dispose of the Java side bitmap.
            GC.Collect();
        }
    }
}