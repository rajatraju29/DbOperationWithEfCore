namespace DbOperationsForEfCore.Data
{
    public class BookPrice
    {
        public int Bookid { get; set; }
        public int Amount { get; set; }
        public int CurrencyId { get; set; }
        public int id { get; set; }
        public Book Book { get; set; }
        public Currency Currency { get; set; }

    }
}
