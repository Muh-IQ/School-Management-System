namespace Modules.School.Application.Common.Results;


public enum ErrorType
{
    /// <summary>
    /// No error occurred (successful operation).
    /// </summary>
    None = 0,

    /// <summary>
    /// The operation failed due to a bad request (invalid input).
    /// </summary>
    BadRequest = 400,

    /// <summary>
    /// The operation failed due to an unauthorized access attempt.
    /// </summary>
    Unauthorized = 401,

    /// <summary>
    /// The operation was forbidden due to insufficient permissions.
    /// </summary>
    Forbidden = 403,

    /// <summary>
    /// The requested resource was not found.
    /// </summary>
    NotFound = 404,

    /// <summary>
    /// The operation failed due to a conflict (e.g., duplicate entry).
    /// </summary>
    Conflict = 409,

    /// <summary>
    /// The operation failed due to a timeout.
    /// </summary>
    Timeout = 408,

    /// <summary>
    /// The operation failed validation.
    /// </summary>
    Validation = 422,

    /// <summary>
    /// The operation failed due to an internal server error.
    /// </summary>
    InternalServerError = 500,

    /// <summary>
    /// The operation failed due to a service being unavailable.
    /// </summary>
    ServiceUnavailable = 503
}
