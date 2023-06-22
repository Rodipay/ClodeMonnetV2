using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using ClodeMonnetV2.Model;
using ClodeMonnetV2.Utilities;
using Microsoft.EntityFrameworkCore;

namespace ClodeMonnetV2.ViewModel
{
    internal class CookVM : ViewModelBase
    {
        private ObservableCollection<OrderVisabilities> _orders;
        private bool _isInfoPanelVisible = false;

        public ICommand ToggleVisibilityCommand { get; }
        public ICommand SetPreparingStatusCommand { get; }
        public ICommand SetDelayedStatusCommand { get; }
        public ICommand SetReadyStatusCommand { get; }

        public ObservableCollection<OrderVisabilities> Orders
        {
            get => _orders;
            set
            {
                _orders = value;
                OnPropertyChanged(nameof(Orders));
            }
        }

        public bool IsInfoPanelVisible
        {
            get => _isInfoPanelVisible;
            set
            {
                _isInfoPanelVisible = value;
                OnPropertyChanged(nameof(IsInfoPanelVisible));
            }
        }

        public CookVM()
        {
            UpdateOrders();
            ToggleVisibilityCommand = new RelayCommand(ToggleVisibility);
            SetPreparingStatusCommand = new RelayCommand(SetPreparingStatus);
            SetDelayedStatusCommand = new RelayCommand(SetDelayedStatus);
            SetReadyStatusCommand = new RelayCommand(SetReadyStatus);
        }

        public void UpdateOrders()
        {
            using RestaurantDbContext context = new RestaurantDbContext();
            var orders = context.Orders.Include(o => o.OrderItems).ToList();
            Orders = new ObservableCollection<OrderVisabilities>(orders.Select(o => new OrderVisabilities(o)).Where(o => o.Order.OrderStatus != "Готов"));
            foreach (var order in Orders)
            {
                order.IsInfoPanelVisible = false;
            }
        }

        private void ToggleVisibility(object parameter)
        {
            if (parameter is OrderVisabilities orderVm)
            {
                orderVm.IsInfoPanelVisible = !orderVm.IsInfoPanelVisible;
            }
        }
        private void SetPreparingStatus(object parameter)
        {
            if (parameter is OrderVisabilities orderVm)
            {
                RestaurantDbContext context = new RestaurantDbContext();
                Order? orderToUpdate = context.Orders.Find(orderVm.Order.OrderId);
                orderToUpdate.OrderStatus = "Готовится";

                context.SaveChanges();
                UpdateOrders();
            }
        }
        private void SetDelayedStatus(object parameter)
        {
            if (parameter is OrderVisabilities orderVm)
            {
                RestaurantDbContext context = new RestaurantDbContext();
                Order? orderToUpdate = context.Orders.Find(orderVm.Order.OrderId);
                orderToUpdate.OrderStatus = "Задерживается";

                context.SaveChanges();
                UpdateOrders();
            }
        }
        private void SetReadyStatus(object parameter)
        {
            if (parameter is OrderVisabilities orderVm)
            {
                RestaurantDbContext context = new RestaurantDbContext();
                Order? orderToUpdate = context.Orders.Find(orderVm.Order.OrderId);
                orderToUpdate.OrderStatus = "Готов";

                context.SaveChanges();
                UpdateOrders();
            }
        }
    }
}
