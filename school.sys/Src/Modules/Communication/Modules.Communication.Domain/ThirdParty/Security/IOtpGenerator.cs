namespace Modules.Communication.Domain.ThirdParty.Security
{
    public interface  IOtpGenerator
    {
         string Generate(int length = 6);

    }
}
