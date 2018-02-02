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

            ListView lista = (ListView)this.FindViewById(Resource.Id.lvLista);
            ListViewAdapter adapter = new ListViewAdapter(lista);

        }
    }
}