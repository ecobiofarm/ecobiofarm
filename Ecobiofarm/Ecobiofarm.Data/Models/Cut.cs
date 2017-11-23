namespace EcoBioFarm.Data.Models
{
    public class Cut
    {
        public long Id { get; set; }

        public string Value { get; set; }

        public long ProductId { get; set; }

        public virtual Product Product { get; set; }

    }
}