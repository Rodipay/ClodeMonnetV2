using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ClodeMonnetV2.Model;
using ClodeMonnetV2.Utilities;

namespace ClodeMonnetV2.ViewModel
{
    internal class ManagerVM : ViewModelBase
    {
        private DateTime _startDate;
        private DateTime _endDate;
        private ObservableCollection<DishStatistics> _dishStatistics;
        
        public ICommand GetDishStatisticsCommand { get; set; }

        public DateTime StartDate
        {
            get => _startDate;
            set
            {
                _startDate = value;
                OnPropertyChanged(nameof(StartDate));
            }
        }
        public DateTime EndDate
        {
            get => _endDate;
            set
            {
                _endDate = value;
                OnPropertyChanged(nameof(EndDate));
            }
        }
        public ObservableCollection<DishStatistics> DishStatistics
        {
            get => _dishStatistics;
            set
            {
                _dishStatistics = value;
                OnPropertyChanged(nameof(DishStatistics));
            }
        }

        public ManagerVM()
        {
            GetDishStatisticsCommand = new RelayCommand(GetDishStatistics);
        }

        private void GetDishStatistics(object parameter)
        {
            var context = new RestaurantDbContext();
            DishStatistics = new ObservableCollection<DishStatistics>(context.OrderItems
                .Where(oi => oi.Order.OrderTime >= StartDate && oi.Order.OrderTime <= EndDate && oi.Order.OrderStatus == "Готов")
                .GroupBy(oi => oi.Dish)
                .Select(g => new DishStatistics
                {
                    Dish = g.Key,
                    QuantitySold = g.Sum(oi => oi.Quantity)
                })
                .ToList());
        }
    }
}
