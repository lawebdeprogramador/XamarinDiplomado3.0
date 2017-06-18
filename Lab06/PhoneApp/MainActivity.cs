using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneApp
{
    [Activity(Label = "Phone App", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        static readonly List<string> _phoneNumbers = new List<string>();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var phoneNumberText = FindViewById<EditText>(Resource.Id.PhoneNumberText);
            var translateButton = FindViewById<Button>(Resource.Id.TranslateButton);
            var callButton = FindViewById<Button>(Resource.Id.CallButton);
            var callHistoryButton = FindViewById<Button>(Resource.Id.CallHistoryButton);
            var validateActivityButton = FindViewById<Button>(Resource.Id.ValidateActivityButton);

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
                    // Agregar el número marcado a la lista de números marcados
                    _phoneNumbers.Add(translatedNumber);
                    // Habilitar el botón CallHistoryButton
                    callHistoryButton.Enabled = true;
                    // Crear un intento para marcar el número telefónico
                    var callIntent = new Intent(Intent.ActionCall);
                    callIntent.SetData(Android.Net.Uri.Parse($"tel:{translatedNumber}"));
                    StartActivity(callIntent);
                });
                callDialog.SetNegativeButton("Cancelar", delegate { });
                // Mostrar el cuadro de diálogo al usuário y esperar una respuesta
                callDialog.Show();
            };

            callHistoryButton.Click += delegate
            {
                var intent = new Intent(this, typeof(CallHistoryActivity));
                intent.PutStringArrayListExtra("phone_numbers", _phoneNumbers);
                StartActivity(intent);
            };

            validateActivityButton.Click += delegate
            {
                var intent = new Intent(this, typeof(ValidationActivity));
                StartActivity(intent);
            };
        }
    }
}

