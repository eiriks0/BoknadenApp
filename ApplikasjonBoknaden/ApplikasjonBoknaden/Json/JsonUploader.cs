using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ApplikasjonBoknaden.JsonHelpers;
using System.Net;

namespace ApplikasjonBoknaden
{
   public static class JsonUploader
    {

        private static string AutenticationURL = "http://146.185.164.20:57483/authenticate"; //http://146.185.164.20:57483/authenticate
        private static string UsersURL = "http://146.185.164.20:57483/users"; //http://146.185.164.20:57483/users //http://10.0.0.58:57483/users

        public static async Task<string> AutenticateUser()
        {

            string jsonData1 = @"{
                ""username"" : ""Hay55"", 
            ""passphrase"" : ""Halla""}";

            try
            {
                using (var client = new HttpClient())
                {
                    //client.BaseAddress = new Uri(UsersURL);


                    var content = new StringContent(jsonData1, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(AutenticationURL, content);

            

                    // this result string should be something like: "{"token":"rgh2ghgdsfds"}"
                    string result = await response.Content.ReadAsStringAsync();

                 //   Newtonsoft.Json.Linq.JObject jObject = Newtonsoft.Json.Linq.JObject.Parse(result);
                //    JToken token = JObject.Parse(jObject.ToString());
                  //  var t = result.t

                     //System.Diagnostics.Debug.WriteLine(t);
                    return result;
                }
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine("Nay");
                System.Diagnostics.Debug.WriteLine("CAUGHT EXCEPTION:");
                System.Diagnostics.Debug.WriteLine(exception);
                return null;
            }
        }


        /// <summary>
        /// http://www.newtonsoft.com/json/help/html/T_Newtonsoft_Json_JsonConvert.htm
        /// </summary>
        /// <param name="username"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public static async Task RegisterNewBookAd()
        {
            NewBook newbook = new NewBook();
            newbook.userid = "1";
            newbook.courseid = "1";
            newbook.universityid = "1";
            newbook.adname = "Ny bok!";

            string jsonData = JsonConvert.SerializeObject(newbook);
            // var client = new HttpClient();

            try
            {
                using (var client = new HttpClient())
                {
                   // HttpWebRequest.Headers["Authorization"] = "Basic " + Convert.ToBase64String(credentialBuffer);
                 //  HttpResponseHeaders.
                      

                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync("http://146.185.164.20:57483/ads", content);
                   // response.EnsureSuccessStatusCode(); ???

                    // this result string should be something like: "{"token":"rgh2ghgdsfds"}"
                    var result = await response.Content.ReadAsStringAsync();
                    System.Diagnostics.Debug.WriteLine(result);
                }
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine("Nay");
                System.Diagnostics.Debug.WriteLine("CAUGHT EXCEPTION:");
                System.Diagnostics.Debug.WriteLine(exception);
            }
        }

        /// <summary>
        /// http://www.newtonsoft.com/json/help/html/T_Newtonsoft_Json_JsonConvert.htm
        /// </summary>
        /// <param name="username"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public static async Task RegisterNewUser(string username, string firstName, string lastName, string password, string email, string phone, string courseID)
        {

            RootObjectTest newuser = new RootObjectTest();
            newuser.username = username;
            newuser.passphrase = password;
            newuser.email = email;
            newuser.firstname = firstName;
            newuser.lastname = lastName;
            newuser.phone = "47706787";
            newuser.courseid = "1";

            //  newuser.username = "Nils3";
            //  newuser.passphrase = "12435";
            //   newuser.email = "Kret3@gmail.com";
            //    newuser.firstname = "Vogt3";
            //   newuser.lastname = "Person3";
            //   newuser.phone = "47665326";
            //    newuser.courseid = "1";



            string jsonData = JsonConvert.SerializeObject(newuser);
            // var client = new HttpClient();

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(UsersURL);


            string jsonData2 =
            @"{
            ""username"" : ""Geir3"", 
            ""passphrase"" : ""636366"",
            ""email"" : ""Geireman2@gmail.com"",
            ""firstname"" : ""GGgu2"",
            ""lastname"" : ""Gundersen2"", 
            ""phone"" : ""46644554"",
            ""courseid"" : ""1""}";


            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(UsersURL, content);

            // this result string should be something like: "{"token":"rgh2ghgdsfds"}"
            var result = await response.Content.ReadAsStringAsync();
            System.Diagnostics.Debug.WriteLine(result);
                }
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine("Nay");
                System.Diagnostics.Debug.WriteLine("CAUGHT EXCEPTION:");
                System.Diagnostics.Debug.WriteLine(exception);
            }

            return;



            //var client = new HttpClient();
            // client.BaseAddress = new Uri("http://146.185.164.20:57483/users");

            User newUser = new User();
            newUser.Username = username;
            newUser.Firstname = firstName;
            newUser.Lastname = lastName;
            newUser.Password = password;
            newUser.Email = email;

         //   string json = JsonConvert.SerializeObject(newUser);

            try
            {
                using (var client1 = new HttpClient())
                {
                    string jsonData1 = @"{
            ""username"" : ""Geir2"", 
            ""passphrase"" : ""636366"",
            ""email"" : ""Geireman@gmail.com"",
            ""firstname"" : ""GGgu2"",
            ""lastname"" : ""Gundersen2"", 
            ""phone"" : ""46644554"",
            ""courseid"" : ""1"",}";

                    var content1 = new StringContent(
                    JsonConvert.SerializeObject(new { jsonData1 }));
                    var result1 = await client1.PostAsync("http://146.185.164.20:57483/users", content1).ConfigureAwait(false);
                    if (result1.IsSuccessStatusCode)
                    {
                        var tokenJson = await result1.Content.ReadAsStringAsync();
                        System.Diagnostics.Debug.WriteLine(tokenJson);
                    }
                }
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine("Nay");
                System.Diagnostics.Debug.WriteLine("CAUGHT EXCEPTION:");
                System.Diagnostics.Debug.WriteLine(exception);
            }
        }

        public static async Task RegisterNewUsr(string username, string firstName, string lastName, string password, string email)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://146.185.164.20:57483/users");

            User newUser = new User();
            newUser.Username = username;
            newUser.Firstname = firstName;
            newUser.Lastname = lastName;
            newUser.Password = password;
            newUser.Email = email;

            string json = JsonConvert.SerializeObject(newUser);

            //   string CompleteJsonData = "";

            // string jsonData =
            //   @"{
            //   ""username"" : ""Staurheim55"", 
            //   ""passphrase"" : ""Staurheimspylsa55"",
            //   ""email"" : ""cam-bridge@hotmail55.com"",
            //   ""firstname"" : ""Gunnar55"",
            //   ""lastname"" : ""Burka55"" 
            //   }";


            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("http://146.185.164.20:57483/users", content);

            // this result string should be something like: "{"token":"rgh2ghgdsfds"}"
            var result = await response.Content.ReadAsStringAsync();
            System.Diagnostics.Debug.WriteLine(result);
        }
    }

    public class RootObjectTest
    {
        public string username { get; set; }
        public string passphrase { get; set; }
        public string email { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string phone { get; set; }
        public string courseid { get; set; }
    }

    public class NewBook
    {
        public string userid = "";
        public string universityid = "";
        public string courseid = "";
        public string adname = "";

        public string text = "";
        public string pinned = "";
        public string deleted = "";
    }
}


