using System.Windows;
using System.Windows.Controls;

// ReSharper disable once CheckNamespace
namespace Controls.FuzzySearchComboBox
{
    public class SearchResultPanelItemContainerStyleSelector : StyleSelector
    {
        public Style HeaderStyle { get; set; }
        public Style CommonStyle { get; set; }

        public override Style SelectStyle(object item, DependencyObject container)
        {
            var resultItem = item as FuzzySearchCombobox.ResultItem;
            return resultItem != null && (resultItem.ItemType == ItemType.Header || resultItem.ItemType == ItemType.Button) ? HeaderStyle : CommonStyle;
        }
    }
}