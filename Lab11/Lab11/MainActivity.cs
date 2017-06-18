using Android.App;
using Android.Widget;
using Android.OS;

namespace Lab11
{
    [Activity(Label = "Lab11", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private int _counter = 0;
        private Complex _data;
        private ValidationMessageWrapper _validationMessage;

        protected override void OnCreate(Bundle bundle)
        {
            Android.Util.Log.Debug("Lab11Log", "Activity A - OnCreate");

            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            FindViewById<Button>(Resource.Id.StartActivity).Click += (sender, e) =>
            {
                var activityIntent = new Android.Content.Intent(this, typeof(SecondActivity));
                StartActivity(activityIntent);
            };

            // Utilizar FragmentManager para recuperar el Fragmento
            _data = (Complex)FragmentManager.FindFragmentByTag("Data");

            if (_data == null)
            {
                // No ha sido almacenado, agregar el fragmento a la Activity
                _data = new Complex();
                var fragmentTransaction = FragmentManager.BeginTransaction();
                fragmentTransaction.Add(_data, "Data");
                fragmentTransaction.Commit();
            }

            if (bundle != null)
            {
                _counter = bundle.GetInt("CounterValue", 0);
                Android.Util.Log.Debug("Lab11Log", "Activity A - Recovered Instance State");
            }

            var clickCounter = FindViewById<Button>(Resource.Id.ClicksCounter);
            clickCounter.Text = Resources.GetString(Resource.String.ClickCounter_Text, _counter);
            clickCounter.Text += $"\n{_data.ToString()}";
            clickCounter.Click += (sender, e) =>
            {
                _counter++;
                clickCounter.Text = Resources.GetString(Resource.String.ClickCounter_Text, _counter);
                // Modificar con cualquier valor solo para verificar la persistencia
                _data.Real++;
                _data.Imaginary++;
                // Mostrar el valor de los miembros
                clickCounter.Text += $"\n{_data.ToString()}";
            };
        }

        protected override void OnStart()
        {
            Android.Util.Log.Debug("Lab11Log", "Activity A - OnStart");
            base.OnStart();
        }

        protected async override void OnResume()
        {
            Android.Util.Log.Debug("Lab11Log", "Activity A - OnResume");
            base.OnResume();

            _validationMessage = (ValidationMessageWrapper)FragmentManager.FindFragmentByTag("ValidationMessage");
            if (_validationMessage == null)
            {
                _validationMessage = new ValidationMessageWrapper();
                SALLab11.ServiceClient client = new SALLab11.ServiceClient();
                var email = "mail@mymail.com";
                var password = "p4$$vv0rd";
                var deviceInfo = Android.Provider.Settings.Secure.GetString(ContentResolver,
                    Android.Provider.Settings.Secure.AndroidId);

                var response = await client.ValidateAsync(email, password, deviceInfo);
                _validationMessage.ValidationMessage = $"{response.Status}\n{response.Fullname}\n{response.Token}";

                FindViewById<TextView>(Resource.Id.ValidationMessage).Text = _validationMessage.ValidationMessage;
                var fragmentTransaction = FragmentManager.BeginTransaction();
                fragmentTransaction.Add(_validationMessage, "ValidationMessage");
                fragmentTransaction.Commit();
            }
            else
            {
                FindViewById<TextView>(Resource.Id.ValidationMessage).Text = _validationMessage.ValidationMessage;
            }
        }

        protected override void OnPause()
        {
            Android.Util.Log.Debug("Lab11Log", "Activity A - OnPause");
            base.OnPause();
        }

        protected override void OnStop()
        {
            Android.Util.Log.Debug("Lab11Log", "Activity A - OnStop");
            base.OnStop();
        }

        protected override void OnDestroy()
        {
            Android.Util.Log.Debug("Lab11Log", "Activity A - OnDestroy");
            base.OnDestroy();
        }

        protected override void OnRestart()
        {
            Android.Util.Log.Debug("Lab11Log", "Activity A - OnRestart");
            base.OnRestart();
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            outState.PutInt("CounterValue", _counter);
            Android.Util.Log.Debug("Lab11Log", "Activity A - OnSaveInstanceState");

            base.OnSaveInstanceState(outState);
        }
    }
}

