using Android.App;
using Android.Content;

namespace AndroidApp
{
    class AndroidDialog : PCLProject.IDialog
    {
        private Context _appContext;

        public AndroidDialog(Context context)
        {
            _appContext = context;
        }

        public void Show(string message)
        {
            AlertDialog alert = new AlertDialog.Builder(_appContext).Create();
            alert.SetTitle("Resultado de la verificación");
            alert.SetIcon(Resource.Drawable.Icon);
            alert.SetMessage(message);
            alert.SetButton("OK", (sender, e) => { });
            alert.Show();
        }
    }
}