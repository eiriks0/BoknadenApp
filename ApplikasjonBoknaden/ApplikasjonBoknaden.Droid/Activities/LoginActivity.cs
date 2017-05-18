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
using ApplikasjonBoknaden.JsonHelpers;
using ApplikasjonBoknaden.Droid.AndroidJsonHelpers;
using ApplikasjonBoknaden.Droid.SavedValues;
using System.Net.Http;
using Android.Content.PM;
using Android.Graphics;
using ApplikasjonBoknaden.Droid.DialogFragments.Popups;

namespace ApplikasjonBoknaden.Droid
{
    [Activity(Label = "LoginActivity", ScreenOrientation = ScreenOrientation.Portrait)]
    public class LoginActivity : CustomFragmentActivity
    {
        private EditText LoginEditText;
        private EditText PasswordEditText;
        private UserOld User = new UserOld();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Forms.Forms.Init(this, savedInstanceState);
            ActionBar.Hide();
            SetContentView(Resource.Layout.ActivityLoginLayout);
            SetButtonValues();
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
                User.Username = LoginEditText.Text;
                User.Password = PasswordEditText.Text;
                User.Email = LoginEditText.Text;
                NewLogin();
                //Login(User);

            };
            RegisterButton.Click += delegate {
                PopupRegisterPage();
            };
        }
        /// <summary>
        /// Tries to log user in.
        /// </summary>
        private async void NewLogin()
        {
            Json.LoginInfo lf = await Task.Run(() => Json.JsonUploader.AutenticateUser(User));

            if (!lf.WrongLoginInfo)
            {
                JToken s = lf.Token;

                SavedValues.UserValues.saveStringPrefs("Header", s.ToString(), sPEditor);
                System.Diagnostics.Debug.WriteLine(SavedValues.UserValues.getStringPrefs("Header", sP));
                string token = s.ToString();
                System.Diagnostics.Debug.WriteLine(token + "" + "Dette er tokenen");

                User.UserID = AndroidJsonHelper.GetValueFromToken(token, AndroidJsonHelper.UserValuesEnums.userid);
                User.Firstname = AndroidJsonHelper.GetValueFromToken(token, AndroidJsonHelper.UserValuesEnums.firstname);
                User.Lastname = AndroidJsonHelper.GetValueFromToken(token, AndroidJsonHelper.UserValuesEnums.lastname);
                User.Email = AndroidJsonHelper.GetValueFromToken(token, AndroidJsonHelper.UserValuesEnums.email);
                User.Username = AndroidJsonHelper.GetValueFromToken(token, AndroidJsonHelper.UserValuesEnums.username);
                User.verified = AndroidJsonHelper.GetValueFromToken(token, AndroidJsonHelper.UserValuesEnums.verified);
                User.Password = PasswordEditText.Text;
                User.Token = token;

                if (UserIsVerified(User))
                {
                    UserValues.SaveNewUserValues(User, sPEditor);
                    StartActivity(typeof(MainMenuActivity));
                }
                else
                {
                    PopupNotVerifiedMailDialogueFragment APDF = new PopupNotVerifiedMailDialogueFragment(SupportFragmentManager, "dialog", this, "Bruker er ikke verifisert", "Send ny verifiserings mail", token);
                }

            }
            else
            {
                PoppupDialogueFragment APDF = new PoppupDialogueFragment();
                APDF.Show(SupportFragmentManager, "dialog", this, "Feil passord eller brukernavn!", false);
            }
        }

        private void SendNewVerificationMail()
        {
            System.Diagnostics.Debug.WriteLine("SendNewVerificationMail");
        }

        /// <summary>
        /// Checks if given user has its verified value set to 1 (true) or 0 (false).
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private bool UserIsVerified(UserOld user)
        {
            if (User.verified == "1")
            {
                return true;
            }else
            {
                return false;
            }
        }
        /// <summary>
        /// Shows the register new user fragment
        /// </summary>
        private void PopupRegisterPage()
        {
            RegisterNewUserDialogueFragment s = new DialogFragments.RegisterNewUserDialogueFragment();
            s.Show(SupportFragmentManager, "dialog", this);
        }
    }
}