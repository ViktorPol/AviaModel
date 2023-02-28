namespace AviaModel.Model.Entity
{
    public class Country
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public override string ToString()
        {
            return $"{Id}-{Name}";
        }
    }
}
