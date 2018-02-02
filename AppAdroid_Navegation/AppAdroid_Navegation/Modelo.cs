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

namespace AppAdroid_Navegation
{
    public class Modelo
    {
        public class DatosLogin
        {
            public String _id { get; set; }
            public String userName { get; set; }
            public kmd _acl { get; set; }
            public String name { get; set; }
            public String phone { get; set; }
            public String mail { get; set; }
            public kmd _kmd { get; set; }

            public class acl
            {
                public String creator { get; set; }
            }
            public class kmd
            {
                public String lmt { get; set; }
                public String ect { get; set; }
                public String authtoken { get; set; }
            }
            public override string ToString()
            {
                return string.Format("[DatosLogin: _id={0}, userName={1}, name={2}, phone={3}, mail={4}]", _id, userName, name, phone, mail);
            }
        }

        public class DatosRegistro
        {
            public string _Id { get; set; }
            public string username { get; set; }
            public string password { get; set; }
            public string name { get; set; }
            public string phone { get; set; }
            public string mail { get; set; }
        }

        public class DatosMovies : Java.Lang.Object
        {
            public String _id { get; set; }
            public String title { get; set; }
            public String image { get; set; }
            public String category { get; set; }
            public String rating { get; set; }
            public String description { get; set; }

            public DatosMovies()
            {
            }

            public override string ToString()
            {
                return string.Format("[MovieModel: _id={0}, title={1}, image={2}, category={3}, description={4}, rating={5}]", _id, title, image, category, description, rating);
            }
        }
    }
}