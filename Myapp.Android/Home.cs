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
using Android.Support.V4.Widget;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.Design.Widget;
using Android.Support.V7.App;

namespace Myapp.Droid
{
    [Activity(Label = "Home", Theme = "@style/Theme.DesignDemo")]
    public class Home : AppCompatActivity
    {
        DrawerLayout drawerLayout;
        NavigationView navigationView;
        View navTextView;
        TextView username;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Home);

            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            var toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);

            SetSupportActionBar(toolbar);

            var drawerToggle = new ActionBarDrawerToggle(this, drawerLayout, toolbar, Resource.String.drawer_open, Resource.String.drawer_close);

            drawerLayout.SetDrawerListener(drawerToggle);
            drawerToggle.SyncState();

            navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            setupDrawerContent(navigationView);

            navTextView = navigationView.GetHeaderView(0);
            username = navTextView.FindViewById<TextView>(Resource.Id.navheader_username);

            username.Text = Intent.GetStringExtra("username").ToString();
        }

        void setupDrawerContent(NavigationView navigationView)
        {
            navigationView.NavigationItemSelected += (sender, e) =>
            {
                e.MenuItem.SetChecked(true);

                int id = e.MenuItem.ItemId;

                if (id == Resource.Id.nav_home)
                {
                    Toast.MakeText(this, "Home", ToastLength.Short).Show();
                } else if (id == Resource.Id.nav_logout)
                {
                    var dialog = new Android.App.AlertDialog.Builder(this);
                    dialog.SetMessage("Are You Sure ?");
                    dialog.SetNeutralButton("Yes", delegate {
                        StartActivity(new Intent(this,typeof(MainActivity)));
                        Finish();
                    });
                    dialog.SetNegativeButton("No", delegate { });
                    dialog.Show();
                }

                drawerLayout.CloseDrawers();
            };
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            navigationView.InflateMenu(Resource.Menu.nav_menu); //Navigation Drawer Layout Menu Creation  
            return true;
        }
    }
}