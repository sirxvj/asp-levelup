using ConsoleQueries.Models;
using ConsoleQueries.Queries;

Repository repository = new Repository(new DataBaseContext());


var products = repository.GetProducts();
var ord = repository.CmplOrderByProd(products[0]);
foreach (var item in ord)
{
    Console.WriteLine(item.status);
    Console.WriteLine(item.Price);
    Console.WriteLine(item.User.Username+"\r");
}