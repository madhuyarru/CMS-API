namespace CMS.Api;

public class ProductStore
{
    private readonly object syncRoot = new();
    private readonly Dictionary<int, Product> products = new()
    {
        [1] = new Product(1, "Notebook", 5.99m),
        [2] = new Product(2, "Pen", 1.49m)
    };
    private int nextId = 3;

    public Product[] GetAll()
    {
        lock (syncRoot)
        {
            return products.Values.OrderBy(product => product.Id).ToArray();
        }
    }

    public Product Create(ProductRequest request)
    {
        lock (syncRoot)
        {
            var product = new Product(nextId++, request.Name.Trim(), request.Price!.Value);
            products.Add(product.Id, product);
            return product;
        }
    }

    public Product? Update(int id, ProductRequest request)
    {
        lock (syncRoot)
        {
            if (!products.ContainsKey(id))
            {
                return null;
            }

            var product = new Product(id, request.Name.Trim(), request.Price!.Value);
            products[id] = product;
            return product;
        }
    }

    public bool Delete(int id)
    {
        lock (syncRoot)
        {
            return products.Remove(id);
        }
    }
}