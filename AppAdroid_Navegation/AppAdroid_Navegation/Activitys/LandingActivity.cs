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

namespace AppAdroid_Navegation.Activitys
{
    [Activity(Label = "LandingActivity")]
    public class LandingActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.LandingLayout);

            Intent intent = this.Intent;

            ListView lvLista = (ListView)this.FindViewById(Resource.Id.lvLista);
            var lista = this.GetIListMovies(intent.GetStringExtra("authtoken"));

            ListViewAdapter adapter = new ListViewAdapter(lista);

            lvLista.Adapter = adapter;
        }

        private IList<Modelo.DatosMovies> GetIListMovies(string authtoken)
        {
            IList<Modelo.DatosMovies> lista = new List<Modelo.DatosMovies>();

            GetData.GetMovies((datosMovies) => {
                if (datosMovies != null)
                {
                    foreach (var DatoMovie in datosMovies)
                    {
                        lista.Add(DatoMovie);
                    }
                }
                else
                {
                    Toast.MakeText(this, "No hay datos de peliculas", ToastLength.Short).Show();
                }
            }, () => {
            }, authtoken);
            
            return lista;
        }
    }
}