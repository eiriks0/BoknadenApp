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
using System.Threading.Tasks;
using Android.Support.V4.App;
using ApplikasjonBoknaden.Droid.DialogFragments;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Dynamic;

namespace ApplikasjonBoknaden.Droid
{
    [Activity(Label = "LoginActivity")]
    public class LoginActivity : CustomFragmentActivity
    {
        private EditText LoginEditText;
        private EditText PasswordEditText;
        private ISharedPreferences sP;
        private ISharedPreferencesEditor sPEditor;

        int testint = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Forms.Forms.Init(this, savedInstanceState);
            ActionBar.Hide();
            sP = GetSharedPreferences("SearchFilter", FileCreationMode.Private);
            sPEditor = sP.Edit();

            

            SetContentView(Resource.Layout.Login);



            SetButtonValues();

            //   CheckIfUserShouldGetNewToken();
        }

        //  private async void G()
        //  {
        //       await JsonUploader.RegisterNewUser(WritenUsername, WrittenEmail, WritenFirstname, WritenLastname, WritenPassword);
        //  await JsonDownloader.RegisterNewUser(WritenUsername, WrittenEmail, WritenFirstname, WritenLastname, WritenPassword);
        // }

        private async void CheckIfUserShouldGetNewToken()
        {
            // if (SavedValues.UserValues.getStringPrefs("Header", sP))
            // {
            JToken s = await JsonUploader.AutenticateUser();
            SavedValues.UserValues.saveStringPrefs("Header", s.ToString(), sPEditor);
            System.Diagnostics.Debug.WriteLine(SavedValues.UserValues.getStringPrefs("Header", sP));


            //  System.Diagnostics.Debug.WriteLine(id.);
            //  var name = results.Name;
            TestJwtSecurityTokenHandler(s.ToString());
            // }
        }
        /// <summary>
        /// Gets user values from given token.
        /// </summary>
        /// <param name="token"></param>
        public void TestJwtSecurityTokenHandler(string token)
        {

            //removes the start of the token string
            token = token.Substring(25);
            //Removes the end of the token string
            token = token.Remove(token.Length - 2);
            var handler = new JwtSecurityTokenHandler();
            //Reads the "cleansed" token
            var jsonToken = handler.ReadToken(token) as JwtSecurityToken;
            //Gets the email from the token           
            var UserEmail = jsonToken.Claims.First(claim => claim.Type == "email").Value;
            //Gets the expiration from the token
            var UserTokenExpiraton = jsonToken.Claims.First(claim => claim.Type == "exp").Value;
            //Debug
            Console.WriteLine(UserTokenExpiraton);
        }



        private void PopupRegisterPage()
        {

            RegisterNewUserFragment s = new DialogFragments.RegisterNewUserFragment();
            s.Show(SupportFragmentManager, "dialog", this);

          //  Android.Support.V4.App.FragmentTransaction ft = SupportFragmentManager.BeginTransaction();
         //   ft.SetCustomAnimations(Resource.Animation.abc_slide_in_bottom, Resource.Animation.abc_slide_out_top);
         //   ft.Replace(Resource.Id.FragmentHolderRelativeLayout, new RegisterNewUserFragment(), "details_fragment");
           // ft.SetTransition(Android.Support.V4.App.FragmentTransaction.TransitFragmentFade);
        //    ft.Commit();


        }








        /// <summary>
        /// Finds and sets the values on this activities buttons and other views
        /// </summary>
        protected void SetButtonValues()
        {
            Android.Widget.Button loginButton = FindViewById<Android.Widget.Button>(Resource.Id.Button_Login);
            Android.Widget.Button RegisterButton = FindViewById<Android.Widget.Button>(Resource.Id.Button_NewUser);
            LoginEditText = FindViewById<EditText>(Resource.Id.editTextEmailLogin);
            PasswordEditText = FindViewById<EditText>(Resource.Id.editTextPassordLogin);

            loginButton.Click += delegate {
                Login();

            };

            RegisterButton.Click += delegate {
             //   var dialog = new RegisterNewUserFragment();
               // dialog.Show(SupportFragmentManager, "dialog", this);
                 PopupRegisterPage();

            };
        }

        private void Login()
        {
           // CheckIfUserShouldGetNewToken();
            StartActivity(typeof(MainMenuActivity));
        }


     //   protected async void Login()
   //     {
    //        await JsonUploader.TryToLogIn(LoginEditText.Text, PasswordEditText.Text);
            //StartActivity(typeof(MainMenuActivity));
    //    }
    }
}