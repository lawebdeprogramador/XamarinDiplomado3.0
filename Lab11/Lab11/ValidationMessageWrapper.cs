using Android.App;
using Android.OS;

namespace Lab11
{
    public class ValidationMessageWrapper : Fragment
    {
        public string ValidationMessage { get; set; }

        public override string ToString()
        {
            return ValidationMessage;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RetainInstance = true;
        }
    }
}