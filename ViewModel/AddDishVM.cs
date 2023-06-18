using ClodeMonnetV2.Model;
using ClodeMonnetV2.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ClodeMonnetV2.ViewModel
{
    internal class AddDishVM : ViewModelBase
    {
        private string _dishName;
        private decimal _price;
        private string _category;
        private ObservableCollection<Ingredient> _ingredients;
        private ICommand _addIngredientCommand;
        private ICommand _saveDishCommand;

        public string DishName
        {
            get => _dishName;
            set
            {
                _dishName = value;
                OnPropertyChanged(nameof(DishName));
            }
        }

        public decimal Price
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        public string Category
        {
            get => _category;
            set
            {
                _category = value;
                OnPropertyChanged(nameof(Category));
            }
        }

        public ObservableCollection<Ingredient> Ingredients
        {
            get => _ingredients;
            set
            {
                _ingredients = value;
                OnPropertyChanged(nameof(Ingredients));
            }
        }

        public ICommand AddIngredientCommand
        {
            get => _addIngredientCommand;
            set
            {
                _addIngredientCommand = value;
                OnPropertyChanged(nameof(AddIngredientCommand));
            }
        }

        public ICommand SaveDishCommand
        {
            get => _saveDishCommand;
            set
            {
                _saveDishCommand = value;
                OnPropertyChanged(nameof(SaveDishCommand));
            }
        }

        public AddDishVM()
        {
            Ingredients = new ObservableCollection<Ingredient>();
            AddIngredientCommand = new RelayCommand(AddIngredient);
            SaveDishCommand = new RelayCommand(SaveDish);
        }

        private void AddIngredient(object parameter)
        {
            // Логика добавления ингредиента
        }

        private void SaveDish(object parameter)
        {
            // Логика сохранения блюда
        }
    }
}
