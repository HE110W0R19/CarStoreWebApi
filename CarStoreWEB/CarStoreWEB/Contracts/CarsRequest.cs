namespace CarStoreWEB.Contracts
{
    public record CarsRequest
    (
        string Name,
        string Model,
        string Discription,
        decimal Price);
}
