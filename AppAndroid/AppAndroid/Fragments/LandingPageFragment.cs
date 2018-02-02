using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace AppAndroid.Fragments
{
    public class LandingPageFragment : Fragment
    {
        private String authtoken;
        public static LandingPageFragment NewInstance(Mod.DatosLogin datosLogin)
        {
            LandingPageFragment fragment = new LandingPageFragment();
            fragment.Arguments = new Bundle();
            fragment.Arguments.PutString("authtoken", datosLogin._kmd.authtoken);
            return fragment;
        }
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
            if (this.Arguments != null)
            {
                this.authtoken = this.Arguments.GetString("authtoken");
            }
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            var view = inflater.Inflate(Resource.Layout.LandingPageLayout, container, false);

            ListView lvLista = view.FindViewById(Resource.Id.lvLista) as ListView;

            ListViewAdapter adapter = new ListViewAdapter(generateDummy(20));

            lvLista.Adapter = adapter;

            return view;
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
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