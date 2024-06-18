namespace APBD_test2.Dtos
{
    public class BookDto
    {
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int PublishingHouseId { get; set; }
        public string PublishingHouseName { get; set; }
        public string PublishingHouseCountry { get; set; }
        public string PublishingHouseCity { get; set; }
        public List<int> AuthorIds { get; set; }
        public List<int> GenreIds { get; set; }
    }
}
