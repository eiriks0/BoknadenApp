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

namespace ApplikasjonBoknaden.Droid.ViewPageExpanders
{
    class ChatCatalog : CustomCatalog
    {
        new protected static PageFrag[] treeBuiltInCatalog = {
            new PageFrag { LayoutID = Resource.Layout.DialogueFragmentRegisterUserLayout,
                           Header = "Selger" },
            new PageFrag { LayoutID = Resource.Layout.DialogueFragmentSearchFiltersLayout,
                           Header = "Kj�per" },
            new PageFrag { LayoutID = Resource.Layout.DialogueFragmentSearchFiltersLayout,
                           Header = "Test" },
        };

        public ChatCatalog()
        {
            Pages = treeBuiltInCatalog;
        }
    }
}