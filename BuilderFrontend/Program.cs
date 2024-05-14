using Builder;
using BuilderFrontend;

var product = new ProductBuilder().WithId(Guid.NewGuid())
                                  .WithName("Smartphone")
                                  .WithDetails("New generation", "TS")
                                  .WithColor(EColor.Red)
                                  .WithStatus(isNew: true, isStock: true)
                                  .WithPrices(price: 100, tax: 10, deliveryFee: 10)
                                  .Build();

var html = new BuilderHtml().Build(product);

Console.WriteLine(html);
