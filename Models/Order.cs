namespace PaintManagementSystem.Models;

public class Order
{
    public DateTime CreatedAt { get; }
    public PaintProduct Product { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
    public decimal Rate { get; set; }
    public bool IsOverridable { get; set; }

    public Order( PaintProduct paintProduct, int quantity, decimal rate, bool isOverridable)
    {
        Product = paintProduct;
        Quantity = quantity;
        CreatedAt = DateTime.Now;
        Rate = rate;
        IsOverridable = isOverridable;
        TotalPrice = GetTotalPrice();
    }

    public decimal GetTotalPrice()
    {
        return Product.GetFinalPrice((int)Rate, IsOverridable) * Quantity;
    }

    public void DisplayOrder()
     {
        Console.WriteLine("===== Order Details =====");
        Console.WriteLine($"Created At: {CreatedAt}");
        Console.WriteLine($"Product Name: {Product.Name}");
        Console.WriteLine($"Paint Type: {Product.Type}");
        Console.WriteLine($"Color: {Product.Specification.Color}");
        Console.WriteLine($"Size: {Product.Specification.SizeInLiters}L");
        Console.WriteLine($"Quantity: {Quantity}");
        Console.WriteLine($"Unit Final Price: ${Product.GetFinalPrice((int)Rate, IsOverridable)}");
        Console.WriteLine($"Total Price: ${TotalPrice}");
    }
}