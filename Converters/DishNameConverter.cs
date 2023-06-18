using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using ClodeMonnetV2.Model;

namespace ClodeMonnetV2.Converters
{
    public class DishNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int dishId = (int)value;
            string dishName = GetDishNameById(dishId);
            return dishName;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private string GetDishNameById(int dishId)
        {
            using (var context = new RestaurantDbContext())
            {
                var dish = context.Dishes.FirstOrDefault(d => d.DishId == dishId);

                if (dish is { DishName: not null }) return dish.DishName;
                else return string.Empty;
            }
        }

    }

}
