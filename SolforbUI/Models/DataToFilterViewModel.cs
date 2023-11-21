namespace SolforbUI.Models
{
    public class DataToFilterViewModel:UniqueElementsViewModel
    {
        public DateOnly PreviousDate { get; set; }

        public DateOnly CurrentDate { get; set; }
    }
}
