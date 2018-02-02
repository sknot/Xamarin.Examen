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

namespace AppAdroid_Navegation
{
    class ListViewAdapter : BaseAdapter
    {

        private IList<Modelo.DatosMovies> movies;

        public ListViewAdapter(IList<Modelo.DatosMovies> movies)
        {
            this.movies = movies;
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return this.movies[position];
        }

        public override long GetItemId(int position)
        {
            return this.GetItem(position).GetHashCode();
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            if (convertView == null)
            {
                var inflater = LayoutInflater.From(parent.Context);

                convertView = inflater.Inflate(Resource.Layout.ItemLayout, parent, false);
            }

            Modelo.DatosMovies movie = (Modelo.DatosMovies)this.GetItem(position);

            TextView tvTitle = (TextView)convertView.FindViewById(Resource.Id.tvTitle);
            TextView tvCategory = (TextView)convertView.FindViewById(Resource.Id.tvCategory);

            tvTitle.Text = movie.title;
            tvCategory.Text = movie.category;

            return convertView;
        }

        public override int Count
        {
            get
            {
                return this.movies.Count;
            }
        }

    }
}