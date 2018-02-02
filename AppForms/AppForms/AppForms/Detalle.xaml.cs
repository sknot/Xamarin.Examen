using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppForms
{
	public partial class Detalle : ContentPage
	{
        public Modelo.DatosMovies DatosMovies { get; set; }
		public Detalle ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            this.Title = "Detalle";

            this.lblTitulo.Text = this.DatosMovies.title;
            this.lblDescripcion.Text = "Descripción: " + this.DatosMovies.description;
            this.lblCategoria.Text = "Categoría: " + this.DatosMovies.category;
            this.lblRating.Text = "Rating: " + this.DatosMovies.rating;
            this.imgPelicula.Source = ImageSource.FromUri(new Uri(this.DatosMovies.image));
        }

        protected override bool OnBackButtonPressed()
        {
            this.Navigation.PopAsync();
            return base.OnBackButtonPressed();
        }
    }
}