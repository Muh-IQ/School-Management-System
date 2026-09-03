using System.Collections.Specialized;
using System.Security.Cryptography;

namespace Modules.IdP.Application.Helpers
{
    public class OTPHelper
    {
        public string Generate()
        {
            while (true)
            {
                string otp = RandomNumberGenerator
                    .GetInt32(0, 1_000_000)
                    .ToString("D6");

                if (!IsWeakOtp(otp))
                    return otp;
            }
        }

        private  bool IsWeakOtp(string otp)
        {
            // All digits are the same
            if (otp.Distinct().Count() == 1)
                return true;

            // Common sequential patterns
            if (otp == "012345" ||
                otp == "123456" ||
                otp == "234567" ||
                otp == "345678" ||
                otp == "456789" ||
                otp == "987654" ||
                otp == "876543" ||
                otp == "765432" ||
                otp == "654321" ||
                otp == "543210")
            {
                return true;
            }

            return false;
        }
    }
}
