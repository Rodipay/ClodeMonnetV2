using ClodeMonnetV2.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ClodeMonnetV2.ViewModel
{
    internal class NavigationVM : ViewModelBase
    {
        private object? _currentView;

        public NavigationVM()
        {
            WaiterCommand = new RelayCommand(Waiter);
            CookCommand = new RelayCommand(Cook);
            ChefCommand = new RelayCommand(Chief);
            ManagerCommand = new RelayCommand(Manager);

            // Startup Page
            CurrentView = new WaiterVM();
        }

        public object? CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public ICommand WaiterCommand { get; set; }
        public ICommand CookCommand { get; set; }
        public ICommand ChefCommand { get; set; }
        public ICommand ManagerCommand { get; set; }

        private void Waiter(object obj)
        {
            CurrentView = new WaiterVM();
        }

        private void Cook(object obj)
        {
            CurrentView = new CookVM();
        }

        private void Chief(object obj)
        {
            CurrentView = new ChefVM();
        }

        private void Manager(object obj)
        {
            CurrentView = new ManagerVM();
        }
    }
}
