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
using Android.Graphics;

namespace ApplikasjonBoknaden.Droid.AdItemClasses
{
   public class AdMiniature : RelativeLayout
    {
    

        public Json.Ad AdPack_Ad;
        private Button AdPack_Button;

        private Json.Aditem _Product;
        private View AdPack_View;
        private TextView AdPack_SellerText;
        private TextView AdPack_PriceText;
        private TextView AdPack_PackNameText;
        private ImageView AdPack_ImageView;
        //private LinearLayout AdPack_HorizontalPri;
        private LinearLayout AdPack_TextFogBackground;
        private int PackPrice = 0;

        private ViewGroup AdPack_Parent;

        private bool isPack = false;

        public AdMiniature(Context context) : base (context)
        {
            //Initialize();
        }

        public AdMiniature(Context context, ViewGroup parent, Json.Aditem product, Json.Ad Ad) : base(context)
        {
            _Product = product;
            AdPack_Ad = Ad;
            AdPack_Parent = parent;
            isPack = false;
            Initiate(parent);
        }

        public AdMiniature(Context context, ViewGroup parent, Json.Ad Ad) : base(context)
        {
            AdPack_Ad = Ad;
            AdPack_Parent = parent;
            isPack = true;
            foreach (Json.Aditem ai in Ad.aditems)
            {
                PackPrice = PackPrice + ai.price;
            }
            Initiate(parent);
        }

        public AdMiniature(Context context, Android.Util.IAttributeSet attrs) : base (context,attrs)    
        {
          //  Initialize();
        }

        public AdMiniature(Context context, Android.Util.IAttributeSet attrs, int defStyle) : base (context, attrs, defStyle)
        {
           // Initialize();
        }

        public Button GetButton()
        {
            return AdPack_Button;
        }

        public Json.Aditem GetProduct()
        {
            return _Product;
        }

        private void Initiate(ViewGroup parent)
        {
            AdPack_View = LayoutInflater.From(Context).Inflate(Resource.Layout.AdMiniatureLayout, parent, false);
            parent.AddView(AdPack_View);
            SetButtonValues();
        }

        public void setImage(Bitmap b)
        {
           // AdPack_ImageView = AdPack_View.FindViewById<ImageView>(Resource.Id.AdPack_ImageView);
          //  if(AdPack_ImageView != null)
            AdPack_ImageView.SetImageBitmap(b);
        }

        public void SetValues(Json.Aditem aditem)
        {
            this.AdPack_PackNameText.Text = aditem.text;
            this.AdPack_PriceText.Text = "Pris:" + " " + aditem.price.ToString() + " " + "Kr";
        }

        private void SetButtonValues()
        {
            AdPack_Button = AdPack_View.FindViewById<Button>(Resource.Id.AdPack_button);
            AdPack_ImageView = AdPack_View.FindViewById<ImageView>(Resource.Id.AdPack_ImageView);
            AdPack_SellerText = AdPack_View.FindViewById<TextView>(Resource.Id.AdPack_SellerText);
            AdPack_PriceText = AdPack_View.FindViewById<TextView>(Resource.Id.AdPack_PriceText);
            AdPack_PackNameText = AdPack_View.FindViewById<TextView>(Resource.Id.AdPack_PackNameText);
            AdPack_TextFogBackground = AdPack_View.FindViewById<LinearLayout>(Resource.Id.AdPack_TextFogBackground);

            AdPack_SellerText.Text = AdPack_Ad.user.firstname + " " + AdPack_Ad.user.lastname;

            if (isPack)
            {
                AdPack_PackNameText.Text = AdPack_Ad.adname;
                AdPack_PriceText.Text = "Totalt:" + " " + PackPrice.ToString() + " " + "Kr";

            }
            else
            {
                AdPack_PackNameText.Text = _Product.text;
                AdPack_PriceText.Text = "Pris:" + " " + _Product.price.ToString() + " " + "Kr";
            }


        }
    }
}