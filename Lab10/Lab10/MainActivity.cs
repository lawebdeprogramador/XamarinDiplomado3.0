using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content.Res;
using System.IO;
using Android.Content;

namespace Lab10
{
    [Activity(Label = "@string/ApplicationName", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int _counter = 0;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var contentHeader = FindViewById<TextView>(Resource.Id.ContentHeader);
            contentHeader.Text = GetString(Resource.String.ContentHeader);
            var clickMe = FindViewById<Button>(Resource.Id.ClickMe);
            var clickCounter = FindViewById<TextView>(Resource.Id.ClickCounter);
            var validate = FindViewById<Button>(Resource.Id.Validate);

            clickMe.Click += (sender, e) =>
            {
                _counter++;
                clickCounter.Text = Resources.GetQuantityString(Resource.Plurals.numberOfClicks, _counter, _counter);

                var player = Android.Media.MediaPlayer.Create(this, Resource.Raw.sound);
                player.Start();
            };

            validate.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(ValidateActivity));
                StartActivity(intent);
            };

            AssetManager manager = Assets;

            using (var reader = new StreamReader(manager.Open("Contenido.txt")))
            {
                contentHeader.Text += $"\n\n{reader.ReadToEnd()}";
            }
        }
    }
}

