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

            // Creamos la instancia de código compartido y 
            // le inyectamos la dependencia
            var validator = new PCLProject.AppValidator(new UWPDialog());

            // Aquí podríamos establecer los valores de las propriedades 
            // Email, Password y Device

            // Realizamos la validación
            validator.Validate();
        }
    }
}
