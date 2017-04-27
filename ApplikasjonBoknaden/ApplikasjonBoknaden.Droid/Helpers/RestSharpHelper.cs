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

namespace ApplikasjonBoknaden.Droid.Helpers
{
    public class RestSharpHelper
    {
       

        public void AdNewAdd(string header)
        {
             header = AndroidJsonHelpers.AndroidJsonHelper.CleansedToken(header);


            // var request = new RestRequest("ads", Method.POST);
          //  System.Diagnostics.Debug.WriteLine(header);
            try
            {
                var client = new RestClient("http://146.185.164.20:57483/");

                Json.Ad newad = new Json.Ad();
                newad.userid = 1;
                // newad.userid = "1";
                //newad.universityid = 1;

                newad.courseid = 1;
                newad.adname = "Nye boker!";
                newad.text = "Text";
                newad.aditems = new List<Json.Aditem>();
                Json.Aditem newAdItem = new Json.Aditem();
                newAdItem.isbn = "1455555555";
                newAdItem.userid = 1;
                newAdItem.price = 250;
                newAdItem.text = "Funker fra app!";
                newAdItem.description = "Hm";
           
                newad.aditems.Add(newAdItem);

                var request = new RestRequest("ads", Method.POST);
                request.AddJsonBody(newad);
                request.AddHeader("boknaden-verify", header);
              //  System.Diagnostics.Debug.WriteLine(request.Parameters);

                //  RestResponse response = client.Execute(request);
                // var content = response.Content;

                client.ExecuteAsync(request, response => {
                   // Console.WriteLine(response.Content);
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