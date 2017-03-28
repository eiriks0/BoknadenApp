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
using ZXing.Mobile;
using Android.Support.V7.Widget;
using ApplikasjonBoknaden.Droid.DialogFragments.CostumParent;

namespace ApplikasjonBoknaden.Droid.DialogFragments
{
    [Activity(Label = "ISBNScanActivity")]
    public class AddNewBookFirstFragment : CustomDialogActivity
    {
        protected ValidationResponse ValidationResponder = new ValidationResponse();
        private CardView ISBNScanCard = null;
        private CardView ISBNDescriptionCard = null;

        private TakePictureFragment takePictureFragment = null;

        //  protected override void OnCreate(Bundle savedInstanceState)
        //  {
        //        base.OnCreate(savedInstanceState);
        //      SetContentView(Resource.Layout.ISBNScan);
        //      SetButtonValues();
        //   }

        protected override int LayoutSetter()
        {
            return Resource.Layout.AddNewBookFirstFragmentLayout;
        }

        protected override void InitiateFragment()
        {
            SetButtonValues();
        }

        private void GoToNextStep(string isbn)
        {
            //Validates username
            ValidationResponder = InputValidator.validISBN(isbn);
            if (!ValidationResponder.Successful)
            {
                ShowToast(ValidationResponder.Information);
                return;
            }

            var dialog = new DialogFragments.AddNewBookFirstFragment();
            dialog.Show(this.CallerActivity.SupportFragmentManager, "dialog", this.CallerActivity);

          //  var nextActivity = new Intent(this.CallerActivity, typeof(CameraActivity));
          //  nextActivity.PutExtra(GetString(Resource.String.ISBNString), isbn);
           // StartActivity(nextActivity);
        }

        private void GoToPreviusStep()
        {
            takePictureFragment = new DialogFragments.TakePictureFragment();
          //  takePictureFragment.Show(this.CallerActivity.SupportFragmentManager, "dialog", this.CallerActivity, this.CallerActivity);
        }



        /// <summary>
        /// Finds and sets the values on this activities buttons and other views
        /// </summary>
        protected void SetButtonValues()
        {
            EditText ManualISBNInput = Dialogueview.FindViewById<EditText>(Resource.Id.ManualISBNInputEditText);
            Button NextStepImageButton = Dialogueview.FindViewById<Button>(Resource.Id.NextStepISBNScanButton);
            TextView ISBNDescriptionLink = Dialogueview.FindViewById< TextView>(Resource.Id.ISBNDescriptionLink);
            ISBNScanCard = Dialogueview.FindViewById<CardView>(Resource.Id.cardViewScanner);
            ISBNDescriptionCard = Dialogueview.FindViewById<CardView>(Resource.Id.cardViewISBNDescription);
            ISBNDescriptionLink.Clickable = true;
            ISBNDescriptionLink.Click += ShowDescriptionCard;

            ImageView closeCard = Dialogueview.FindViewById<ImageView>(Resource.Id.ImageViewCardClose);

            ImageButton BackToScannerButton = Dialogueview.FindViewById<ImageButton>(Resource.Id.BackToScannerImageButton);
            BackToScannerButton.Click += ShowScannerCard;
            closeCard.Touch += (object sender, View.TouchEventArgs e) =>
            {
                if (e.Event.Action == MotionEventActions.Up)
                {
                    closeCard.Alpha = 1.0f;
                    CloseFragment();
                }
                if (e.Event.Action == MotionEventActions.Down)
                {
                    closeCard.Alpha = 0.4f;
                }
            };


            NextStepImageButton.Touch += (object sender, View.TouchEventArgs e) =>
            {
                if (e.Event.Action == MotionEventActions.Up)
                {
                    NextStepImageButton.Alpha = 1.0f;
                    GoToNextStep(ManualISBNInput.Text);

                   // Toast.MakeText(this, "Key Up", ToastLength.Short).Show();
                }
                if (e.Event.Action == MotionEventActions.Down)
                {
                    NextStepImageButton.Alpha = 0.4f;
                  //  Toast.MakeText(this, "Key Down", ToastLength.Short).Show();
                }
            };

            Button Scanbutton = Dialogueview.FindViewById<Button>(Resource.Id.ScanISBNButton);
            Scanbutton.Click += async (sender, e) =>
            {

#if __ANDROID__
                // Initialize the scanner first so it can track the current context
                MobileBarcodeScanner.Initialize(this.CallerActivity.Application);
#endif
                var scanner = new ZXing.Mobile.MobileBarcodeScanner();
                var result = await scanner.Scan();
                if (result != null)
                {
                    Console.WriteLine("Scanned Barcode: " + result.Text);
                    GoToNextStep(result.Text);
                    //  TestText.Text = result.Text;
                }
            };
        }

        private void ShowScannerCard(object sender, EventArgs e)
        {
            ISBNDescriptionCard.Visibility = ViewStates.Gone;
            ISBNScanCard.Visibility = ViewStates.Visible;
        }

        private void ShowDescriptionCard(object sender, EventArgs e)
        {
            ISBNDescriptionCard.Visibility = ViewStates.Visible;
            ISBNScanCard.Visibility = ViewStates.Gone;
        }
    }
}