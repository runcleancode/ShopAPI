using System.Security.Cryptography;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//In-memory list - no database yet
var products = new List<Product>
{
    new(1, "Keyboard", 599.90m, 50),
    new(2, "Mouse", 299.90m, 25),
    new(3, "Monitor", 3499.90m, 5),
};

//GET /products/{id} - returns single product
app.MapGet("products/{id}", (int id) =>
{
    if (id <= 0) return Results.BadRequest("Id must be greater than 0");
    var product = products.FirstOrDefault(p => p.Id == id);
    return product is null ? Results.NotFound() : Results.Ok(product);
});

//GET /products - supports optional price filtering
app.MapGet("/products", (decimal? minPrice, decimal? maxPrice) =>
{
    var filtered = products.AsEnumerable();
    if (minPrice.HasValue)
        filtered = filtered.Where(p => p.Price >= minPrice.Value);

    if (maxPrice.HasValue)
        filtered = filtered.Where(p => p.Price <= maxPrice.Value);

    return Results.Ok(filtered.ToList());
});

app.Run();

//Product model
record Product(int Id, string Name, decimal Price, int Stock);