using System.Linq;
using System.Text;

namespace PhoneApp
{
    public class PhoneTranslator
    {
        private string _letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private string _numbers = "22233344455566677778889999";

        public string ToNumber(string alphanumericPhoneNumber)
        {
            var numericPhoneNumber = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(alphanumericPhoneNumber))
            {
                alphanumericPhoneNumber = alphanumericPhoneNumber.ToUpper();

                foreach (var c in alphanumericPhoneNumber)
                {
                    if ("0123456789".Contains(c))
                    {
                        numericPhoneNumber.Append(c);
                    }
                    else
                    {
                        var index = _letters.IndexOf(c);

                        if (index >= 0)
                        {
                            numericPhoneNumber.Append(_numbers[index]);
                        }
                    }
                }
            }

            return numericPhoneNumber.ToString();
        }
    }
}