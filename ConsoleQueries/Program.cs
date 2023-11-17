
using ConsoleQueries.Data;
using ConsoleQueries.Models;
using ConsoleQueries.Queries;

Repository repository = new Repository(new DataBaseContext());

var brands = repository.GetBrands().Result;

var productsFirstBrand = repository.GetProductsByBrand(brands[0]).Result;

foreach (var item in productsFirstBrand)
{
    Console.WriteLine(item.Name);
    Console.WriteLine(item.Price);
    var lazyBrand = item.Brand;
    Console.WriteLine(lazyBrand?.Name);
}
var pV = repository.GetProductVariantsByProduct(productsFirstBrand[0]).Result;
foreach (var item in pV)
{
    Console.WriteLine(item.Color?.Name);
    var lazySize = item.Size;
    Console.WriteLine(lazySize?.Name);
}

var brandsWithProd = repository.GetBrandProdNum().Result;

var sections = repository.GetSections().Result;
var categories = repository.GetCategories().Result;
var prodCategory = repository.GetProdForCategory(categories[0],sections[0]).Result;

var orders = repository.CmplOrderByProd(prodCategory[0]).Result;
foreach (var item in orders)
{
    Console.WriteLine(item.status);
    Console.WriteLine(item.User?.Username);
    var lazyAddress = item.Address;
    Console.WriteLine(lazyAddress?.Address1);
}


var reviews = repository.ReviewsByProd(prodCategory[0]).Result;
foreach (var a in reviews)
{
    Console.WriteLine(a.Titile);
    Console.WriteLine(a.Comment);
    var lazyUser = a.User;
    Console.WriteLine(lazyUser?.Username);
}


User user = repository.GetUsers().Result[0];
Console.WriteLine(user.Username);
long id = user.Id;
await repository.UpdateUserName(user,"niggative");
Console.WriteLine(repository.GetUserById(id).Result?.Username);