namespace Builder
{
    public class Product(Guid id, string name, string description, string brand)
    {
        public Guid Id { get; protected set; } = id;
        public string Name { get; protected set; } = name;
        public string Description { get; protected set; } = description;
        public string Brand { get; protected set; } = brand;
        public EColor Color { get; protected set; }
        public decimal Price { get; protected set; }
        public decimal Tax { get; protected set; }
        public decimal DeliveryFee { get; protected set; }
        public bool IsNew { get; protected set; }
        public bool IsStock { get; protected set; }

        public void SetColor(EColor color) => Color = color;

        public void SetPrices(decimal price, decimal tax, decimal deliveryFee)
        {
            Price = price;
            Tax = tax;
            DeliveryFee = deliveryFee;
        }

        public void SetStatus(bool isNew, bool isStock)
        {
            IsNew = isNew;
            IsStock = isStock;
        }

        public void OrderDetails()
        {
            Console.WriteLine($@"Product: {Id} Name: {Name}, Brand: {Brand}, Status: {ProductStatus()}
                              Available: {Available()}
                              Description: {Description}
                              Brand: {Brand}
                              Select Color: {Color}
                              Total: {Price + Tax + DeliveryFee}");
        }

        public string Available() => IsStock ? $"Yes" : $"No";

        public decimal Total() => Price + Tax + DeliveryFee;

        private string ProductStatus() => IsNew ? $"New" : $"Old";
    }
}
