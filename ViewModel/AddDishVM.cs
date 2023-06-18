using ClodeMonnetV2.Model;
using ClodeMonnetV2.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ClodeMonnetV2.ViewModel
{
    internal class AddDishVM : ViewModelBase
    {
        private string? _dishName;
        private decimal? _price;
        private string? _category;
        private string? _imagePath;
        private int? _quantity;
        private string? _ingredientName;
        private ObservableCollection<Ingredient>? _ingredients;

        public ICommand AddIngredientCommand { get; set; }
        public ICommand SaveDishCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public string? DishName
        {
            get => _dishName;
            set
            {
                _dishName = value;
                OnPropertyChanged(nameof(DishName));
            }
        }

        public decimal? Price
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        public string? Category
        {
            get => _category;
            set
            {
                _category = value;
                OnPropertyChanged(nameof(Category));
            }
        }

        public string? ImagePath
        {
            get => _imagePath;
            set
            {
                _imagePath = value;
                OnPropertyChanged(nameof(ImagePath));
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

        public string? IngredientName
        {
            get => _ingredientName;
            set
            {
                _ingredientName = value;
                OnPropertyChanged(nameof(IngredientName));
            }
        }

        public ObservableCollection<Ingredient>? Ingredients
        {
            get => _ingredients;
            set
            {
                _ingredients = value;
                OnPropertyChanged(nameof(Ingredients));
            }
        }

        public AddDishVM()
        {
            Ingredients = new ObservableCollection<Ingredient>();
            AddIngredientCommand = new RelayCommand(AddIngredient);
            SaveDishCommand = new RelayCommand(SaveDish);
            CancelCommand = new RelayCommand(Cancel);
        }

        private void AddIngredient(object parameter)
        {
            Ingredients?.Add(new Ingredient
            {
                IngredientName = IngredientName,
                Quantity = Quantity
            });
        }

        private void SaveDish(object parameter)
        {
            var newDish = new Dish
            {
                DishName = _dishName,
                Price = _price,
                Category = _category,
                ImagePath = _imagePath
            };
            using (RestaurantDbContext context = new RestaurantDbContext())
            {
                context.Dishes.Add(newDish);
                context.SaveChanges();
            }
            ChefVM.GetNewDishDialog().Close();
        }

        private void Cancel(object parameter)
        {
            ChefVM.GetNewDishDialog().Close();
        }
    }
}
