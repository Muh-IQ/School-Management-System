namespace Modules.School.Domain.Common.StaticError;

public static class LanguageErrors
{
    public static string NotFoundMessage(Guid? id = null) =>
        id == null ? "Language was not found." : $"Language with ID '{id}' was not found.";

    public static string NoneFoundMessage() => "No languages found.";

    public static string NameRequired() => "Language name is required.";

    public static string CodeRequired() => "Language code is required.";

    public static string NameAlreadyExists() => "A language with this name already exists.";

    public static string CodeAlreadyExists() => "A language with this code already exists.";

    public static string CannotUpdateDeleted() => "Cannot update a deleted language.";

    public static string CannotDeleteInUse() => "Cannot delete language because it is in use by one or more schools.";

    public static string AlreadyDeleted() => "Language is already deleted.";

    public static string InvalidPaging() => "Page number must be at least 1 and page size between 1 and 100.";
}
