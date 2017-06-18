using System;

namespace UWPApp
{
    class UWPDialog : PCLProject.IDialog
    {
        public async void Show(string message)
        {
            await new Windows.UI.Popups.MessageDialog(message).ShowAsync();
        }
    }
}
