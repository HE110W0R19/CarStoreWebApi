namespace CarStoreWEB.Contracts
{
    public record CarsResponce(
        Guid Id,
        string Name,
        string Model,
        string Discription,
        decimal Price
        );
}
