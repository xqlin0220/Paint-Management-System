using PaintManagementSystem.Enums;
using PaintManagementSystem.Interfaces;

namespace PaintManagementSystem.Models;

public class PaintProduct: IBuyable
{
    public readonly decimal TaxRate;
    public const decimal DefaultDiscount = 0.05m;

    public string Name{ get; set; } = string.Empty;
    public decimal Price { get; set; }
    public PaintType Type{ get; set; }
    public PaintSpecification Specification { get; set; }

    public PaintProduct(string name, decimal price, PaintType paintType, PaintSpecification paintSpecification, decimal taxRate)
    {
        Name = name;
        Price = price;
        Type = paintType;
        Specification = paintSpecification;
        TaxRate = taxRate;
    }

    public decimal GetMaxDiscount(int rate, bool isOverridable)
    {
        decimal inputDiscount = rate / 100m;
        decimal maxDiscount = Math.Max(DefaultDiscount, inputDiscount);
        return isOverridable ? maxDiscount : DefaultDiscount;
    }

    public decimal GetFinalPrice(int rate, bool isOverridable)
    {
        decimal discount = GetMaxDiscount(rate, isOverridable);
        decimal discountedPrice = Price * (1 - discount);
        decimal finalPrice = discountedPrice * (1 + TaxRate);

        return finalPrice;
    }

    public void DisplayInfo(int rate, bool isOverridable)
    {
        Console.WriteLine("Paint Product");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Type: {Type}");
        Specification.DisplaySpecification();
        Console.WriteLine($"Original Price: ${Price}");
        Console.WriteLine($"Tax Rate: {TaxRate:P0}");
        Console.WriteLine($"Default Discount: {DefaultDiscount}");
        Console.WriteLine($"Final Price: ${GetFinalPrice(rate, isOverridable)}");
        Console.WriteLine();

    }

}