namespace AccioBook.Domain.Entities
{
    public class Edition
    {
        public Int64 Id { get; set; }
        public Int64 Id_Book { get; set; }
        public Book Book { get; set; }
        public Int64 Id_Publisher { get; set; }
        public Publisher Publisher { get; set; }
        public Int64 Id_Language { get; set; }
        public Language Language { get; set; }
        public DateTime PublicationDate { get; set; }
        public Int64 PageCount { get; set; }
        public string ISBNCode_10 { get; set; }
        public string ISBNCode_13 { get; set; }
    }
}
