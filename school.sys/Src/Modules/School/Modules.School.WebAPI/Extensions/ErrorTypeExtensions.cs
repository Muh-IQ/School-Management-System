using Modules.School.Application.Common.Results;

namespace Modules.School.WebAPI.Extensions;

public static class ErrorTypeExtensions
{
    public static int ToHttpStatus(this ErrorType type)
        => type == ErrorType.None ? 200 : (int)type;
}
