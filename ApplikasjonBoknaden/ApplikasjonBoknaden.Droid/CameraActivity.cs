using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;

using Android.Graphics;
using Android.Widget;
using Android.Provider;
using Android.Content.PM;
using Android.Net;
using ZXing.Mobile;

namespace ApplikasjonBoknaden.Droid
{
    [Activity(Label = "CameraActivity")]
    public class CameraActivity : Activity
    {
        private ImageView _imageView;
        private EditText EditTextISBNNumber;
        private Spinner SchoolSpinner;
        private Spinner ClassSpinner;
        private string[] schoolnamesarr1 = new string[] { "Uspesifisert", "Lunde", "Bø", "Horten" };
        private string[] ClassNamesarr = new string[] { "Uspesifisert", "IT", "Helse", "Religion" };

        static int REQUEST_IMAGE_CAPTURE = 1;
        private string PassedISBN = "";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            PassedISBN = Intent.GetStringExtra(GetString(Resource.String.ISBNString)) ?? "Data not available";
            SetContentView(Resource.Layout.Camera);
            SetButtonValues();
            CheckDatabaseForExistingISBN(PassedISBN);

            // SchoolSpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            // var adapter = ArrayAdapter.FromArray<string>(schoolnamesarr1);
            //  var adapter = ArrayAdapter.CreateFromResource(
            //     this, Resource.Array.planets_array, Android.Resource.Layout.SimpleSpinnerItem);

            PopulateSpinner(SchoolSpinner, schoolnamesarr1);
            PopulateSpinner(ClassSpinner, ClassNamesarr);

        }

        private void PopulateSpinner(Spinner sp, string [] spinnerStrings)
        {
            ArrayAdapter<string> adapter1 = new ArrayAdapter<string>(this, Resource.Layout.Spinner_textview, spinnerStrings);
            adapter1.SetDropDownViewResource(global::Android.Resource.Layout.SimpleSpinnerDropDownItem);
            sp.Adapter = adapter1;

        }




        //https://developer.xamarin.com/guides/android/user_interface/spinner/
        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;

            string toast = string.Format("The planet is {0}", spinner.GetItemAtPosition(e.Position));
            Toast.MakeText(this, toast, ToastLength.Long).Show();
        }

        private void CheckDatabaseForExistingISBN(string isbn)
        {
           // string bookName = JsonDownloader.GetNameOfBook(isbn); (Returns as empty string if the isbn doesn't exist).
        }

        /// <summary>
        /// Finds and sets the values on this activities buttons and other views
        /// </summary>
        protected void SetButtonValues()
        {
            //School Selector
            SchoolSpinner = FindViewById<Spinner>(Resource.Id.spinnerSchoolUpload);
            //Class Selector
            ClassSpinner = FindViewById<Spinner>(Resource.Id.spinnerClassUpload);
            //ISBN number
            EditTextISBNNumber = FindViewById<EditText>(Resource.Id.editTextISBNNumber);
            EditTextISBNNumber.Text = PassedISBN;
            EditTextISBNNumber.Focusable = false;
            EditTextISBNNumber.SetBackgroundColor(Color.LightGreen);
            //Book Image
            _imageView = FindViewById<ImageView>(Resource.Id.imageView1);
            if (IsThereAnAppToTakePictures())
            {
                Button button = FindViewById<Button>(Resource.Id.myButton);
                CreateDirectoryForPictures();
                button.Click += TakeAPicture;
            }
        }



        private void dispatchTakePictureIntent()
        {
            Intent takePictureIntent = new Intent(MediaStore.ActionImageCapture);
            if (IsThereAnAppToTakePictures())
            {
                StartActivityForResult(takePictureIntent, REQUEST_IMAGE_CAPTURE);
            }
        }

        private void CreateDirectoryForPictures()
        {
            App._dir = new Java.IO.File(
                Android.OS.Environment.GetExternalStoragePublicDirectory(
                    Android.OS.Environment.DirectoryPictures), "CameraAppDemo");
            if (!App._dir.Exists())
            {
                App._dir.Mkdirs();
            }
        }

        private bool IsThereAnAppToTakePictures()
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            IList<ResolveInfo> availableActivities =
                PackageManager.QueryIntentActivities(intent, PackageInfoFlags.MatchDefaultOnly);
            return availableActivities != null && availableActivities.Count > 0;
        }

        private void TakeAPicture(object sender, EventArgs eventArgs)
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            App._file = new Java.IO.File(App._dir, String.Format("myPhoto_{0}.jpg", Guid.NewGuid()));
            intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(App._file));
            StartActivityForResult(intent, 0);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            // Make it available in the gallery

            Intent mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
            Android.Net.Uri contentUri = Android.Net.Uri.FromFile(App._file);
            mediaScanIntent.SetData(contentUri);
            SendBroadcast(mediaScanIntent);

            // Display in ImageView. We will resize the bitmap to fit the display.
            // Loading the full sized image will consume to much memory
            // and cause the application to crash.

            int height = Resources.DisplayMetrics.HeightPixels;
            int width = _imageView.Height;
            App.bitmap = App._file.Path.LoadAndResizeBitmap(width, height);
            if (App.bitmap != null)
            {
                _imageView.SetImageBitmap(App.bitmap);
                App.bitmap = null;
            }

            // Dispose of the Java side bitmap.
            GC.Collect();
        }
    }


    public static class App
    {
        public static Java.IO.File _file;
        public static Java.IO.File _dir;
        public static Bitmap bitmap;
    }
}