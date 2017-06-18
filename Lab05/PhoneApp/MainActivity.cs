using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using System.Threading.Tasks;

namespace PhoneApp
{
    [Activity(Label = "Phone App", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        TextView textView;

        protected async override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            textView = FindViewById<TextView>(Resource.Id.Result);
            var phoneNumberText = FindViewById<EditText>(Resource.Id.PhoneNumberText);
            var translateButton = FindViewById<Button>(Resource.Id.TranslateButton);
            var callButton = FindViewById<Button>(Resource.Id.CallButton);

            callButton.Enabled = false;
            var translatedNumber = string.Empty;

            translateButton.Click += delegate
            {
                var translator = new PhoneTranslator();
                translatedNumber = translator.ToNumber(phoneNumberText.Text);

                if (string.IsNullOrWhiteSpace(translatedNumber))
                {
                    // No hay número a llamar
                    callButton.Text = "Llamar";
                    callButton.Enabled = false;
                }
                else
                {
                    // Hay un possible número telefónico a llamar
                    callButton.Text = $"Llamar al {translatedNumber}";
                    callButton.Enabled = true;
                }
            };

            callButton.Click += delegate
            {
                // Intentar marcar el número telefónico
                var callDialog = new AlertDialog.Builder(this);
                callDialog.SetMessage($"Llamar al número{translatedNumber}?");
                callDialog.SetNeutralButton("Llamar", delegate 
                {
                    // Crear un intento para marcar el número telefónico
                    var callIntent = new Intent(Intent.ActionCall);
                    callIntent.SetData(Android.Net.Uri.Parse($"tel:{translatedNumber}"));
                    StartActivity(callIntent);
                });
                callDialog.SetNegativeButton("Cancelar", delegate { });
                // Mostrar el cuadro de diálogo al usuário y esperar una respuesta
                callDialog.Show();
            };
            await SendEvidence();
        }

        private async Task SendEvidence()
        {
            SALLab05.ServiceClient client = new SALLab05.ServiceClient();

            string email = "mail@mail.com";
            string password = @"p4$§\/\/*Rd";
            string deviceInfo = Android.Provider.Settings.Secure.GetString(ContentResolver,
                Android.Provider.Settings.Secure.AndroidId);
            var resultInfo = await client.ValidateAsync(email, password, deviceInfo);

            textView.Text = resultInfo.Status.ToString() + "\n";
            textView.Text += resultInfo.Fullname + "\n";
            textView.Text += resultInfo.Token;
        }
    }
}

