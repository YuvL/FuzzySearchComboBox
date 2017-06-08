using DemoApplication.DemoData;

namespace DemoApplication.ViewModels
{
    public class AddressViewModel : BaseViewModel
    {
        public AddressViewModel()
        {
            AddressDictionary = Dictionaries.InitAddressDictionary();
        }
    }
}
