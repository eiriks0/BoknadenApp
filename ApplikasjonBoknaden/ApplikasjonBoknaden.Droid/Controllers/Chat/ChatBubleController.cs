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

namespace ApplikasjonBoknaden.Droid.Controllers.Chat
{
    class ChatBubleController : RelativeLayout
    {
        public Json.Chat.Row _Row;

        private View Controller_View;

        private ViewGroup _Parent;

        private ViewGroup AdPack_Parent;
        private TextView ChatBubleText;
        private LinearLayout _LinearLayoutButton;
        private ChatBubleType _ChatBubleType;
        private string ChatText;

        public enum ChatBubleType
        {
            Seller,
            Byer
        }


        public ChatBubleController(Context context) : base (context)
        {
            //Initialize();
        }

        public ChatBubleController(Context context, ViewGroup parent, ChatBubleType chatBubleType, string chatbubletext) : base(context)
        {
            _ChatBubleType = chatBubleType;
            ChatText = chatbubletext;
            // _Row = ch;
            AdPack_Parent = parent;
            // foreach (Json.Aditem ai in Ad.aditems)
            // {
            //    PackPrice = PackPrice + ai.price;
            // }
            Initiate(parent);
        }

        public LinearLayout GetLinearLayoutButton()
        {
            return _LinearLayoutButton;
        }

        public ChatBubleController(Context context, Android.Util.IAttributeSet attrs) : base (context,attrs)    
        {
            //  Initialize();
        }

        public ChatBubleController(Context context, Android.Util.IAttributeSet attrs, int defStyle) : base (context, attrs, defStyle)
        {
            // Initialize();
        }

        // public Button GetButton()
        // {
        //    return AdPack_Button;
        // }

        private void Initiate(ViewGroup parent)
        {
            _Parent = parent;
            if (_ChatBubleType == ChatBubleType.Byer)
            {
                Controller_View = LayoutInflater.From(Context).Inflate(Resource.Layout.ChatBuble_Buyer, parent, false);
            }else
            {
                Controller_View = LayoutInflater.From(Context).Inflate(Resource.Layout.ChatBuble_Seller, parent, false);
            }

            ChatBubleText = Controller_View.FindViewById<TextView>(Resource.Id.ChatBuble_Textview);
            ChatBubleText.Text = ChatText;
         //   _LinearLayoutButton = Controller_View.FindViewById<LinearLayout>(Resource.Id.linearLayout_ChatPickerControllButton);
         //  ChatText.Text = _Row.Initiator.firstname + _Row.Initiator.lastname;
            parent.AddView(Controller_View);
        //    SetButtonValues();
        }

        private void SetButtonValues()
        {

        }
    }
}