namespace PaintManagementSystem.Models;
 
public class User
{
    public int UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public List<Order> OrderHistory { get; set; }= new List<Order>();
    public List<Payment> PaymentHistory { get; set; } = new List<Payment>();
 
    public User(int userId, string name, string email)
    {
        UserId = userId;
        Name = name;
        Email = email;
    }
    public Order? GetMostExpensiveOrder()
    {
        return OrderHistory.MaxBy(order => order.TotalPrice);
    }
    public Payment? GetCheapestPayment()
    {
        return PaymentHistory.MinBy(payment => payment.PaymentAmount);
    }
    public Order? GetLatestOrder()
    {
        return OrderHistory.MaxBy(order => order.CreatedAt);
    }
    public List<Payment> GetPaymentsAboveTen()
    {
        return PaymentHistory.Where(payment => payment.PaymentAmount > 10).ToList();
    }
}