namespace TripsBooking.DTOs
{
    public class ItemDto
    {
        public string Label { get; set; }

        public decimal? Value { get; set; }

        public ItemDto(string label, decimal? value)
        {
            Label = label;
            Value = value;
        }
    }
}