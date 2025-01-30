public class Order
{
    private Customer customer;
    private List<Product> products;
    private const double USA_SHIPPING_COST = 5;
    private const double INTERNATIONAL_SHIPPING_COST = 35;

    public Order(Customer customer)
    {
        this.customer = customer;
        products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public double CalculateTotalPrice()
    {
        double totalCost = 0;
        foreach (var product in products)
        {
            totalCost += product.CalculateTotalCost();
        }

        // Add shipping cost based on customer's location
        double shippingCost = customer.LivesInUSA() ? USA_SHIPPING_COST : INTERNATIONAL_SHIPPING_COST;
        totalCost += shippingCost;

        return totalCost;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (var product in products)
        {
            label += $"{product.GetName()} - {product.GetProductId()}\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        string label = "Shipping Label:\n";
        label += $"{customer.GetName()}\n";
        label += customer.GetAddress().GetFullAddress();
        return label;
    }
}