namespace DbOperationsForEfCore.Data
{
    public class Currency
    {
        public int id { get; set; }
       // public string Currencyin { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<BookPrice> BookPrice { get; set; }
    }
}
