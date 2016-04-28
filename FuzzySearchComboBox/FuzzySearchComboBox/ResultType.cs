using System.ComponentModel.DataAnnotations;

// ReSharper disable once CheckNamespace
namespace Controls.FuzzySearchComboBox
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