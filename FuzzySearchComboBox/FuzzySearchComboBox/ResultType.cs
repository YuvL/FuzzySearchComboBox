using System.ComponentModel.DataAnnotations;

// ReSharper disable once CheckNamespace
namespace Controls.FuzzySearchComboBox
{
    public enum ResultType
    {
        Empty,
        All,
        Strong,
        Fuzzy,
        Renamed,
        ShowAll
    }
}