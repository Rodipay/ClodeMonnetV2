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
    internal class CookVM : ViewModelBase
    {
        private ObservableCollection<Order> _orders;
        private bool _isInfoPanelVisible = false;

        public ICommand ToggleVisibilityCommand { get; }

        public ObservableCollection<Order> Orders
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
        }

        public void UpdateOrders()
        {
            using RestaurantDbContext context = new RestaurantDbContext();
            Orders = new ObservableCollection<Order>(context.Orders.Include(o => o.OrderItems).ToList());
        }
        private void ToggleVisibility(object parameter) => IsInfoPanelVisible = !IsInfoPanelVisible;
    }
}
