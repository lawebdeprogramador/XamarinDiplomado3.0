using Android.App;
using Android.OS;

namespace AndroidApp
{
    [Activity(Label = "AndroidApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Validate();
        }

        private async void Validate()
        {
            SALLab02.ServiceClient serviceClient = new SALLab02.ServiceClient();

            string studentEmail = "mail@mail.com";
            string password = "_p@$$vv0Rd_";
            string myDevice = Android.Provider.Settings.Secure.GetString(ContentResolver,
                Android.Provider.Settings.Secure.AndroidId);

            SALLab02.ResultInfo result = await serviceClient.ValidateAsync(studentEmail, password, myDevice);

            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            AlertDialog alert = builder.Create();
            alert.SetTitle("Resultado de la verificación");
            alert.SetIcon(Resource.Drawable.Icon);
            string nl = System.Environment.NewLine;
            alert.SetMessage(
                $"{result.Status}{nl}{result.Fullname}{nl}{result.Token}");
            alert.SetButton("OK", (s, ev) => { });
            alert.Show();
        }
    }
}

