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
using System.Threading.Tasks;

namespace PhoneApp
{
    [Activity(Label = "Validar actividad", Icon = "@drawable/icon")]
    public class ValidationActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Validation);

            Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();

            // Create your application here
            var textView = FindViewById<TextView>(Resource.Id.Result);
            var validateButton = FindViewById<Button>(Resource.Id.ValidateButton);
            var emailText = FindViewById<EditText>(Resource.Id.Email);
            var passwordText = FindViewById<EditText>(Resource.Id.Password);

            validateButton.Click += async delegate
            {
                SALLab06.ServiceClient client = new SALLab06.ServiceClient();

                string email = emailText.Text;
                string password = passwordText.Text;
                string deviceInfo = Android.Provider.Settings.Secure.GetString(ContentResolver,
                    Android.Provider.Settings.Secure.AndroidId);
                var resultInfo = await client.ValidateAsync(email, password, deviceInfo);

                textView.Text = resultInfo.Status.ToString() + "\n";
                textView.Text += resultInfo.Fullname + "\n";
                textView.Text += resultInfo.Token;
            };
        }
    }
}