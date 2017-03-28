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

namespace ApplikasjonBoknaden.Droid.DialogFragments
{
    public class ItemStoreFragment : CostumFragment
    {
      //  protected TakePictureFragment takePictureFragment = null;

        protected override int Layout()
        {
            return Resource.Layout.FragmentItemStoreLayout;
        }

        protected override void SetButtonValues()
        {
            ImageView iv = Fragmentview.FindViewById<ImageView>(Resource.Id.SettingsImage);
            iv.Touch += (object sender, View.TouchEventArgs e) =>
            {
                if (e.Event.Action == MotionEventActions.Up)
                {
                    iv.Alpha = 1.0f;
                   // StartActivity(typeof(SearchFilterActivity));

               //     Toast.MakeText(Context, "Key Up", ToastLength.Short).Show();
                }
                if (e.Event.Action == MotionEventActions.Down)
                {
                    iv.Alpha = 0.4f;
                  //  Toast.MakeText(Context, "Key Down", ToastLength.Short).Show();
                }
            };

            ImageView iv2 = Fragmentview.FindViewById<ImageView>(Resource.Id.AddNewItemImage);
            iv2.Touch += (object sender, View.TouchEventArgs e) =>
            {
                if (e.Event.Action == MotionEventActions.Up)
                {
                    iv2.Alpha = 1.0f;

                    FragmentActivityCaller.takePictureFragment = new DialogFragments.TakePictureFragment();
                    FragmentActivityCaller.takePictureFragment.Show(FragmentActivityCaller.SupportFragmentManager, "dialog", FragmentActivityCaller);

                }
                if (e.Event.Action == MotionEventActions.Down)
                {
                    iv2.Alpha = 0.4f;
                    //  Toast.MakeText(Context, "Key Down", ToastLength.Short).Show();
                }
            };

          //  Android.Widget.ImageButton newAdImageButton = Fragmentview.FindViewById<Android.Widget.ImageButton>(Resource.Id.NewAdImageButton);
          //  newAdImageButton.Click += delegate {
          //      takePictureFragment = new DialogFragments.TakePictureFragment();
          //      takePictureFragment.Show(FragmentActivityCaller.SupportFragmentManager, "dialog", FragmentActivityCaller);
                
         //   };
        }

        private void AddItems()
        {
            // var webClient = new WebClient();
            // var json = new WebClient().DownloadString("url");

            //  using (WebClient wc = new WebClient())
            //  {
            //      var json = wc.DownloadString("http://146.185.164.20:57483/ping");
            // }

            Android.Widget.ScrollView s = Fragmentview.FindViewById<Android.Widget.ScrollView>(Resource.Id.scrollView2);
            GridLayout g = Fragmentview.FindViewById<GridLayout>(Resource.Id.tableLayout1);
            //Makes the scrollview fit the screen with the given floatvalue 
            LinearLayout.LayoutParams scrollParams = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent, 2.0f);
            s.LayoutParameters = scrollParams;


            ImageButton[] btnGreen = new ImageButton[6];

            Android.Widget.RelativeLayout[] lLL = new Android.Widget.RelativeLayout[6];

            for (int i = 0; i < 6; i++)
            {

                lLL[i] = new Android.Widget.RelativeLayout(Context);
                //  lLL[i].Orientation = Orientation.Vertical;
                Android.Widget.RelativeLayout.LayoutParams width = new Android.Widget.RelativeLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
                Android.Widget.RelativeLayout.LayoutParams height = new Android.Widget.RelativeLayout.LayoutParams(width.Width, 400);
                lLL[i].LayoutParameters = height;
                //textbox3.setLayoutParams(width);


                // l.LayoutParameters = new TableLayout.LayoutParams(, LayoutParams.WRAP_CONTENT, 1f);


                TextView t = new TextView(Context);

                ImageView iv = new ImageView(Context);
                iv.SetImageResource(Resource.Drawable.design_fab_background);
                t.Text = "Databaser og krig: Pris: 250kr";
                t.SetTextColor(Android.Graphics.Color.White);
                btnGreen[i] = new ImageButton(Context);
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

        protected override void InitiateFragment()
        {
            base.InitiateFragment();
            AddItems();
           // ViewPager viewPager = Fragmentview.FindViewById<ViewPager>(Resource.Id.viewpager);
           // TreeCatalog treeCatalog = new TreeCatalog();
           //  viewPager.Adapter = new TreePagerAdapter(this.Context, treeCatalog);
        }
    }
}