namespace Modules.Communication.Domain.ThirdParty.Email
{
    public class EmailMessage
    {
        public string To { get; init; } = default!;
        public string Subject { get; init; } = default!;
        public string Body { get; init; } = default!;
        public bool IsHtml { get; init; } = true;
    }
}
