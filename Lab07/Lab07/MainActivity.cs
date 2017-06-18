using Android.App;
using Android.Widget;
using Android.OS;

namespace Lab07
{
    [Activity(Label = "Lab07", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var btnValidade = FindViewById<Button>(Resource.Id.btnValidar);
            var txtEmail = FindViewById<EditText>(Resource.Id.txtEmail);
            var txtPassword = FindViewById<EditText>(Resource.Id.txtPassword);
            var lblResponse = FindViewById<TextView>(Resource.Id.lblResult);

            btnValidade.Click += async delegate
            {
                if (string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    return;
                }

                SALLab07.ServiceClient client = new SALLab07.ServiceClient();
                var response = await client.ValidateAsync(txtEmail.Text, 
                    txtPassword.Text, Android.Provider.Settings.Secure.GetString(ContentResolver, 
                    Android.Provider.Settings.Secure.AndroidId));

                if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
                {
                    var builder = new Notification.Builder(this)
                        .SetContentTitle("Validación de actividad")
                        .SetContentText(
                            $"{response.Status} {response.Fullname} {response.Token}")
                        .SetSmallIcon(Resource.Drawable.Icon);

                    builder.SetCategory(Notification.CategoryMessage);

                    var objectNotification = builder.Build();
                    var manager = GetSystemService(NotificationService) as NotificationManager;
                    manager.Notify(0, objectNotification);
                }
                else
                {
                    lblResponse.Text = 
                        $"{response.Status} \n{response.Fullname} \n{response.Token}";
                }
            };
        }
    }
}

