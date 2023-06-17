using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClodeMonnetV2.Model
{
    public sealed class User
    {
        public User(ICollection<Order> orders, ICollection<Report> reports, ICollection<PurchaseRequest> purchaseRequests)
        {
            Orders = orders;
            Reports = reports;
            PurchaseRequests = purchaseRequests;
        }
        public User() { }

        public int UserId { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }

        public ICollection<Order>? Orders { get; set; }
        public ICollection<Report>? Reports { get; set; }
        public ICollection<PurchaseRequest>? PurchaseRequests { get; set; }
    }
}
