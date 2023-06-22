using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClodeMonnetV2.Model;
using ClodeMonnetV2.Utilities;
using Microsoft.EntityFrameworkCore;

namespace ClodeMonnetV2.ViewModel
{
    internal class CookVM : ViewModelBase
    {
        private ObservableCollection<Order> _orders;

        public ObservableCollection<Order> Orders
        {
            get => _orders;
            set
            {
                _orders = value;
                OnPropertyChanged(nameof(Orders));
            }
        }

        public CookVM()
        {
            UpdateOrders();

        }

        public void UpdateOrders()
        {
            using RestaurantDbContext context = new RestaurantDbContext();
            Orders = new ObservableCollection<Order>(context.Orders.Include(o => o.OrderItems).ToList());
        }
    }
}
