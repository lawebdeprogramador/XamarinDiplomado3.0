using System;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            Task.Run(() => Show());
        }

        private async void Show()
        {
            var helper = new SharedProject.MySharedCode();
            var dialog = new Windows.UI.Popups.MessageDialog(helper.GetFilePath("demo.dat"));
            await dialog.ShowAsync();
        }
    }
}
