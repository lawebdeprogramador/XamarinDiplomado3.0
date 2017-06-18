using Android.App;
using Android.Widget;
using Android.OS;
using Android.Provider;

namespace Lab12
{
    [Activity(Label = "Lab12", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private const string _email = "mail@mail.com";
        private const string _password = "s3n|-|@";

        protected async override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            // User interface elements
            var listColors = FindViewById<ListView>(Resource.Id.listView1);
            listColors.Adapter = new CustomAdapters.ColorAdapter(this, 
                Resource.Layout.ListItem, Resource.Id.textView1, 
                Resource.Id.textView2, Resource.Id.imageView1);

            // Lab validation
            string deviceInfo = Settings.Secure.GetString(ContentResolver, 
                Settings.Secure.AndroidId);
            var response = await new SALLab12.ServiceClient().ValidateAsync(_email, 
                _password, deviceInfo);
            FindViewById<TextView>(Resource.Id.ValidationMessage).Text = 
                $"{response.Status}\n{response.FullName}\n{ response.Token}";
        }
    }

    //class MyViewGroup : ViewGroup
    //{
    //    Context _viewGroupContext;

    //    public MyViewGroup(Context context) : base(context)
    //    {
    //        _viewGroupContext = context;
    //    }

    //    protected override void OnLayout(bool changed, int l, int t, int r, int b)
    //    {
    //        SetBackgroundColor(Android.Graphics.Color.Fuchsia);
    //        var myView = new View(_viewGroupContext);
    //        myView.SetBackgroundColor(Android.Graphics.Color.Blue);
    //        myView.Layout(20, 20, 150, 150);
    //        AddView(myView);
    //    }
    //}
}

