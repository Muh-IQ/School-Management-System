using Modules.Communication.Domain.ThirdParty.Security;
using System.Security.Cryptography;

namespace Modules.Communication.Infrastructure.ThirdParty.Security
{
    internal class OtpGenerator : IOtpGenerator
    {
        public string Generate(int length = 6)
        {
            if (length <= 0)
                throw new ArgumentOutOfRangeException(nameof(length));

            var otp = new char[length];

            for (int i = 0; i < length; i++)
            {
                otp[i] = (char)('0' + RandomNumberGenerator.GetInt32(0, 10));
            }

            return new string(otp);
        }
    }
}
