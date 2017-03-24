using System;
using Android.App;
using Android.Runtime;
using Android.Content;
using Android.Views;
using Android.Widget;
using Android.Support.V4.View;
using Java.Lang;
using ApplikasjonBoknaden.Droid.TreePager;
using ApplikasjonBoknaden.Droid;

namespace TreePager
{
    /// <summary>
    /// Source: https://developer.xamarin.com/guides/android/user_interface/viewpager/part-1-viewpager-and-views/
    /// Source2: http://stackoverflow.com/questions/37480733/xamarin-android-tablayout-adding-fragments-to-viewpager-instead-of-layouts
    /// </summary>
    class TreePagerAdapter : PagerAdapter
    {
        public override Java.Lang.ICharSequence GetPageTitleFormatted(int position)
        {
            return new Java.Lang.String(treeCatalog[position].caption);
        }

        //  public override int Count
        //  {
        //     get { throw new NotImplementedException(); }
        //  }

        public override int Count
        {
            get { return treeCatalog.NumTrees; }
        }

        Context context;
        TreeCatalog treeCatalog;

        public TreePagerAdapter(Context context, TreeCatalog treeCatalog)
        {
            this.context = context;
            this.treeCatalog = treeCatalog;

        }

       // public override bool IsViewFromObject(View view, Java.Lang.Object obj)
      //  {
       //     throw new NotImplementedException();
      //  }

        public override bool IsViewFromObject(View view, Java.Lang.Object obj)
        {
            return view == obj;
        }

        //  public override Java.Lang.Object InstantiateItem(View container, int position)
        // {
        //      throw new NotImplementedException();
        //   }

        public override Java.Lang.Object InstantiateItem(ViewGroup container, int position)
        {
            if (position == 1)
            {
                View view = LayoutInflater.From(container.Context).Inflate(Resource.Layout.RegisterNewUserFragmentLayout, container, false);
                container.AddView(view);

                return view;
            }

            if (position == 1)
            {
                LayoutInflater inflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
                ViewGroup vg = new LinearLayout(context);
                inflater.Inflate(Resource.Layout.UserPageLayout, vg, false);



                return inflater;
            }

            var imageView = new ImageView(context);
            imageView.SetImageResource(treeCatalog[position].imageId);
            var viewPager = container.JavaCast<ViewPager>();
            viewPager.AddView(imageView);
            return imageView;
        }

     //   public override Java.Lang.Object InstantiateItem(View container, int position)
    //    {
     //       var imageView = new ImageView(context);
      //      imageView.SetImageResource(treeCatalog[position].imageId);
      //      var viewPager = container.JavaCast<ViewPager>();
       //     viewPager.AddView(imageView);
     //       return imageView;
       // }

        //  public override void DestroyItem(View container, int position, Java.Lang.Object view)
        //  {
        //     throw new NotImplementedException();
        //  }


        public override void DestroyItem(View container, int position, Java.Lang.Object view)
        {
            var viewPager = container.JavaCast<ViewPager>();
            viewPager.RemoveView(view as View);
        }
    }
}