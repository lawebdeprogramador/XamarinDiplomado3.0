using Android.App;
using Android.Widget;
using Android.OS;
using System;
using System.Threading.Tasks;

namespace Lab08
{
    [Activity(Label = "@string/ApplicationName", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override async void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            await ValidateActivityAsync();

            //var viewGroup = (Android.Views.ViewGroup)
            //    Window.DecorView.FindViewById(Android.Resource.Id.Content);
            //var mainLayout = viewGroup.GetChildAt(0) as LinearLayout;
            //var headerImage = new ImageView(this);
            //headerImage.SetImageResource(Resource.Drawable.Xamarin_Diplomado_30);
            //mainLayout.AddView(headerImage);
            //var userNameTextView = new TextView(this);
            //userNameTextView.Text = GetString(Resource.String.UserName);
            //mainLayout.AddView(userNameTextView);
        }

        private async Task ValidateActivityAsync()
        {
            SALLab08.ServiceClient client = new SALLab08.ServiceClient();
            var response = await client.ValidateAsync("mail@mail.com", "PizsToTheWorld",
                Android.Provider.Settings.Secure.GetString(ContentResolver,
                Android.Provider.Settings.Secure.AndroidId));

            var txtStatus = FindViewById<TextView>(Resource.Id.StatusValue);
            txtStatus.Text = response.Status.ToString();

            var txtName = FindViewById<TextView>(Resource.Id.UserNameValue);
            txtName.Text = response.Fullname;

            var txtToken = FindViewById<TextView>(Resource.Id.TokenValue);
            txtToken.Text = response.Token;
        }
    }
}

