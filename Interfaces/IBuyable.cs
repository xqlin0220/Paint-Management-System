namespace PaintManagementSystem.Interfaces;

public interface IBuyable
{
    decimal GetFinalPrice(int rate, bool isOverridable);
}