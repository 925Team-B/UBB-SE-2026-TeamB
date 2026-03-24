using BankingAppTeamB.Configuration;
using BankingAppTeamB.Models;
using BankingAppTeamB.ViewModels;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.ComponentModel;

namespace BankingAppTeamB.Views
{
    public sealed partial class BillPayPage : Page
    {
        private readonly BillPayViewModel _viewModel;

        public BillPayPage()
        {
            InitializeComponent();
            _viewModel = new BillPayViewModel(ServiceLocator.BillPaymentService);
            DataContext = _viewModel;
            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            await _viewModel.LoadAsync();
        }

        private void SearchBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                _viewModel.SearchCommand.Execute(null);
            }
        }

        private void CategoryCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _viewModel.SearchCommand.Execute(null);
        }

        private void BillersList_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem is Biller biller)
            {
                _viewModel.SelectBillerCommand.Execute(biller);
            }
        }

        private void SavedBillersList_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem is SavedBiller savedBiller)
            {
                _viewModel.SelectBillerCommand.Execute(savedBiller);
            }
        }

        private void AmountBox_ValueChanged(NumberBox sender, NumberBoxValueChangedEventArgs args)
        {
            if (!double.IsNaN(sender.Value) && !double.IsInfinity(sender.Value))
            {
                _viewModel.Amount = Convert.ToDecimal(sender.Value);
            }
            else
            {
                _viewModel.Amount = 0;
            }
        }

        private void ViewModel_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(BillPayViewModel.Amount))
            {
                if (AmountBox != null)
                {
                    double newValue = Convert.ToDouble(_viewModel.Amount);

                    if (AmountBox.Value != newValue)
                    {
                        AmountBox.Value = newValue;
                    }
                }
            }
        }
    }
}

/*using BankingAppTeamB.Configuration;
using BankingAppTeamB.Models;
using BankingAppTeamB.ViewModels;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using System;

namespace BankingAppTeamB.Views
{
    public sealed partial class BillPayPage : Page
    {
        private readonly BillPayViewModel _viewModel;

        public BillPayPage()
        {
            InitializeComponent();
            _viewModel = new BillPayViewModel(ServiceLocator.BillPaymentService);
            DataContext = _viewModel;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            await _viewModel.LoadAsync();
        }

        private void SearchBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                _viewModel.SearchCommand.Execute(null);
            }
        }

        private void CategoryCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _viewModel.SearchCommand.Execute(null);
        }

        private void BillersList_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem is Biller biller)
            {
                _viewModel.SelectBillerCommand.Execute(biller);
            }
        }

        private void SavedBillersList_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem is SavedBiller savedBiller)
            {
                _viewModel.SelectBillerCommand.Execute(savedBiller);
            }
        }

        private void AmountBox_ValueChanged(NumberBox sender, NumberBoxValueChangedEventArgs args)
        {
            if (!double.IsNaN(sender.Value) && !double.IsInfinity(sender.Value))
            {
                _viewModel.Amount = Convert.ToDecimal(sender.Value);
            }
            else
            {
                _viewModel.Amount = 0;
            }
        }
    }
}
*/
