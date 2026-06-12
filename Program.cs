using PaintManagementSystem.Enums;
using PaintManagementSystem.Models;

namespace PaintManagementSystem;

public class Program
{
    public static void Main(string[] args)
    {
        int rate = 10;
        bool isOverridable = true;

        PaintProduct paint1 = new PaintProduct(
            "Dulux Primer",
            120.00m,
            PaintType.BaseCoat,
            new PaintSpecification("White", 10),
            0.10m
        );
        PaintProduct paint2 = new PaintProduct(
            "Glossy Wall Paint",
            80.00m,
            PaintType.Glossy,
            new PaintSpecification("Blue", 5),
            0.10m
        );
        PaintProduct paint3 = new PaintProduct(
            "Matte Interior Paint",
            150.00m,
            PaintType.Matte,
            new PaintSpecification("Grey", 15),
            0.10m
        ); 
        PaintProduct[] products = { paint1, paint2, paint3 };

        Console.WriteLine("Available Paint Products:");
        Console.WriteLine();
        foreach (PaintProduct product in products)
        {
            product.DisplayInfo(rate, isOverridable);
        }

        Order order = new Order(paint2, 3, rate, isOverridable);
        Console.WriteLine();
        order.DisplayOrder();
    }
}