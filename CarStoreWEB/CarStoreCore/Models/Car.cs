namespace CarStoreCore.Models
{
    public class Car
    {
        //Values for validation
        public const UInt16 MAX_NAME_LENGTH = 10;
        public const UInt16 MAX_DISCRIPTION_LENGTH = 400;
        public const UInt16 MAX_MODEL_LENGTH = 30;

        //Car structure
        public Guid Id { get; }
        public string Name { get; }
        public string Model { get; }
        public string? Description { get; }
        public decimal Price { get; }

        //Init values
        private Car(Guid id, string name, string model, string discription, decimal price)
        {
            Id = id;
            Name = name;
            Model = model;
            Description = discription;
            Price = price;
        }

        public static (Car Car, string Error) CreateCar(Guid id, string name, string model, string discription, decimal price)
        {
            var err = string.Empty;

            //Check validation
            if (string.IsNullOrEmpty(name) || name.Length >= MAX_NAME_LENGTH)
            {
                err = $"Name cant be empty or length must be < {MAX_NAME_LENGTH}";
            }

            if (!string.IsNullOrEmpty(discription) && discription.Length >= MAX_DISCRIPTION_LENGTH)
            {
                err = $"Discription length must be < {MAX_DISCRIPTION_LENGTH}";
            }

            if (string.IsNullOrEmpty(model) || model.Length >= MAX_MODEL_LENGTH)
            {
                err = $"Model cant be empty or length must be < {MAX_MODEL_LENGTH}";
            }

            if (price <= 0)
            {
                err = "Price cant be <= 0";
            }

            var car = new Car(id, name, model, discription, price);

            return (car, err);
        }
    }
}
