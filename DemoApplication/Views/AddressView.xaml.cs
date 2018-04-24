using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DemoApplication.ViewModels;

namespace DemoApplication.Views
{
    /// <summary>
    /// Interaction logic for AddressView.xaml
    /// </summary>
    public partial class AddressView : UserControl
    {
        public AddressView()
        {
            InitializeComponent();
            GridScope.DataContext = new AddressViewModel();
            GridScopeA.DataContext = new AddressAutocompleteViewModel();
            GridScopeB.DataContext = new AddressViewModel();

            GridScopeP.DataContext = new AddressAutocompleteViewModel();

            GridScopeRealAddressData.DataContext = new RealAddressViewModel();

            Loaded += (sender, args) => FocusManager.SetFocusedElement(GridScopeRealAddressData, StreetComboboxReal); 
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var msg = new StringBuilder();

            if (!CityComboboxA.IsValid)
                msg.AppendLine("City not valid.");
            if (!CityComboboxA.IsValidInGroup)
                msg.AppendLine("City not requared.");

            if (!RegionComboboxA.IsValid)
                msg.AppendLine("Region not valid.");
            if (!RegionComboboxA.IsValidInGroup)
                msg.AppendLine("Region requared.");

            if (!CountryComboboxA.IsValid)
                msg.AppendLine("Country not valid.");
            if (!CountryComboboxA.IsValidInGroup)
                msg.AppendLine("Country requared.");



            if (String.IsNullOrEmpty(msg.ToString()))
                MessageBox.Show("Address is valid.", "Success", MessageBoxButton.OK);
            else
                MessageBox.Show(msg.ToString(), "Error", MessageBoxButton.OK);
        }
    }
}
