using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIKit;
using Xamarin.Forms;

namespace AppForms
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            this.btnLogin.Clicked += (sender, e) =>
            {
                if (string.IsNullOrEmpty(this.eUserName.Text))
                {
                    DisplayAlert("Error", "Favor de ingresar tu usuario", "Aceptar");
                }
                else if (string.IsNullOrEmpty(this.ePassword.Text))
                {
                    DisplayAlert("Error", "Favor de ingresar tu contraseña", "Aceptar");
                }
                else
                {
                    GetData.GetLogin((datosLogin) => {
                        if (datosLogin != null)
                        {
                            var LandingPage = new LandingPage();
                            LandingPage.authtoken = datosLogin._kmd.authtoken;
                            this.Navigation.PushAsync(LandingPage);
                        }
                        else {
                            this.eUserName.Text = string.Empty;
                            this.ePassword.Text = string.Empty;

                            DisplayAlert("Información", "No hay datos del usuario", "Aceptar");
                        }
                    }, () => {
                        System.Diagnostics.Debug.WriteLine("Error - Error al consumir el servicio Login");
                    }, this.eUserName.Text, this.ePassword.Text);
                }
            };

            this.btnRegistro.Clicked += (sender, e) =>
            {
                var RegistroPage = new RegistroPage();
                this.Navigation.PushAsync(RegistroPage);
            };
        }

        protected override void OnDisappearing()
        {
            this.eUserName.Text = string.Empty;
            this.ePassword.Text = string.Empty;
        }
    }
}
