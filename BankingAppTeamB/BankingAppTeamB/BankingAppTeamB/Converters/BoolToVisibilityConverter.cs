using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using System;

namespace BankingAppTeamB.Converters;

public class BoolToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        // If IsTriggered is true, show the badge. Otherwise, hide it.
        if (value is bool isTriggered && isTriggered)
            return Visibility.Visible;

        return Visibility.Collapsed;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}