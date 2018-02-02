using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace AppForms
{
    public class GetData
    {
        public static async void GetLogin(Action<Modelo.DatosLogin> success, Action error, String userName, String password)
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

                    Modelo.DatosLogin datosLogin = JsonConvert.DeserializeObject<Modelo.DatosLogin>(json);
                    success(datosLogin);
                }
            }
        }

        public static async void SetUsuario(Action<Modelo.DatosRegistro> success, Action error, Modelo.DatosRegistro datosRegistro)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://baas.kinvey.com/user/kid_SyXkBdMVM");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            httpWebRequest.Headers["Authorization"] = "Basic a2lkX1N5WGtCZE1WTToyOGQwOThmOTQ0N2Q0OWNmYmI0MTUwN2FjOWU3MDZiOA==";
            httpWebRequest.Headers["X-Kinvey-API-Version"] = "3";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{\"username\":\"" + datosRegistro.username + "\"," +
                              "\"password\":\"" + datosRegistro.password + "\"," +
                              "\"name\":\"" + datosRegistro.name + "\"," +
                              "\"phone\":\"" + datosRegistro.phone + "\"," +
                              "\"mail\":\"" + datosRegistro.mail + "\"}";

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

                    Modelo.DatosRegistro datosRegistroJ = JsonConvert.DeserializeObject<Modelo.DatosRegistro>(json);
                    success(datosRegistroJ);
                }
            }
        }

        public static async void GetMovies(Action<Modelo.DatosMovies[]> success, Action error, String Kinvey)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://baas.kinvey.com/appdata/kid_SyXkBdMVM/movies");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";

            httpWebRequest.Headers["Authorization"] = string.Format("Kinvey {0}", Kinvey);
            httpWebRequest.Headers["X-Kinvey-API-Version"] = "3";

            using (WebResponse response = await httpWebRequest.GetResponseAsync())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream);
                    String json = reader.ReadToEnd();

                    Modelo.DatosMovies[] movies = JsonConvert.DeserializeObject<Modelo.DatosMovies[]>(json);

                    success(movies);
                }
            }
        }
    }
}
