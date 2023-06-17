using System;

namespace ClodeMonnetV2.Model;

public sealed class PurchaseRequest
{
    public PurchaseRequest(User user)
    {
        User = user;
    }
    public PurchaseRequest() { }

    public int RequestId { get; set; }
    public int UserId { get; set; }
    public DateTime RequestTime { get; set; }

    public User? User { get; set; }
}