using System.Net.Http.Headers;
using PaintManagementSystem.Enums;

namespace PaintManagementSystem.Models;

public class Order
{
    public DateTime CreatedAt { get; }
    public PaintProduct Product { get; set; }
    public List<PaintProduct> Products { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
    public decimal Rate { get; set; }
    public bool IsOverridable { get; set; }

    public Order( PaintProduct paintProduct, int quantity, decimal rate, bool isOverridable)
    {
        Product = paintProduct;
        Products = new List<PaintProduct>();
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

    // Identify the most expensive paint
    public PaintProduct? GetMostExpensivePaintProduct()
    {
        if(Products.Count == 0)
            return null;
        
        PaintProduct mostExpensiveProduct = Products[0];
        foreach(PaintProduct product in Products)
        {
            if (product.Price > mostExpensiveProduct.Price)
                mostExpensiveProduct = product;
        }
        return mostExpensiveProduct;
    }
    // Completely remove a certain paint product
    public bool RemoveProduct(int productId)
    {
        if(productId < 0 || productId >= Products.Count)
        {
            Console.WriteLine($"Invalid product ID: {productId}");
            return false;
        }
        PaintProduct removedProduct = Products[productId];
        Products.RemoveAt(productId);
        Console.WriteLine($"Deleted product : {removedProduct.Name}");
            return true;
    }
    // Find all paints priced above x and less than y
    public List<PaintProduct> GetProductsByPriceRange(decimal x, decimal y)
    {
        List<PaintProduct> result = new List<PaintProduct>();
        foreach(PaintProduct product in Products)
        {
            if (product.Price > x && product.Price < y )
                result.Add(product);
        }
        return result;
    }
    public Dictionary<PaintType, decimal> getTotalPriceByType()
    {
        return Products
            .GroupBy(product=> product.Type)
            .ToDictionary(group => group.Key,group => group.Sum(product => product.Price));
    }
}