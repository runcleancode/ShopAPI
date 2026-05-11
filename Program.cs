using System.Security.Cryptography;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//In-memory list - no database yet
var products = new List<Product>
{
    new(1, "Keyboard", 499.90m, 10),
    new(2, "Mouse", 299.90m, 25),
    new(3, "Monitor", 3499.90m, 5),
};

//GET /products - returns all products
app.MapGet("/products", () => Results.Ok(products));

//GET /products/{id} - returns single product
app.MapGet("products/{id}", (int id) =>
{
    var product = products.FirstOrDefault(p => p.Id == id);
    return product is null ? Results.NotFound() : Results.Ok(product);
});

app.Run();

//Product model
record Product(int Id, string Name, decimal Price, int Stock);