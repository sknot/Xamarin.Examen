using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AppAndroid.DA
{
    public class GetData
    {
        public static async void GetLogin(Action<Mod.DatosLogin> success, Action error, String userName, String password)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://baas.kinvey.com/user/kid_SyXkBdMVM/login");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            httpWebRequest.Headers["Authorization"] = "Basic a2lkX1N5WGtCZE1WTToyOGQwOThmOTQ0N2Q0OWNmYmI0MTUwN2FjOWU3MDZiOA==";
            httpWebRequest.Headers["X-Kinvey-API-Version"] = "3";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{\"username\":\"" + userName + "\"," +
                              "\"password\":\"" + password + "\"}";

                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            using (WebResponse response = await httpWebRequest.GetResponseAsync())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream);
                    String json = reader.ReadToEnd();

                    Mod.DatosLogin datosLogin = JsonConvert.DeserializeObject<Mod.DatosLogin>(json);
                    success(datosLogin);
                }
            }
        }

        public static Mod.DatosMovies[] GetMovies()
        {
            //var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://baas.kinvey.com/appdata/kid_SyXkBdMVM/movies");
            //httpWebRequest.ContentType = "application/json";
            //httpWebRequest.Method = "GET";

            ////httpWebRequest.Headers["Authorization"] = string.Format("Kinvey {0}", Kinvey);
            //httpWebRequest.Headers["Authorization"] = "Kinvey 503d7f9f-66ec-42c1-b0c2-8327a5fdb0b2.OfSmHAj6+CeshDUJfGBJwhiH16UAI4yYYYMq35dqEpw=";
            //httpWebRequest.Headers["X-Kinvey-API-Version"] = "3";

            //using (WebResponse response = httpWebRequest.GetResponse())
            //{
            //    using (Stream stream = response.GetResponseStream())
            //    {
            //        StreamReader reader = new StreamReader(stream);
            //        String json = reader.ReadToEnd();

            //        Mod.DatosMovies[] movies = JsonConvert.DeserializeObject<Mod.DatosMovies[]>(json);

            //        return movies;
            //    }
            //}

            String url = "https://baas.kinvey.com/appdata/kid_SyXkBdMVM/movies";

            HttpWebRequest request =
                (HttpWebRequest)WebRequest.Create(new Uri(url));

            request.Headers["Authorization"] = "Basic a2lkX1N5WGtCZE1WTTowMmIxM2Y1MzYzOGU0NjZkYTI2YTI3Y2IxYzNkNTNkNg==";
            request.Headers["X-Kinvey-API-Version"] = "3";

            request.Method = "GET";

            using (WebResponse response = request.GetResponse())
            {
                using (Stream stream = response.GetResponseStream())
                {

                    StreamReader reader = new StreamReader(stream);
                    String json = reader.ReadToEnd();

                    //Mod.DatosMoviesB[] movies = JsonConvert.DeserializeObject<Mod.DatosMoviesB[]>(json);
                    Mod.DatosMovies[] datosMovies = JsonConvert.DeserializeObject<Mod.DatosMovies[]>(json);

                    return datosMovies;
                }
            }
        }
        public static async void GetMovies(Action<Mod.DatosMovies[]> success, Action error, String Kinvey)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://baas.kinvey.com/appdata/kid_SyXkBdMVM/movies");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";

            //httpWebRequest.Headers["Authorization"] = string.Format("Kinvey {0}", Kinvey);
            httpWebRequest.Headers["Authorization"] = "Kinvey 503d7f9f-66ec-42c1-b0c2-8327a5fdb0b2.OfSmHAj6+CeshDUJfGBJwhiH16UAI4yYYYMq35dqEpw=";
            httpWebRequest.Headers["X-Kinvey-API-Version"] = "3";

            using (WebResponse response = await httpWebRequest.GetResponseAsync())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream);
                    String json = reader.ReadToEnd();

                    Mod.DatosMovies[] movies = JsonConvert.DeserializeObject<Mod.DatosMovies[]>(json);

                    success(movies);
                }
            }
        }
    }
}