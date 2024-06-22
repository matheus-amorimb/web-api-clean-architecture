namespace CleanArch.Domain.Validations;

public class DomainException : Exception
{
    public DomainException() { }
    public DomainException(string error) : base(error) {}
}