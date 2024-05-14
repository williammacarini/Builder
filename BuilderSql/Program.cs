using Builder;
using BuilderSql;

var query = new QueryBuilder().Select("*")
                              .From("product")
                              .Where("isNew = true")
                              .And("isStock = true")
                              .OrderBy("name")
                              .Build();

Console.WriteLine(query);

var queryCommand = new QueryExpressionBuilder<Product>().Where(x => x.IsNew == true)
                                                     .And(x => x.IsStock == true)
                                                     .And(x => x.Price > 50m)
                                                     .OrderBy(o => o.Name)
                                                     .Build();

Console.WriteLine(queryCommand);

var queryCommandWithSelect = new QueryExpressionBuilder<Product>().Select(s => s.Name, s => s.Description)
                                                               .Where(x => x.IsNew == true)
                                                               .And(x => x.IsStock == true)
                                                               .And(x => x.Price > 50)
                                                               .OrderBy(o => o.Name)
                                                               .Build();

Console.WriteLine(queryCommandWithSelect);

