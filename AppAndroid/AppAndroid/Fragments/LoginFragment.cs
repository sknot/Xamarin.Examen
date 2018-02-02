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
    public class LoginFragment : Fragment
    {
        public static LoginFragment NewInstance()
        {
            LoginFragment fragment = new LoginFragment();
            fragment.Arguments = new Bundle();
            return fragment;
        }
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            return inflater.Inflate(Resource.Layout.LoginLayout, container, false);
        }
        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            EditText etUserName = (EditText)this.View.FindViewById(Resource.Id.etUserName);
            EditText etPassword = (EditText)this.View.FindViewById(Resource.Id.etPassword);

            Button btnLogin = (Button)this.View.FindViewById(Resource.Id.btnLogin);
            btnLogin.Click += delegate
            {
                ProgressDialog dialog = ProgressDialog.Show(view.Context, "", "Cargando. Por Favor Espere...", true);

                if (string.IsNullOrEmpty(etUserName.Text))
                {
                    dialog.Hide();
                    Toast.MakeText(view.Context, "Favor de ingresar el usuario", ToastLength.Short).Show();
                }
                else if (string.IsNullOrEmpty(etPassword.Text))
                {
                    dialog.Hide();
                    Toast.MakeText(view.Context, "Favor de ingresar el Password", ToastLength.Short).Show();
                }
                else {
                    DA.GetData.GetLogin((datosLogin) => {
                        dialog.Hide();
                        if (datosLogin != null)
                        {
                            Siguiente(LandingPageFragment.NewInstance(datosLogin));
                        }
                        else
                        {
                            Toast.MakeText(view.Context, "Credenciales incorrectas", ToastLength.Short).Show();
                        }
                    }, () => {
                        System.Diagnostics.Debug.WriteLine("Error - Error al consumir el servicio Login");
                    }, etUserName.Text, etPassword.Text);
                }
            };

            Button btnRegistro = (Button)this.View.FindViewById(Resource.Id.btnRegistro);
            btnRegistro.Click += delegate {
                Siguiente(RegistroFragment.NewInstance());
            };
        }
        public void Siguiente(Fragment fragment)
        {
            var transaction = this.FragmentManager.BeginTransaction();

            //transaction.Replace(Resource.Id.mainContainer, fragment);
            transaction.AddToBackStack(null);
            transaction.Commit();
        }
    }
}