using Android.App;
using Android.Widget;
using Android.OS;

namespace Lab13
{
    [Activity(Label = "Lab13", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            FindViewById<ImageButton>(Resource.Id.imageButton).Click += async (sender, e) =>
            {
                var client = new SALLab13.ServiceClient();
                string email = "mail@mail.com";
                string password = "rocaroca";
                var result = await client.ValidateAsync(this, email, password);

                AlertDialog.Builder builder = new AlertDialog.Builder(this);
                AlertDialog alert = builder.Create();
                alert.SetTitle("Resultado de la verificación");
                alert.SetIcon(Resource.Drawable.Icon);
                alert.SetMessage($"{result.Status}\n{result.FullName}\n{result.Token}");
                alert.SetButton("Ok", delegate { });
                alert.Show();
            };
        }
    }
}

