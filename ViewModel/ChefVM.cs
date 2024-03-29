﻿using ClodeMonnetV2.Model;
using ClodeMonnetV2.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using ClodeMonnetV2.View;
using Microsoft.EntityFrameworkCore;

namespace ClodeMonnetV2.ViewModel
{
    internal class ChefVM : ViewModelBase
    {
        private readonly RestaurantDbContext _context;
        private ObservableCollection<Dish?> _dishes;
        private static AddDishView _addDishDialog = new AddDishView()
        {
            Width = 600,
            Height = 400,
            WindowStartupLocation = WindowStartupLocation.CenterScreen
        };
        private Dish _selectedDish = null!;

        public ChefVM()
        {
            _context = new RestaurantDbContext();
            _dishes = new ObservableCollection<Dish?>();
            LoadDishes();
            AddDishCommand = new RelayCommand(AddDish);
            UpdateDishCommand = new RelayCommand(UpdateDish, CanEditOrDeleteDish);
            DeleteDishCommand = new RelayCommand(DeleteDish, CanEditOrDeleteDish);
        }

        public Dish SelectedDish
        {
            get => _selectedDish;
            set
            {
                _selectedDish = value;
                OnPropertyChanged(nameof(SelectedDish));
            }
        }

        public ObservableCollection<Dish?> Dishes
        {
            get => _dishes;
            set
            {
                _dishes = value;
                OnPropertyChanged(nameof(Dishes));
            }
        }

        public ICommand AddDishCommand { get; }
        public ICommand UpdateDishCommand { get; }
        public ICommand DeleteDishCommand { get; }

        //private async Task LoadDishesAsync()
        //{
        //    await using var context = new RestaurantContext();
        //    if (context.Dishes != null)
        //    {
        //        await context.Dishes.LoadAsync().ConfigureAwait(false);
        //        foreach (var dish in context.Dishes.Local)
        //        {
        //            _dishes.Add(dish);
        //        }
        //    }
        //}

        private void LoadDishes()
        {
            _dishes.Clear();
            if (_context?.Dishes != null)
            {
                _context.Dishes.Load();
                foreach (var dish in _context.Dishes.Local)
                {
                    _dishes.Add(dish);
                }
            }
        }

        public static AddDishView GetNewDishDialog() => _addDishDialog;
        private void AddDish(object parameter)
        {
            _addDishDialog = new AddDishView()
            {
                Width = 600,
                Height = 400,
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            GetNewDishDialog().ShowDialog();
            LoadDishes();
        }
        private void UpdateDish(object parameter)
        {
            Dish? dataToUpdate =  _context.Dishes.Find(SelectedDish.DishId);

            if (dataToUpdate != null)
            {
                dataToUpdate.DishName = SelectedDish.DishName;
                dataToUpdate.Price = SelectedDish.Price;
                dataToUpdate.Category = SelectedDish.Category;
                dataToUpdate.ImagePath = SelectedDish.ImagePath;
            }

            _context.SaveChanges();
        }
        private bool CanEditOrDeleteDish(object parameter) => Dishes.Count > 0;
        private void DeleteDish(object parameter)
        {
            _context.Dishes?.Remove(SelectedDish);
            _context.SaveChanges();
            LoadDishes();
        }
    }
}
