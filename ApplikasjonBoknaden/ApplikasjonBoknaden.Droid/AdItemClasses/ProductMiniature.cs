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

namespace ApplikasjonBoknaden.Droid.AdItemClasses
{
    class ProductMiniature : RelativeLayout
    {
        private Json.Aditem _Product;
        private View Product_View;
        private ViewGroup Product_Parent;

        public ProductMiniature(Context context) : base (context)
        {
            //Initialize();
        }

        public ProductMiniature(Context context, ViewGroup parent, Json.Aditem product) : base(context)
        {
            _Product = product;
            Product_Parent = parent;
            Initiate(parent);
        }


        private void Initiate(ViewGroup parent)
        {
            Product_View = LayoutInflater.From(Context).Inflate(Resource.Layout.AdMiniatureLayout, parent, false);
            parent.AddView(Product_View);
          //  SetButtonValues();
        }

    }
}