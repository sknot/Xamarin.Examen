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

namespace AppAndroid
{
    class ListViewAdapter : BaseAdapter
    {

        private IList<ListViewAdapterViewHolder> canciones;

        public ListViewAdapter(IList<ListViewAdapterViewHolder> canciones)
        {
            this.canciones = canciones;
        }


        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View reusableView, ViewGroup parent)
        {
            if (reusableView == null)
            {

                var inflater = LayoutInflater.From(parent.Context);

                reusableView = inflater.Inflate(Resource.Layout.ItemLayout,
                                               parent,
                                                false);

            }

            ListViewAdapterViewHolder song = (ListViewAdapterViewHolder)this.GetItem(position);

            TextView tvTitle = (TextView)reusableView.FindViewById(Resource.Id.tvTitle);
            TextView tvSubTitle = reusableView.FindViewById(Resource.Id.tvSubtitle)
                                              as TextView;

            tvTitle.Text = song.Title;

            tvSubTitle.Text = song.Subtitle;

            return reusableView;
        }

        //Fill in cound here, currently 0
        public override int Count
        {
            get
            {
                return this.canciones.Count;
            }
        }

    }

    class ListViewAdapterViewHolder : Java.Lang.Object
    {
        public String Title { get; set; }

        public String Subtitle { get; set; }

        public String PublishDate { get; set; }

        public ListViewAdapterViewHolder()
        {
        }

        public override string ToString()
        {
            return string.Format("[CancionModel: Title={0}, Subtitle={1}, PublishDate={2}]", Title, Subtitle, PublishDate);
        }
    }
}