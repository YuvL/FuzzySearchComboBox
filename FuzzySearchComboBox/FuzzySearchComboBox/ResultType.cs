using System.ComponentModel.DataAnnotations;

// ReSharper disable once CheckNamespace
namespace Controls.FuzzySearchComboBox
{
    public enum ResultType
    {
        [Display(Name = "Empty")]
        Empty,

        [Display(Name = "All")]
        All,

        [Display(Name = "Strong")]
        Strong,

        [Display(Name = "Fuzzy")]
        Fuzzy,

        [Display(Name = "Renamed")]
        Renamed,

        [Display(Name = "ShowAll")]
        ShowAll
    }
}