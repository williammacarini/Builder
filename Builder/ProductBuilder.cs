namespace Builder
{
    public class ProductBuilder : Builder<Product>
    {
        private Guid _id;
        private string _name;
        private string _description;
        private string _brand;
        private EColor _color;
        private decimal _price;
        private decimal _tax;
        private decimal _deliveryFee;
        private bool _isNew;
        private bool _isStock;

        public ProductBuilder()
        {
            _id = Guid.NewGuid();
            _name = string.Empty;
            _description = string.Empty;
            _brand = string.Empty;
            _color = EColor.Blue;
            _price = decimal.Zero;
            _tax = decimal.Zero;
            _deliveryFee = decimal.Zero;
            _isNew = false;
            _isStock = false;
        }

        public ProductBuilder WithId(Guid id)
        {
            _id = id;
            return this;
        }

        public ProductBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public ProductBuilder WithDetails(string description, string brand)
        {
            _description = description;
            _brand = brand;
            return this;
        }

        public ProductBuilder WithColor(EColor color)
        {
            _color = color;
            return this;
        }

        public ProductBuilder WithPrices(decimal price, decimal tax, decimal deliveryFee)
        {
            _price = price;
            _tax = tax;
            _deliveryFee = deliveryFee;
            return this;
        }

        public ProductBuilder WithStatus(bool isNew, bool isStock)
        {
            _isNew = isNew;
            _isStock = isStock;
            return this;
        }

        public override Product Build()
        {
            var product = new Product(_id, _name, _description, _brand);
            product.SetColor(_color);
            product.SetPrices(_price, _tax, _deliveryFee);
            product.SetStatus(_isNew, _isStock);
            return product;
        }
    }
}
