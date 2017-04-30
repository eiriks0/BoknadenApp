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
using ApplikasjonBoknaden.Droid.DialogFragments.CostumParent;
using ApplikasjonBoknaden.Json;
using Android.Support.V4.View;
using ApplikasjonBoknaden.Droid.ViewPageExpanders;

namespace ApplikasjonBoknaden.Droid.DialogFragments
{
    [Activity(Label = "AdPackDialogueFragmen")]
    public class AdPackDialogueFragment : CustomDialogActivity
    {
        private Ad _AdPack;

        public void Show(Android.Support.V4.App.FragmentManager manager, string tag, CustomFragmentActivity caller, Ad ad)
        {
            this.CallerActivity = caller;
            _AdPack = ad;
            base.Show(manager, tag);

    
        }

        protected override int LayoutSetter()
        {
            return Resource.Layout.AdPackLayout;
        }

        protected override void InitiateFragment()
        {
            ViewPager viewPager = Dialogueview.FindViewById<ViewPager>(Resource.Id.viewpager);
            //AdCatalog treeCatalog = new AdCatalog(_AdPack);
            // viewPager.Adapter = new TreePagerAdapter(this.Context, treeCatalog);
            viewPager.Adapter = new AdPackAdapter(this.Context, _AdPack);
        }
    }
}