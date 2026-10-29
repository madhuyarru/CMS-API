using Microsoft.AspNetCore.Mvc;

namespace CMS.Api;

[ApiController]
[Route("api/products")]
public class ProductsController(ProductStore store) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType<Product[]>(StatusCodes.Status200OK)]
    public ActionResult<Product[]> GetAll() => Ok(store.GetAll());

    [HttpPost]
    [ProducesResponseType<Product>(StatusCodes.Status201Created)]
    [ProducesResponseType<ValidationProblemDetails>(StatusCodes.Status400BadRequest)]
    public ActionResult<Product> Create(ProductRequest request)
    {
        var product = store.Create(request);
        return CreatedAtAction(nameof(GetAll), null, product);
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType<Product>(StatusCodes.Status200OK)]
    [ProducesResponseType<ValidationProblemDetails>(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Product> Update(int id, ProductRequest request)
    {
        var product = store.Update(id, request);
        return product is null ? NotFound() : Ok(product);
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(int id) => store.Delete(id) ? NoContent() : NotFound();
}