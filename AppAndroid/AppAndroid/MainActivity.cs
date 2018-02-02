using Android.App;
using Android.Widget;
using Android.OS;
using AppAndroid.Fragments;
using System.Collections.Generic;

namespace AppAndroid
{
    [Activity(Label = "AppAndroid", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //                                              //Validamos si existe un fragment en el mainContainer
            //if (savedInstanceState == null)
            //{
            //    //                                          //Creamos una nueva intancia para el fragmente que vamos
            //    //                                          //      a cargar al mainContainer
            //    Fragment fragment = LoginFragment.NewInstance();

            //    //                                          //Creamos la transaccion
            //    FragmentManager manager = this.FragmentManager;
            //    FragmentTransaction transaction = manager.BeginTransaction();

            //    //                                          //Agregamos el fragment al mainContainer
            //    transaction.Add(Resource.Id.mainContainer, fragment);

            //    transaction.Commit();
            //}

            ListView lvLista = this.FindViewById(Resource.Id.lvLista) as ListView;





            var lista = this.generateDummy(20);
            ListViewAdapter adapter = new ListViewAdapter(lista);

            lvLista.Adapter = adapter;
        }

        private IList<ListViewAdapterViewHolder> generateDummy(int count)
        {

            IList<ListViewAdapterViewHolder> lista = new List<ListViewAdapterViewHolder>();

            for (int i = 0; i < count; i = i + 1)
            {

                ListViewAdapterViewHolder song = new ListViewAdapterViewHolder();

                song.Title = "Title " + i;
                song.Subtitle = "Subtitle " + i;

                lista.Add(song);

            }

            return lista;

        }
    }
}

