using System.ComponentModel.DataAnnotations;

namespace DbOperationsForEfCore.Data
{
    public class Status
    {
        [Key]
        public int Statusid { get; set; }
        public string? StatusDesc { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
