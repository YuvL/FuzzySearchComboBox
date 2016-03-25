using System.ComponentModel.DataAnnotations;

// ReSharper disable once CheckNamespace
namespace WPFControls.FuzzySearchComboBox
{
    public enum ResultType
    {
        [Display(Name = "Неизвестно")]
        Empty,

        [Display(Name = "Все")]
        All,

        [Display(Name = "По алфавиту")]
        Strong,

        [Display(Name = "Нечетко")]
        Fuzzy,

        [Display(Name = "Переименовано")]
        Renamed
    }
}