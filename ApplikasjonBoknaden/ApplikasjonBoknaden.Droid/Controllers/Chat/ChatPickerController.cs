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
    class ChatPickerController : RelativeLayout
    {
        public Json.Chat.Row _Row;

        private View Controller_View;

        private ViewGroup _Parent;

        private ViewGroup AdPack_Parent;
        private TextView ChatText;
        private LinearLayout _LinearLayoutButton;


        public ChatPickerController(Context context) : base (context)
        {
            //Initialize();
        }

        public ChatPickerController(Context context, ViewGroup parent, Json.Chat.Row ch) : base(context)
        {
            _Row = ch;
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

        public ChatPickerController(Context context, Android.Util.IAttributeSet attrs) : base (context,attrs)    
        {
            //  Initialize();
        }

        public ChatPickerController(Context context, Android.Util.IAttributeSet attrs, int defStyle) : base (context, attrs, defStyle)
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
            Controller_View = LayoutInflater.From(Context).Inflate(Resource.Layout.ChatPickerControllLayout, parent, false);
            ChatText = Controller_View.FindViewById<TextView>(Resource.Id.ChatBuble_Textview);
            _LinearLayoutButton = Controller_View.FindViewById<LinearLayout>(Resource.Id.linearLayout_ChatPickerControllButton);
            ChatText.Text = _Row.Initiator.firstname + _Row.Initiator.lastname;
            parent.AddView(Controller_View);
            SetButtonValues();
        }

        private void SetButtonValues()
        {
          
        }
    }
}