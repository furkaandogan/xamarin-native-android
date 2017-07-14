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
using Java.IO;
using System.IO;

namespace Odev.Droid
{
    [Activity(Label = "DetailActivity")]
    public class DetailActivity : Activity
    {
        private int Id;

        private TextView aciklamaText;
        private TextView fiyatText;
        private TextView konutTipText;
        private TextView alanText;
        private TextView bulunduguKatText;
        private TextView odaSayisiText;
        private TextView binaYasiText;
        private TextView ilText;
        private ImageView anaResim;
        private ListView resimlerList;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            if (Intent != null && Intent.Extras != null)
                Id = Intent.Extras.GetInt("Id");

            // Create your application here
            SetContentView(Resource.Layout.EvDetay);
            anaResim = FindViewById<ImageView>(Resource.Id.anaResim);
            aciklamaText = FindViewById<TextView>(Resource.Id.açýklama);
            konutTipText = FindViewById<TextView>(Resource.Id.konutTip);
            fiyatText = FindViewById<TextView>(Resource.Id.fiyat);
            alanText = FindViewById<TextView>(Resource.Id.alan);
            odaSayisiText = FindViewById<TextView>(Resource.Id.odaSayisi);
            binaYasiText = FindViewById<TextView>(Resource.Id.binaYasi);
            bulunduguKatText = FindViewById<TextView>(Resource.Id.bulunduguKat);
            ilText = FindViewById<TextView>(Resource.Id.il_d);
            resimlerList = FindViewById<ListView>(Resource.Id.resimler);

            LoadEvDetail();
        }


        protected void LoadEvDetail()
        {
            Models.Result<Models.Ev> evDetailResult = Models.Ev.GetDetay(Id);
            if (evDetailResult.IsOk)
            {
                konutTipText.SetText("Emplak Tipi: " + evDetailResult.Data.EmlakTip, TextView.BufferType.Normal);
                fiyatText.SetText("Fiyat: " + evDetailResult.Data.Fiyat.ToString("N") + " TL", TextView.BufferType.Normal);
                alanText.SetText("Alan: " + evDetailResult.Data.Alan.ToString(), TextView.BufferType.Normal);
                odaSayisiText.SetText("Oda Sayýsý: " + evDetailResult.Data.OdaSayisi.ToString(), TextView.BufferType.Normal);
                bulunduguKatText.SetText("Bulunduðu Kat: " + evDetailResult.Data.BulunduguKat, TextView.BufferType.Normal);
                binaYasiText.SetText("Bina Yaþý: " + evDetailResult.Data.BinaYasi, TextView.BufferType.Normal);
                binaYasiText.SetText("Ýl: " + evDetailResult.Data.Il, TextView.BufferType.Normal);
                aciklamaText.SetText("Açýklama: " + evDetailResult.Data.Aciklama, TextView.BufferType.Normal);
                URL url = new URL(evDetailResult.Data.MainResimYolu);
                Bitmap bmp = BitmapFactory.DecodeStream((Stream)url.OpenStream());
                anaResim.SetImageBitmap(bmp);
                Adapters.ImageAdapter imgAdapter = new Adapters.ImageAdapter(this, evDetailResult.Data.Resimler);
                resimlerList.SetAdapter(imgAdapter);
            }
        }
    }
}