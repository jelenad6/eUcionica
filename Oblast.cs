namespace eUcionica.EntityLib
{
    public class Oblast
    {
        public int OblastId { get; set; }
        public string NazivOblasti { get; set; }

        public int PredmetId { get; set; }
        public Predmet Predmet { get; set; }

        public ICollection<Zadatak> Zadatak { get; set; } = new List<Zadatak>();
    }
}
