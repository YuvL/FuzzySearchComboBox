using System.ComponentModel.DataAnnotations;

// ReSharper disable once CheckNamespace
namespace Protei.WPFControls.FilterCombobox
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