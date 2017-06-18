using Android.App;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;

namespace Lab09
{
    [Activity(Label = "Lab09", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override async void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            await ValidateActivityAsync();
        }

        private async Task ValidateActivityAsync()
        {
            SALLab09.ServiceClient client = new SALLab09.ServiceClient();
            var response = await client.ValidateAsync("mail@mail.com", "c0nTr4$3Ñª",
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

