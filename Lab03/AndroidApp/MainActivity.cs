using Android.App;
using Android.Widget;
using Android.OS;

namespace AndroidApp
{
    [Activity(Label = "AndroidApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            var helper = new SharedProject.MySharedCode();
            var alert = new AlertDialog.Builder(this).Create();
            alert.SetMessage(helper.GetFilePath("demo.dat"));
            alert.Show();
            Validate();

            // Set our view from the "main" layout resource
            // SetContentView (Resource.Layout.Main);
        }

        private async void Validate()
        {
            var serviceClient = new SALLab03.ServiceClient();
            string studentEmail = "mail@mail.com";
            string password = "p@$$vv0Rd";
            string myDevice = Android.Provider.Settings.Secure.GetString(ContentResolver,
                Android.Provider.Settings.Secure.AndroidId);

            var result = await serviceClient.ValidateAsync(studentEmail, password, myDevice);

            var alert = new AlertDialog.Builder(this).Create();
            alert.SetTitle("Resultado dela verificación");
            alert.SetIcon(Resource.Drawable.Icon);
            alert.SetMessage($"{result.Status}\n{result.Fullname}\n{result.Token}");
            alert.SetButton("OK", (sender, e) => { });
            alert.Show();
        }
    }
}

