using Android.App;
using Android.Widget;
using Android.OS;
using System;
using System.Linq;

namespace MaratonaXamarin.AndroidApp
{
    [Activity(Label = "MaratonaXamarin.AndroidApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            var button = this.FindViewById<Button>(Resource.Id.btnCarregar);
            var listview = this.FindViewById<ListView>(Resource.Id.lvwItens);

            button.Click += async (sender,e) =>
            {
                var api = new Shared.UserApi();
                var users = await api.ListAsync(new Shared.Developer
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Rhuan",
                    Email = "test@email.com",
                    State = "RJ",
                    City = "Rio de Janeiro"
                });

                listview.Adapter = new ArrayAdapter(this,
                                                    Android.Resource.Layout.SimpleListItemSingleChoice,
                                                    users.OrderBy(y => y.Name)
                                                         .Select(x => $"{x.Id} {x.Name}")
                                                         .ToArray()
                                                    );
            }; 
            
        }
        
    }
}

