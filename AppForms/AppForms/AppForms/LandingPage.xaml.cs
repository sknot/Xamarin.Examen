using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace AppForms
{
	public partial class LandingPage : ContentPage
	{
        public string authtoken { get; set; }

        public LandingPage ()
		{
			InitializeComponent ();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            this.Title = "Películas";

            this.lvLista.ItemsSource = GetCollection(this.authtoken);

            this.lvLista.RowHeight = 75;
            
            this.lvLista.ItemTapped += (object sender, ItemTappedEventArgs e) => {

                Modelo.DatosMovies movies = e.Item as Modelo.DatosMovies;

                var detalle = new Detalle();
                detalle.DatosMovies = movies;
                this.Navigation.PushAsync(detalle);
            };
        }

        public ObservableCollection<Modelo.DatosMovies> GetCollection(string authtoken) {
            ObservableCollection<Modelo.DatosMovies> adapter = new ObservableCollection<Modelo.DatosMovies>();

            GetData.GetMovies((datosMovies) => {
                if (datosMovies != null)
                {
                    foreach (var DatoMovie in datosMovies)
                    {
                        adapter.Add(DatoMovie);
                    }
                }
                else
                {
                    DisplayAlert("Información", "No hay datos de peliculas", "Aceptar");
                }
            }, () => {
            }, authtoken);

            return adapter;
        }

    }
}