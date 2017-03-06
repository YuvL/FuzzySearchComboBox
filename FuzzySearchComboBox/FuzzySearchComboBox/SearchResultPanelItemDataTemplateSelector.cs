using System.Windows;
using System.Windows.Controls;

namespace Controls.FuzzySearchComboBox
{
    public class SearchResultPanelItemDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate CommonItemDataTemplate { get; set; }
        public DataTemplate HeaderItemDataTemplate { get; set; }
        public DataTemplate ButtonItemDataTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var resultItem = item as FuzzySearchCombobox.ResultItem;
            if (resultItem == null) return null;

            switch (resultItem.ItemType)
            {
                case ItemType.Common:
                    return CommonItemDataTemplate;

                case ItemType.Header:
                    return HeaderItemDataTemplate;

                case ItemType.Button:
                    return ButtonItemDataTemplate;

                default:
                    return HeaderItemDataTemplate;
            }
        }
    }
}
