using Modules.School.Application.Common.Results;

namespace Modules.School.WebAPI.Contracts;

public sealed class ApiResponse<T>
{
    public bool Success { get; init; }
    public T? Data { get; init; }
    public IReadOnlyList<Error> Errors { get; init; } = [];
    public int StatusCode { get; init; }
}
