using Android.App;
using Android.Widget;
using Android.OS;

namespace Lab14
{
    [Activity(Label = "Lab14", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            FindViewById<Button>(Resource.Id.buttonValidate).Click += async (sender, e) =>
            {
                var client = new SALLab14.ServiceClient();
                var result = await client.ValidateAsync(this);

                AlertDialog.Builder builder = new AlertDialog.Builder(this);
                AlertDialog alert = builder.Create();
                alert.SetTitle("Resultado de la verificación");
                alert.SetIcon(Resource.Drawable.Icon);
                alert.SetMessage($"{result.Status}\n{result.FullName}\n{result.Token}");
                alert.SetButton("OK", (s, ev) => { });
                alert.Show();
            };
        }
    }
}

