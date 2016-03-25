using System.Windows;
using System.Windows.Controls;

// ReSharper disable once CheckNamespace
namespace Protei.WPFControls.FilterCombobox
{
    public class SearchResultPanelItemDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate CommonItemDataTemplate { get; set; }
        public DataTemplate HeaderItemDataTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var resultItem = item as FilterCombobox.ResultItem;
            if (resultItem == null) return null;

            switch (resultItem.ItemType)
            {
                case ItemType.Common:
                    return CommonItemDataTemplate;

                case ItemType.Header:
                    return HeaderItemDataTemplate;
            }

            return HeaderItemDataTemplate;
        }
    }
}
