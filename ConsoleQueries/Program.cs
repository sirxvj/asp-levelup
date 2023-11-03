using ConsoleQueries.Models;
using ConsoleQueries.Queries;

Repository repository = new Repository(new DataBaseContext());

var brands = repository.GetBrands();

var productsFirstBrand = repository.GetProsuctsByBrand(brands[0]);

foreach (var item in productsFirstBrand)
{
    Console.WriteLine(item.Name);
    Console.WriteLine(item.Price);
    var lazyBrand = item.Brand;
    Console.WriteLine(lazyBrand.Name);
}
var pV = repository.GetPrVarByProduct(productsFirstBrand[0]);
foreach (var item in pV)
{
    Console.WriteLine(item.Color.Name);
    var lazySize = item.Size;
    Console.WriteLine(lazySize.Name);
}

var brandsWithProd = repository.GetBrandProdNum();

var sections = repository.GetSections();
var categories = repository.GetCategories();
var prodCategory = repository.GetProdForCategory(categories[0],sections[0]);

var orders = repository.CmplOrderByProd(prodCategory[0]);
foreach (var item in orders)
{
    Console.WriteLine(item.status);
    Console.WriteLine(item.User.Username);
    var lazyAddress = item.Address;
    Console.WriteLine(lazyAddress.Address1);
}


var reviews = repository.ReviewsByProd(prodCategory[0]);
foreach (var a in reviews)
{
    Console.WriteLine(a.Titile);
    Console.WriteLine(a.Comment);
    var lazyUser = a.User;
    Console.WriteLine(lazyUser.Username);
}


User user = repository.GetUsers()[0];
Console.WriteLine(user.Username);
long id = user.Id;
repository.updateUserName(user,"niggative");
Console.WriteLine(repository.GetUserById(id).Username);