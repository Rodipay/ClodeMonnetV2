using ClodeMonnetV2.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Microsoft.EntityFrameworkCore;

namespace ClodeMonnetV2.Converters
{
    public class OrderIdToDishNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int orderId)
            {
                using (var context = new RestaurantDbContext())
                {
                    var dishQuantities = context.OrderItems
                        .Where(oi => oi.OrderId == orderId)
                        .Join(context.Dishes,
                            oi => oi.DishId,
                            d => d.DishId,
                            (oi, d) => new { DishName = d.DishName, Quantity = oi.Quantity })
                        .ToList();

                    var result = new StringBuilder();
                    foreach (var dishQuantity in dishQuantities)
                    {
                        result.AppendLine($"{dishQuantity.DishName}: {dishQuantity.Quantity}");
                    }

                    return result.ToString();
                }
            }

            return string.Empty;
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


}
