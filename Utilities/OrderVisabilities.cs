using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClodeMonnetV2.Model;
using ClodeMonnetV2.Utilities;

namespace ClodeMonnetV2.ViewModel
{
    class OrderVisabilities : ViewModelBase
    {
        private Order _order;
        private bool _isInfoPanelVisible;

        public Order Order
        {
            get => _order;
            set
            {
                _order = value;
                OnPropertyChanged(nameof(Order));
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

        public OrderVisabilities(Order order)
        {
            Order = order;
        }
    }
}
