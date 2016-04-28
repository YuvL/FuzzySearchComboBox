using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Controls.FuzzySearchComboBox
{
    internal class WeakReferenceCollection : IEnumerable<FuzzySearchCombobox>
    {
        private readonly List<WeakReference> _internalCollection = new List<WeakReference>();

        private List<WeakReference> InternalCollection
        {
            get
            {
                ClearReferences();
                return _internalCollection;
            }
        }

        public void ClearReferences()
        {
            var withoutReferences = _internalCollection.Where(x => !x.IsAlive).ToArray();
            foreach (var comboboxWithoutReference in withoutReferences)
            {
                _internalCollection.Remove(comboboxWithoutReference);
            }
        }

        public IEnumerator<FuzzySearchCombobox> GetEnumerator()
        {
            return InternalCollection.Select(x => x.Target as FuzzySearchCombobox).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(FuzzySearchCombobox fuzzySearchCombobox)
        {
            InternalCollection.Add(new WeakReference(fuzzySearchCombobox));
        }
    }
}