namespace AviaModel.Model.Entity
{
    public class Avia
    {
        public int Id { get; set; }
        public string? Country { get; set; }
        public string? Mark { get; set; }
        public string? Model { get; set; }
        public int CountPassagers{get; set; }

        public override string ToString()
        {
            return $"{Id}-{Country}-{Mark}-{Model}-{CountPassagers}";
        }
    }
}
