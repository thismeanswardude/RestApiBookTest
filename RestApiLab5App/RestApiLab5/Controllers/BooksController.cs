using Microsoft.AspNetCore.Mvc;
using RestApiLab5.Models;
using RestApiLab5.Repo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestApiLab5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IBook _BookRepo;

        // ο constructor
        public BooksController(IBook bookRepo)
        {
            _BookRepo = bookRepo;
            // _BookRepo = new InMemBookRepo();
        }

        // GET: api/Books
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            return _BookRepo.GetBooks().ToList();
        }


        // GET api/Books/5
        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(Guid id)
        {
            var book = _BookRepo.GetBook(id);
            if (book == null)
                return NotFound();
            return book;
        }


        // POST api/Books
        [HttpPost]
        public ActionResult CreateBook(CreateOrUpdateBookSchema book)
        {
            var mybook = new Book();
            mybook.Id = Guid.NewGuid();
            mybook.Title = book.Title;
            mybook.Price = book.Price;
            _BookRepo.CreateBook(mybook);
            return Ok();
        }


        // PUT api/Books/5
        [HttpPut("{id}")]
        public ActionResult UpdateBook(Guid id, CreateOrUpdateBookSchema
book)
        {
            var mybook = _BookRepo.GetBook(id);
            if (mybook == null)
                return NotFound();
            mybook.Title = book.Title;
            mybook.Price = book.Price;
            _BookRepo.UpdateBook(id, mybook);
            return Ok();
        }


        // DELETE api/Books/5
        [HttpDelete("{id}")]
        public ActionResult DeleteBook(Guid id)
        {
            var mybook = _BookRepo.GetBook(id);
            if (mybook == null)
                return NotFound();
            _BookRepo.DeleteBook(id);
            return Ok();
        }

    }
}
