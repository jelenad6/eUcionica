namespace eUcionica.EntityLib
{
    public class Predmet
    {
        public int PredmetId { get; set; }
        public string NazivPredmeta { get; set; }
        public ICollection<Oblast> Oblast { get; set; } = new List<Oblast>();
    }
}
