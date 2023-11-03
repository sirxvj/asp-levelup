using ConsoleQueries.Models;
using ConsoleQueries.Queries;

Repository repository = new Repository(new DataBaseContext());


// var gtdSec = repository.GetSections();
//
// Category category = new Category();
// category.Name = "qwerty";
// category.Sections.Add(gtdSec[0]);
// repository.InsertCategory(category);
//
//
//
//
// var parent = repository.GetCategories().Where(p=>p.Name == category.Name).First();
//
// Category category2 = new Category();
// category2.Name = "uiop";
// category2.Sections.Add(gtdSec[0]);
// category2.ParentCategoryId = parent.Id;
// repository.InsertCategory(category2);
//
//


var sections = repository.GetCategories();
foreach (var a in sections)
{
    Console.WriteLine(a.Name);
    Console.WriteLine(a.Sections);
}