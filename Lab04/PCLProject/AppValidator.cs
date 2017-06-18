namespace PCLProject
{
    public class AppValidator
    {
        IDialog _dialog;

        public string EMail { get; set; }
        public string Password { get; set; }
        public string Device { get; set; }

        public AppValidator(IDialog dialog)
        {
            _dialog = dialog;
        }

        public async void Validate()
        {
            var serviceClient = new SALLab04.ServiceClient();
            var svcResult = await serviceClient.ValidateAsync(EMail, Password, Device);
            string result = $"{svcResult.Status}\n{svcResult.Fullname}\n{svcResult.Token}";

            // Invocar el código específico de la plataforma
            _dialog.Show(result);
        }
    }
}
