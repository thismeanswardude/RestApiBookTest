using RestApiLab5.Models;

namespace RestApiLab5.Repo
{
    public class InMemBookRepo : IBook
    {
        // δημιουργία αποθετηρίου ως λίστα
        private List<Book> _Books;

        // ο κατασκευαστής (constructor) του αντικειμένου InMemBookRepo
        public InMemBookRepo()
        {
            // καταχώριση ενός πρώτου βιβλίου
            _Books = new() { new Book { Id=Guid.NewGuid(), Title="Book 0", Price=10}};
        }

        public void CreateBook(Book book)
        {
            _Books.Add(book);
        }


        public void DeleteBook(Guid id)
        {
            var bookIndex = _Books.FindIndex(x => x.Id == id);
            if (bookIndex > -1)
                _Books.RemoveAt(bookIndex);
        }

        public Book GetBook(Guid id)
        {
            var book = _Books.Where(x => x.Id == id).SingleOrDefault();
            return book;

        }

        public IEnumerable<Book> GetBooks()
        {
            return _Books;
        }

        public void UpdateBook(Guid id, Book book)
        {
            var bookIndex = _Books.FindIndex(x => x.Id == id);
            if (bookIndex > -1)
                _Books[bookIndex] = book;
        }
    }
}
