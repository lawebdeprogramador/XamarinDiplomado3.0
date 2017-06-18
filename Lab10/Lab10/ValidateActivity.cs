using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Lab10
{
    [Activity(Label = "@string/ApplicationName", MainLauncher =false, Icon = "@drawable/icon")]
    public class ValidateActivity : Activity
    {
        EditText _email;
        EditText _password;
        Button _validate;
        TextView _message;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "validate" layout resource
            SetContentView(Resource.Layout.Validate);

            // Create your application here
            _email = FindViewById<EditText>(Resource.Id.Email);
            _password = FindViewById<EditText>(Resource.Id.Password);
            _validate = FindViewById<Button>(Resource.Id.ConfirmValidation);
            _message = FindViewById<TextView>(Resource.Id.ValidationMessage);

            _validate.Click += async (sender, e) => await Validate();
        }

        private async Task Validate()
        {
            SALLab10.ServiceClient client = new SALLab10.ServiceClient();
            var response = await client.ValidateAsync(_email.Text, _password.Text,
                Android.Provider.Settings.Secure.GetString(ContentResolver,
                    Android.Provider.Settings.Secure.AndroidId));

            _message.Text = $"{response.Status}\n{response.Fullname}\n{response.Token}";
        }
    }
}