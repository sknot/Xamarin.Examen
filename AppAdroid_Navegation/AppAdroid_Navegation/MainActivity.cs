using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using AppAdroid_Navegation.Activitys;

namespace AppAdroid_Navegation
{
    [Activity(Label = "AppAdroid_Navegation", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            this.Title = "Login";

            EditText etUserName = (EditText)this.FindViewById(Resource.Id.etUserName);
            EditText etPassword = (EditText)this.FindViewById(Resource.Id.etPassword);

            Button btnLogin = (Button)this.FindViewById(Resource.Id.btnLogin);
            btnLogin.Click += (sender, e) =>
            {
                ProgressDialog dialog = ProgressDialog.Show(this, "", "Cargando. Por Favor Espere...", true);

                if (string.IsNullOrEmpty(etUserName.Text))
                {
                    dialog.Hide();
                    Toast.MakeText(this, "Favor de ingresar el usuario", ToastLength.Short).Show();
                }
                else if (string.IsNullOrEmpty(etPassword.Text))
                {
                    dialog.Hide();
                    Toast.MakeText(this, "Favor de ingresar el Password", ToastLength.Short).Show();
                }
                else
                {
                    GetData.GetLogin((datosLogin) => {
                        dialog.Hide();
                        if (datosLogin != null)
                        {
                            etUserName.Text = string.Empty;
                            etPassword.Text = string.Empty;

                            var intent = new Intent(this, typeof(LandingActivity));
                            intent.PutExtra("authtoken", datosLogin._kmd.authtoken);

                            this.StartActivity(intent);
                        }
                        else
                        {
                            Toast.MakeText(this, "Credenciales incorrectas", ToastLength.Short).Show();
                        }
                    }, () => {
                        System.Diagnostics.Debug.WriteLine("Error - Error al consumir el servicio Login");
                    }, etUserName.Text, etPassword.Text);
                }
            };

            Button btnRegistrar = (Button)this.FindViewById(Resource.Id.btnRegistro);
            btnRegistrar.Click += (sender, e) =>
            {
                etUserName.Text = string.Empty;
                etPassword.Text = string.Empty;

                this.StartActivity(new Intent(this, typeof(RegistroActivity)));
            };
        }
    }
}

