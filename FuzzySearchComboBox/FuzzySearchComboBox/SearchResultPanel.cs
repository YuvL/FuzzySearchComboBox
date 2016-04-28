using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

// ReSharper disable once CheckNamespace
namespace Controls.FuzzySearchComboBox
{
    public class SearchResultPanel : ListBox
    {
        public SearchResultPanel()
        {
            ItemContainerGenerator.StatusChanged += ItemContainerGenerator_StatusChanged;

        }
        public void ScrollToTop()
        {
            SelectedIndex = -1;
        }

        //скроллинг http://social.msdn.microsoft.com/Forums/vstudio/en-US/8f26a3c6-8a6b-405e-9d0e-a1d4eaaab4c7/listbox-keyboard-focus-why-does-it-work-this-way?forum=wpf 
        void ItemContainerGenerator_StatusChanged(object sender, EventArgs e)
        {
            ScrollToSelectedItem();
        }

        public void ScrollToSelectedItem()
        {
            var item = (ListBoxItem)ItemContainerGenerator.ContainerFromItem(SelectedItem);

            if (item == null) return;
            item.Focus();
            //   item.BringIntoView();
        }

        public void FocusItem(FuzzySearchCombobox.ResultItem selection)
        {
            if (ItemsSource == null || !ItemsSource.OfType<FuzzySearchCombobox.ResultItem>().Any())
                return;

            while (true)
            {
                if (ItemContainerGenerator.Status != GeneratorStatus.ContainersGenerated) continue;
                var listBoxItem = ItemContainerGenerator.ContainerFromItem(selection) as ListBoxItem;
                if (listBoxItem == null) return;
                listBoxItem.Focus();
                return;
            }
        }
    }
}
