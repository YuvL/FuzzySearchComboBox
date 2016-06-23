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
            DataContext = new AddressViewModel();
            //Loaded += (sender, args) => Keyboard.Focus(CountryCombobox);
            Loaded += (sender, args) => FocusManager.SetFocusedElement(GridScope, CountryCombobox); ;
        }
    }
}
