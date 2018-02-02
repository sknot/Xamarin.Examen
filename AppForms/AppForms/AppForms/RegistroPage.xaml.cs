using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppForms
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegistroPage : ContentPage
	{
		public RegistroPage ()
		{
			InitializeComponent ();

            this.Title = "Registro";

            this.btnRegistrar.Clicked += (sender, e) =>
            {
                if (string.IsNullOrEmpty(this.eNombre.Text))
                {
                    DisplayAlert("Informacion", "Favor de ingresar tu nombre", "Aceptar");
                }
                else if (string.IsNullOrEmpty(this.eNombreUsuario.Text))
                {
                    DisplayAlert("Informacion", "Favor de ingresar tu nombre de usuario", "Aceptar");
                }
                else if (string.IsNullOrEmpty(this.eTelefono.Text))
                {
                    DisplayAlert("Informacion", "Favor de ingresar tu telefono", "Aceptar");
                }
                else if (string.IsNullOrEmpty(this.eEmail.Text))
                {
                    DisplayAlert("Informacion", "Favor de ingresar tu correo electronico", "Aceptar");
                }
                else if (string.IsNullOrEmpty(this.ePassword.Text))
                {
                    DisplayAlert("Informacion", "Favor de ingresar tu contraseña", "Aceptar");
                }
                else if (string.IsNullOrEmpty(this.eConfirmarPassword.Text))
                {
                    DisplayAlert("Informacion", "Favor de ingresar tu confirmacion de contraseña", "Aceptar");
                }
                else if (this.ePassword.Text != this.eConfirmarPassword.Text)
                {
                    this.ePassword.Text = string.Empty;
                    this.eConfirmarPassword.Text = string.Empty;

                    DisplayAlert("Informacion", "La contraseña y la confirmacion deben ser iguales", "Aceptar");
                }
                else
                {
                    GetData.SetUsuario((datosRegistro) => {
                        if (datosRegistro != null)
                        {
                            var MainPage = new MainPage();
                            this.Navigation.PushAsync(MainPage);
                        }
                        else
                        {
                            this.eNombre.Text = string.Empty;
                            this.eNombreUsuario.Text = string.Empty;
                            this.eTelefono.Text = string.Empty;
                            this.eEmail.Text = string.Empty;
                            this.ePassword.Text = string.Empty;
                            this.eConfirmarPassword.Text = string.Empty;

                            DisplayAlert("Información", "El usuario ya existe.", "Aceptar");
                        }
                    }, () => {
                        System.Diagnostics.Debug.WriteLine("Error - Error al consumir el servicio Registro");
                    }, new Modelo.DatosRegistro
                    {
                        name = this.eNombre.Text,
                        username = this.eNombreUsuario.Text,
                        phone = this.eTelefono.Text,
                        mail = this.eEmail.Text,
                        password = this.ePassword.Text
                    });
                }
            };
        }

        protected override void OnDisappearing()
        {
            this.eNombre.Text = string.Empty;
            this.eNombreUsuario.Text = string.Empty;
            this.eTelefono.Text = string.Empty;
            this.eEmail.Text = string.Empty;
            this.ePassword.Text = string.Empty;
            this.eConfirmarPassword.Text = string.Empty;
        }
    }
}