namespace eUcionica.EntityLib
{
    public class Zadatak
    {
        public int ZadatakId { get; set; }
        public string SadrzajZadatka { get; set; }

        public int NivoTezine { get; set; }

        public int OblastId { get; set; }
        public Oblast Oblast { get; set; }
    }
}
