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
    [Activity(Label = "LandingActivity", MainLauncher = true)]
    public class LandingActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.LandingLayout);

            ListView lvLista = (ListView)this.FindViewById(Resource.Id.lvLista);
            var lista = this.generateDummy(20);

            ListViewAdapter adapter = new ListViewAdapter(lista);

            lvLista.Adapter = adapter;
        }

        private IList<Modelo.DatosMovies> generateDummy(int count)
        {
            IList<Modelo.DatosMovies> lista = new List<Modelo.DatosMovies>();

            for (int i = 0; i < count; i = i + 1)
            {
                Modelo.DatosMovies movie = new Modelo.DatosMovies();

                movie.title = "Title " + i;
                movie.category = "Category " + i;

                lista.Add(movie);
            }

            return lista;
        }
    }
}