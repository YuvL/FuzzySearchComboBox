using DemoApplication.DemoData;

namespace DemoApplication.ViewModels
{
    public class AddressAutocompleteViewModel : BaseViewModel
    {
        public AddressAutocompleteViewModel()
        {
            AddressDictionary = Dictionaries.InitAddressDictionaryExt();
        }
    }
}
