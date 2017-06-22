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

namespace Myapp.Droid
{
    [Activity(Label = "Login")]
    public class Login : Activity
    {
        Button login;
        EditText email, password;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Login);
            // Create your application here

            login = FindViewById<Button>(Resource.Id.loginButton);
            email = FindViewById<EditText>(Resource.Id.email);
            password = FindViewById<EditText>(Resource.Id.password);

            login.Click += (sender, e) =>
            {
                if (email.Text.Equals("admin@magily.net") && password.Text.Equals("Admin123"))
                {
                    Intent intent = new Intent(this, typeof(Home));
                    intent.PutExtra("username",email.Text);
                    StartActivity(intent);
                    Finish();
                }
                else
                {
                    Toast.MakeText(this, "Invalid Credentials!!", ToastLength.Short).Show();
                }
            };
        }
    }
}