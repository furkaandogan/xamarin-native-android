using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace Odev.Droid
{
    [Activity(Label = "Odev.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        ListView evListView;
        Button refreshListButton;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            evListView = this.FindViewById<ListView>(Resource.Id.expandableListView1);
            refreshListButton = FindViewById<Button>(Resource.Id.refreshListButton);

            refreshListButton.Click += delegate
            {
                LoadEvList();
            };

            LoadEvList();
        }


        protected void LoadEvList()
        {

            if (evListView != null)
            {
                Models.Result<List<Models.Ev>> evListResult = Models.Ev.GetList(0, 20);
                if (evListResult.IsOk)
                {
                    Adapters.EvAdapter evAdapter = new Adapters.EvAdapter(this, evListResult.Data);
                    evListView.SetAdapter(evAdapter);
                }
            }
        }

    }
}

