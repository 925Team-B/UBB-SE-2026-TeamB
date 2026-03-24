using BankingAppTeamB.Configuration;
using BankingAppTeamB.ViewModels;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using System;

namespace BankingAppTeamB.Views
{
    public sealed partial class RecurringPaymentsPage : Page
    {
        private readonly RecurringPaymentViewModel _viewModel;

        public RecurringPaymentsPage()
        {
            InitializeComponent();
            _viewModel = new RecurringPaymentViewModel(ServiceLocator.RecurringPaymentService);
            DataContext = _viewModel;

            StartDatePicker.Date = DateTimeOffset.Now;
            EndDatePicker.Date = DateTimeOffset.Now;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            await _viewModel.LoadAsync();
        }

        private void AmountTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (DataContext is RecurringPaymentViewModel vm && sender is TextBox textBox)
            {
                if (decimal.TryParse(textBox.Text, out decimal value))
                {
                    vm.Amount = value;
                }
                else
                {
                    vm.Amount = 0;
                }
            }
        }

        private void StartDatePicker_DateChanged(object sender, DatePickerValueChangedEventArgs args)
        {
            if (DataContext is RecurringPaymentViewModel vm && sender is DatePicker picker)
            {
                vm.StartDate = picker.Date.DateTime.Date;
            }
        }

        private void EndDatePicker_DateChanged(object sender, DatePickerValueChangedEventArgs args)
        {
            if (DataContext is RecurringPaymentViewModel vm && sender is DatePicker picker)
            {
                vm.EndDate = picker.Date.DateTime.Date;
            }
        }
    }
}

//using BankingAppTeamB.Configuration;
//using BankingAppTeamB.Models;
//using BankingAppTeamB.ViewModels;
//using Microsoft.UI.Xaml;
//using Microsoft.UI.Xaml.Controls;
//using Microsoft.UI.Xaml.Navigation;
//using System;

//namespace BankingAppTeamB.Views
//{
//    public sealed partial class RecurringPaymentsPage : Page
//    {
//        private readonly RecurringPaymentViewModel _viewModel;

//        public RecurringPaymentsPage()
//        {
//            InitializeComponent();
//            _viewModel = new RecurringPaymentViewModel(ServiceLocator.RecurringPaymentService);
//            DataContext = _viewModel;

//            StartDatePicker.Date = DateTimeOffset.Now;
//            EndDatePicker.Date = DateTimeOffset.Now;
//        }

//        protected override async void OnNavigatedTo(NavigationEventArgs e)
//        {
//            base.OnNavigatedTo(e);
//            await _viewModel.LoadAsync();
//        }

//        private void AmountTextBox_TextChanged(object sender, TextChangedEventArgs e)
//        {
//            if (DataContext is RecurringPaymentViewModel vm && sender is TextBox textBox)
//            {
//                if (decimal.TryParse(textBox.Text, out decimal value))
//                {
//                    vm.Amount = value;
//                }
//                else
//                {
//                    vm.Amount = 0;
//                }
//            }
//        }

//        private void StartDatePicker_DateChanged(object sender, DatePickerValueChangedEventArgs args)
//        {
//            if (DataContext is RecurringPaymentViewModel vm && sender is DatePicker picker)
//            {
//                vm.StartDate = picker.Date.DateTime.Date;
//            }
//        }

//        private void EndDatePicker_DateChanged(object sender, DatePickerValueChangedEventArgs args)
//        {
//            if (DataContext is RecurringPaymentViewModel vm && sender is DatePicker picker)
//            {
//                vm.EndDate = picker.Date.DateTime.Date;
//            }
//        }

//        private void NextExecutionTextBlock_Loaded(object sender, RoutedEventArgs e)
//        {
//            if (sender is TextBlock textBlock &&
//                textBlock.DataContext is RecurringPayment payment)
//            {
//                if (payment.Status != PaymentStatus.Active)
//                {
//                    textBlock.Text = "Next Execution: -";
//                    return;
//                }

//                DateTime nextExecution = CalculateNextExecution(payment.StartDate, payment.Frequency);
//                textBlock.Text = $"Next Execution: {nextExecution:dd/MM/yyyy}";
//            }
//        }

//        private DateTime CalculateNextExecution(DateTime startDate, RecurringFrequency frequency)
//        {
//            return frequency switch
//            {
//                RecurringFrequency.Daily => startDate.AddDays(1),
//                RecurringFrequency.Weekly => startDate.AddDays(7),
//                RecurringFrequency.BiWeekly => startDate.AddDays(14),
//                RecurringFrequency.Monthly => startDate.AddMonths(1),
//                RecurringFrequency.Yearly => startDate.AddYears(1),
//                _ => startDate
//            };
//        }
//    }
//}
