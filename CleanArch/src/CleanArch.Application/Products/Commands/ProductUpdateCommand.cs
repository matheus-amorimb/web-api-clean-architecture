namespace CleanArch.Application.Products.Commands;

public class ProductUpdateCommand : ProductCommand
{
    public Guid Id { get; set; }
}