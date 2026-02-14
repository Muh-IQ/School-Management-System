using Modules.Communication.Domain.ThirdParty.Security;
using System.Security.Cryptography;

namespace Modules.Communication.Infrastructure.ThirdParty.Security
{
    internal class OtpGenerator : IOtpGenerator
    {
        public string Generate(int length = 6)
        {
            using var rng = RandomNumberGenerator.Create();
            var otp = new char[length];
            var random = new byte[1];

            for (int i = 0; i < length; i++)
            {
                rng.GetBytes(random);
                otp[i] = (char)('0' + (random[0] % 10));
            }

            return new string(otp);
        }
    }
}
