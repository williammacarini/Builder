using Builder;

var product = new ProductBuilder().WithId(Guid.NewGuid())
                                  .WithName("Tablet")
                                  .WithDetails("New generation", "TS")
                                  .WithColor(EColor.Blue)
                                  .WithStatus(isNew: true, isStock: true)
                                  .WithPrices(price: 100, tax: 10, deliveryFee: 10)
                                  .Build();

product.OrderDetails();
