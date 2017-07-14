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
using Android.Graphics;
using Java.Net;
using Android.Media;

namespace Odev.Droid.Adapters
{
    public class EvAdapter : ArrayAdapter<Models.Ev>
    {
        private LayoutInflater _layout;
        public EvAdapter(Context context, List<Models.Ev> evList) : base(context, 0, evList)
        {
            _layout = ((LayoutInflater)Context.GetSystemService(Context.LayoutInflaterService));
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            Models.Ev ev = GetItem(position);
            if (convertView == null)
            {
                convertView = _layout.Inflate(Resource.Layout.EvItem, null);
            }
            if (ev != null && convertView != null)
            {
                ImageView imgView = convertView.FindViewById<ImageView>(Resource.Id.Image);
                TextView fiyatText = convertView.FindViewById<TextView>(Resource.Id.Fiyat);
                TextView ilText = convertView.FindViewById<TextView>(Resource.Id.Il);
                TextView konutText = convertView.FindViewById<TextView>(Resource.Id.KonutTip);
                URL url = new URL(ev.MainResimYolu);
                Bitmap bmp = BitmapFactory.DecodeStream(url.OpenStream());
                imgView.SetImageBitmap(bmp);
                fiyatText.SetText(ev.Fiyat.ToString("N0") + " Tl", TextView.BufferType.Normal);
                ilText.SetText(ev.Il, TextView.BufferType.Normal);
                konutText.SetText(ev.EmlakTip, TextView.BufferType.Normal);
                convertView.Click += delegate
                {
                    OpenDetail(ev);
                };
            }
            return convertView;
        }

        private void OpenDetail(Models.Ev ev)
        {
            Intent intent = new Intent(this.Context,typeof(DetailActivity));

            Bundle param = new Bundle(1);
            param.PutInt("Id", ev.ID);
            intent.PutExtras(param);

            this.Context.StartActivity(intent);
        }
    }
}