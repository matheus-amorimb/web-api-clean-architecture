namespace CleanArch.Application.Extensions;

public static class NormalizeStringExtension
{
    public static string NormalizeString(this string result)     
    {
        return result.Trim().ToUpperInvariant();
    }
}