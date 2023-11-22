using Catalog.API.Data;
using Catalog.API.Entities;
using Catalog.API.Interfaces;
using Catalog.API.Repositories;
using Catalog.API.Repositories.Interfaces;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICatalogContext, CatalogContext>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Catalog.API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalog.API v1"));
}

// app.MapControllers();

app.MapGet("/", () => "Hello world");

RouteGroupBuilder catalogItems = app.MapGroup("/api/v1/catalog");
catalogItems.MapGet("/", GetAllProducts);
catalogItems.MapGet("/{id}", GetProduct);
catalogItems.MapPost("/", CreateProduct);
catalogItems.MapPut("/{id}", UpdateProduct);
catalogItems.MapDelete("/{id}", DeleteProduct);

static async Task<IResult> GetAllProducts(IProductRepository productRepository)
{
    return TypedResults.Ok(await productRepository.GetProducts());
}

static async Task<IResult> GetProduct(string id, IProductRepository productRepository)
{
    return await productRepository.GetProduct(id)
        is Product product
        ? TypedResults.Ok(product)
        : TypedResults.NotFound();
}

static async Task<IResult> CreateProduct(Product product, IProductRepository productRepository)
{
    await productRepository.CreateProduct(product);
    return TypedResults.Created($"/catalogs/{product.Id}", product);
}

static async Task<IResult> UpdateProduct(string id, Product product, IProductRepository productRepository)
{
    var catalog = await productRepository.GetProduct(id);

    if (catalog is null) return TypedResults.NotFound();

    await productRepository.UpdateProduct(product);

    return TypedResults.NoContent();
}

static async Task<IResult> DeleteProduct(string id, IProductRepository productRepository)
{
    if (await productRepository.GetProduct(id) is Product product)
    {
        await productRepository.DeleteProduct(id);
        return TypedResults.NoContent();
    }

    return TypedResults.NotFound();
}

app.Run();