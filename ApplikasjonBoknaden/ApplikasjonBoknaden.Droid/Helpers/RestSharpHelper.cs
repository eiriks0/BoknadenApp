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
using RestSharp;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net.Http;
using System.IO;
using ApplikasjonBoknaden.Json;

namespace ApplikasjonBoknaden.Droid.Helpers
{
    public class RestSharpHelper
    {


        public void AdNewAdd(string header, Json.Ad sentad)
        {
            header = AndroidJsonHelpers.AndroidJsonHelper.CleansedToken(header);


            // var request = new RestRequest("ads", Method.POST);
            //  System.Diagnostics.Debug.WriteLine(header);
            try
            {
                var client = new RestClient("http://146.185.164.20:57483/");

                //  RootObjectTest newuser = new RootObjectTest();
                //  newuser.username = "Halla";
                //  newuser.passphrase = "Balla";
                //   newuser.email = "Camm-bridge@hotmail.com";
                //   newuser.firstname = "Knut";
                //  newuser.lastname = "Korre";
                //  newuser.phone = "47706787";
                //  newuser.courseid = "1";

                Json.NewAdTest newad = new Json.NewAdTest();
                // newad.userid = 1;

                newad.courseid = 1;
                newad.adname = sentad.adname;
                newad.text = "Bok om te";
                newad.aditems = new List<Json.Aditem>();

                // foreach (Json.Aditem item in ad.aditems)
                //  {
                //      newad.aditems.Add(item);
                // }

                Json.Aditem newAdItem = new Json.Aditem();
                newAdItem.isbn = "5555555555";
                newAdItem.price = 250;
                newAdItem.text = "Funker fra app!";
                newAdItem.description = "Hm";

                newad.aditems.Add(newAdItem);
                string jsonData = JsonConvert.SerializeObject(newad);
                System.Diagnostics.Debug.WriteLine(jsonData);

                var request = new RestRequest("ads", Method.POST);
                request.RequestFormat = DataFormat.Json;
                request.AddHeader("boknaden-verify", header);
                request.AddParameter("Application/Json", jsonData, ParameterType.RequestBody);
                //request.AddJsonBody(newad);

                //  System.Diagnostics.Debug.WriteLine(request.Parameters);

                //  RestResponse response = client.Execute(request);
                // var content = response.Content;

                //   var asyncHandle = client.ExecuteAsync<Json.Ad>(request, response => {
                //      Console.WriteLine(response.Data.adname);
                // });


                client.ExecuteAsync(request, response =>
                {
                    System.Diagnostics.Debug.WriteLine(response.Content);
                });


            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine("Nay");
                System.Diagnostics.Debug.WriteLine("CAUGHT EXCEPTION:");
                System.Diagnostics.Debug.WriteLine(exception);
                // return null;
            }

            //request.AddObject(newbook);

            //request.AddObject("'");

            // request.AddBody("'");
            //  request.AddJsonBody(newbook);
            //  request.AddBody("'");
            // request.AddBody(newad);
            //  request.AddObject(newad);


        }
    }
}