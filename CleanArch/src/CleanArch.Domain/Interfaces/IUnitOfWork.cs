namespace CleanArch.Domain.Interfaces;

public interface IUnitOfWork
{
    Task Commit();
}