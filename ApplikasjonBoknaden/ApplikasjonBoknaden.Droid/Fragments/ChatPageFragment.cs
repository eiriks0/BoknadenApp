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
using ApplikasjonBoknaden.Droid.DialogFragments;
using Android.Support.V4.View;
using ApplikasjonBoknaden.Droid.ViewPageExpanders;
using System.Net.Http;
using ApplikasjonBoknaden.Json;
using System.Threading.Tasks;

namespace ApplikasjonBoknaden.Droid.Fragments
{
    public class ChatPageFragment : CostumFragment
    {
        protected LinearLayout ChatsDisplayer;

        protected override int Layout()
        {
            return Resource.Layout.FragmentChatPage;
        }

        protected override void InitiateFragment()
        {

           // ViewPager viewPager = Fragmentview.FindViewById<ViewPager>(Resource.Id.viewpager);
            //viewPager.Adapter = new ChatPageAdapter(this.Context, new ChatCatalog());
           // viewPager.Adapter = new CustomPageAdapter(this.Context, new ChatCatalog());
            ChatsDisplayer = Fragmentview.FindViewById<LinearLayout>(Resource.Id.linearLayout_Chats);
            GetMessages();
            //viewPager.Adapter = new ChatPageAdapter(this.Context, new ChatCatalog());

        }

        private async void GetMessages()
        {
            Json.Chat.RootObject messages = await JsonDownloader.GetChatsFromDB(AndroidJsonHelpers.AndroidJsonHelper.CleansedToken(SavedValues.UserValues.GetSavedToken(CallerActivity.sP)));

            AddChats(messages);
        }

      //  private void AddItems(Json.RootObject root)
     //   {
       //     foreach (Json.Ad a in root.ads)
      //      {
      //          AdItemClasses.AdMiniature AdPackDisplay1 = new AdItemClasses.AdMiniature(Context, AdDisplayer, a);
       //         AdPackDisplay1.GetButton().Click += delegate {
       //             ShowAdPack(a);
      //          };
      //      }
       // }

        private void AddChats(Json.Chat.RootObject root)
        {
            if (root != null)
            {
                foreach (Json.Chat.Row c in root.chats.rows)
                {
                    Controllers.Chat.ChatPickerController cpc = new Controllers.Chat.ChatPickerController(Context, ChatsDisplayer, c);
                    cpc.GetLinearLayoutButton().Click += delegate {
                        ShowChat(c.chatid);
                    };
                }
            }
        }

        private void ShowChat(int chatID)
        {
            ChatDialogueFragment APDF = new ChatDialogueFragment();
            APDF.Show(CallerActivity.SupportFragmentManager, "dialog", CallerActivity, chatID);
        }
    }
}