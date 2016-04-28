using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace

namespace Controls.FuzzySearchComboBox
{
    public class ValueContainer : IComparable<ValueContainer>
    {
        public int? ID { get; private set; }
        public Dictionary<int?, ValueContainer> Childs { get; set; }
        public bool IsDeleted { get; private set; }
        public Dictionary<int?, ValueContainer> Parents { get; set; }
        public string Value { get; private set; }
        public ValueContainer() {}

        public ValueContainer(int? id, string strValue, bool isDeleted = false)
        {
            ID = id;
            Value = strValue;
            IsDeleted = isDeleted;
        }

        protected bool Equals(ValueContainer other)
        {
            return ID == other.ID;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ValueContainer) obj);
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        public override string ToString()
        {
            return Value;
        }

        public int CompareTo(ValueContainer other)
        {
            return string.Compare(Value, other.Value, StringComparison.Ordinal);
        }
    }
}