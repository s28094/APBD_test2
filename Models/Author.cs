namespace APBD_test2.Models;

public class Author
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Book> BookAuthors { get; set; }
}