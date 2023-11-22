using Catalog.API.Entities;
using Catalog.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CatalogController : ControllerBase
{
  private readonly IProductRepository _productRepository;
  private readonly ILogger<CatalogController> _logger;

  public CatalogController(IProductRepository productRepository, ILogger<CatalogController> logger)
  {
    _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
  }

  [HttpGet]
  [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
  public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
  {
    var products = await _productRepository.GetProducts();
    return Ok(products);
  }

  [HttpGet("{id:length(24)}", Name = "GetProduct")]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
  public async Task<ActionResult<Product>> GetProduct(string id)
  {
    var product = await _productRepository.GetProduct(id);
    if (product is null)
    {
      _logger.LogError($"Product with id: {id}, not found");
      return NotFound();
    }

    return Ok(product);
  }

  [HttpPost]
  [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
  public async Task<ActionResult<Product>> CreateProduct([FromBody] Product product)
  {
    await _productRepository.CreateProduct(product);
    return CreatedAtRoute("GetProduct", new { id = product.Id }, product);
  }

  [HttpPut("{id}")]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  public async Task<ActionResult<Product>> UpdateProduct(string id, [FromBody] Product product)
  {
    if (id != product.Id)
    {
      return BadRequest();
    }

    if (await _productRepository.GetProduct(product.Id) is null)
    {
      return NotFound();
    }

    await _productRepository.UpdateProduct(product);

    return NoContent();
  }

  [HttpDelete("{id:length(24)}", Name = "DeleteProduct")]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  public async Task<ActionResult<Product>> DeleteProduct(string id)
  {
    if (await _productRepository.GetProduct(id) is null)
    {
      return NotFound();
    }

    await _productRepository.DeleteProduct(id);

    return NoContent();
  }
}
