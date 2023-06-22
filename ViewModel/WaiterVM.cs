using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ClodeMonnetV2.Model;
using ClodeMonnetV2.Utilities;
using Microsoft.EntityFrameworkCore;

namespace ClodeMonnetV2.ViewModel
{
    internal class WaiterVM : ViewModelBase
    {
        private Order? _currentOrder;
        private int? _quantity;
        private ObservableCollection<Dish>? _dishes;
        private ObservableCollection<OrderItem>? _orderItems;

        public ICommand AddToOrderCommand { get; }
        public ICommand ConfirmOrderCommand { get; }

        public Order? CurrentOrder
        {
            get => _currentOrder;
            set
            {
                _currentOrder = value;
                OnPropertyChanged(nameof(CurrentOrder));
            }
        }

        public int? Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }
        public ObservableCollection<Dish>? Dishes
        {
            get => _dishes;
            set
            {
                _dishes = value;
                OnPropertyChanged(nameof(Dishes));
            }
        }
        public ObservableCollection<OrderItem>? OrderItems
        {
            get => _orderItems;
            set
            {
                _orderItems = value;
                OnPropertyChanged(nameof(OrderItems));
            }
        }

        public WaiterVM()
        {
            OrderItems = new ObservableCollection<OrderItem>();
            using RestaurantDbContext context = new RestaurantDbContext();
            //context.Dishes.LoadAsync();
            Dishes = new ObservableCollection<Dish>(context.Dishes.ToList()!);
            AddToOrderCommand = new RelayCommand(AddToOrder);
            ConfirmOrderCommand = new RelayCommand(ConfirmOrder);
        }

        public void AddToOrder(object parameter)
        {
            if (parameter is Dish dish)
            {
                var existingItem = OrderItems!.FirstOrDefault(i => i.DishId == dish.DishId);

                if (existingItem != null) existingItem.Quantity++;
                else OrderItems!.Add(new OrderItem { DishId = dish.DishId, Quantity = 1 });
            }
        }

        public void ConfirmOrder(object parameter)
        {
            RestaurantDbContext context = new RestaurantDbContext();
            CurrentOrder = new Order()
            {
                UserId = 1,
                OrderTime = DateTime.Now,
                OrderStatus = "Принят"
            };
            context.Orders.Add(CurrentOrder);
            context.SaveChanges();

            foreach (var orderItem in OrderItems!)
            {
                orderItem.OrderId = CurrentOrder.OrderId;
            }

            context.OrderItems.AddRange(OrderItems);
            context.SaveChanges();
        }

    }
}
