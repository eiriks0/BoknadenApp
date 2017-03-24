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

namespace ApplikasjonBoknaden.Droid
{
    [Activity(Label = "RegisterNewUserActivity")]
    public class RegisterNewUserActivity : Activity
    {

        protected enum NeededValues
        {
            Username,
            Emai,
            Firstname,
            Lastname,
            Password,
            RepeatedPassword,

        };

        protected List<string> ListOfNeededValues = new List<string>();

        protected string WritenUsername = "";
        protected string WrittenEmail = "";
        protected string WritenFirstname = "";
        protected string WritenLastname = "";
        protected string WritenPassword = "";
        protected string WritenRepeatedPassword = "";

        protected EditText InputFieldUsername = null;
        protected EditText InputFieldEmail = null;
        protected EditText InputFieldFirstname = null;
        protected EditText InputFieldLastname = null;
        protected EditText InputFieldPassword = null;
        protected EditText InputFieldRepeatedPassword = null;


        protected ValidationResponse ValidationResponder = new ValidationResponse();


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.RegisterNewUser);
            SetButtonValues();

            foreach (NeededValues value in Enum.GetValues(typeof(NeededValues)))
            {
                string neededvalue = value.ToString();
                ListOfNeededValues.Add(neededvalue);
            }
            Toast.MakeText(this, "Registrering fullført", ToastLength.Long).Show();
          //  UploadNewUser();
        }
        /// <summary>
        /// Finds and sets the values on this activities buttons and other views
        /// </summary>
        protected void SetButtonValues()
        {
            InputFieldUsername = FindViewById<Android.Widget.EditText>(Resource.Id.editTextUsername);
            InputFieldEmail = FindViewById<Android.Widget.EditText>(Resource.Id.editTextEmail);
            InputFieldFirstname = FindViewById<Android.Widget.EditText>(Resource.Id.editTextFirstname);
            InputFieldLastname = FindViewById<Android.Widget.EditText>(Resource.Id.editTextLastname);
            InputFieldPassword = FindViewById<Android.Widget.EditText>(Resource.Id.editTextPassword);
            InputFieldRepeatedPassword = FindViewById<Android.Widget.EditText>(Resource.Id.editTextRepeatedPassword);


            Android.Widget.Button BackToLoginActivutyButton = FindViewById<Android.Widget.Button>(Resource.Id.BackToLoginActivityButton);
            BackToLoginActivutyButton.Click += delegate {
                StartActivity(typeof(MainActivity));
            };

            Android.Widget.Button RegisterButton = FindViewById<Android.Widget.Button>(Resource.Id.RegisterUserButton);
            RegisterButton.Click += delegate {
                ValidateInput();

            };

        }

        /// <summary>
        /// Starts the validation prosess of the values writen in the inputfields
        /// </summary>
        protected void ValidateInput()
        {
            WritenUsername = InputFieldUsername.Text;
            WrittenEmail = InputFieldEmail.Text;
            WritenFirstname = InputFieldFirstname.Text;
            WritenLastname = InputFieldLastname.Text;
            WritenPassword = InputFieldPassword.Text;
            WritenRepeatedPassword = InputFieldRepeatedPassword.Text;

            //Validates username
            ValidationResponder = InputValidator.validUsername(WritenUsername);
            if (!ValidationResponder.Successful)
            {
                ShowToast(ValidationResponder.Information);
                return;
            }
            //Validates email
            ValidationResponder = InputValidator.validEmail(WrittenEmail);
            if (!ValidationResponder.Successful)
            {
                ShowToast(ValidationResponder.Information);
                return;
            }
            //validates firstname
            ValidationResponder = InputValidator.validFirstname(WritenFirstname);
            if (!ValidationResponder.Successful)
            {
                ShowToast(ValidationResponder.Information);
                return;
            }
            //Validates lastname
            ValidationResponder = InputValidator.validLastname(WritenLastname);
            if (!ValidationResponder.Successful)
            {
                ShowToast(ValidationResponder.Information);
                return;
            }
            //Validates password
            ValidationResponder = InputValidator.validPassword(WritenPassword);
            if (!ValidationResponder.Successful)
            {
                ShowToast(ValidationResponder.Information);
                return;
            }
            //Validates repeated password
            ValidationResponder = InputValidator.validRepeatedPassword(WritenPassword, WritenRepeatedPassword);
            if (!ValidationResponder.Successful)
            {
                ShowToast(ValidationResponder.Information);
                return;
            }
   
        }

        private void ShowToast(string message)
        {
            Toast.MakeText(this, message, ToastLength.Long).Show();
        }

     //   private async void UploadNewUser()
      //  {
     //       await JsonUploader.RegisterNewUser(WritenUsername, WrittenEmail, WritenFirstname, WritenLastname, WritenPassword);
          //  await JsonDownloader.RegisterNewUser(WritenUsername, WrittenEmail, WritenFirstname, WritenLastname, WritenPassword);
       // }
    }
}