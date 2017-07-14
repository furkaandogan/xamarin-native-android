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

namespace Odev.Droid.Adapters
{
    class ImageAdapter : ArrayAdapter<Models.Resim>
    {
        private LayoutInflater _layout;
        public ImageAdapter(Context context, List<Models.Resim> imgList) : base(context, 0, imgList)
        {
            _layout = ((LayoutInflater)Context.GetSystemService(Context.LayoutInflaterService));
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            Models.Resim resim = GetItem(position);
            if (convertView == null)
            {
                convertView = _layout.Inflate(Resource.Layout.ImageItem, null);
            }
            if (resim != null && convertView != null)
            {
                ImageView imgView = convertView.FindViewById<ImageView>(Resource.Id.imgItem);
                if (imgView != null)
                {
                    URL _url = new URL(resim.Yol);
                    Bitmap bmp = BitmapFactory.DecodeStream(_url.OpenStream());
                    imgView.SetImageBitmap(bmp);
                }
                convertView.Click += delegate
                {
                    OpenImage(resim);
                };
            }
            return convertView;
        }

        private void OpenImage(Models.Resim resim)
        {
            if (resim == null)
                return;

            View evDetay = _layout.Inflate(Resource.Layout.EvDetay, null);
            if (evDetay != null)
            {
                ImageView mainIamge = evDetay.FindViewById<ImageView>(Resource.Id.anaResim);
                if (mainIamge != null)
                {
                    URL url = new URL(resim.Yol);
                    Bitmap bmp = BitmapFactory.DecodeStream(url.OpenStream());
                    mainIamge.SetImageBitmap(bmp);
                }

            }
        }
    }
}