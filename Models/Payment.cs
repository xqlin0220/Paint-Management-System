using PaintManagementSystem.Enums;
 
namespace PaintManagementSystem.Models;
 
public class Payment
{
    public int PaymentId { get; set; }
    public Order Order { get; set; }
    public PaymentStatus Status { get; set; }
    public decimal PaymentAmount { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public User User { get; set; }

    public Payment(int paymentId, Order order, PaymentMethod paymentMethod, User user)
    {
        PaymentId = paymentId;
        Order = order;
        PaymentMethod = paymentMethod;
        User = user;
        PaymentAmount = order.TotalPrice;
        Status = PaymentStatus.Pending;
    }
 
}