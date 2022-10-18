using BookStore.API.Modesl;
using BookStore.API.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository bookRepository;

        public BooksController( IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }


        [HttpGet("")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await bookRepository.GetAllBooksAsync();
            return Ok(books.ToArray());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById([FromRoute]int id)
        {
            var book = await bookRepository.GetBookAsync( id);
            return book is null ? NotFound() : Ok(book);
        }

        [HttpPost("")]
        public async Task<IActionResult> GetBookById([FromBody] BookModel book)
        {
            var id = await bookRepository.AddBookAsync(book);
            return CreatedAtAction(nameof(GetBookById), new {id = id, controller = "books"}, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> GetBookById([FromRoute] int id, [FromBody] BookModel book)
        {
            var newBook = await bookRepository.UpdateBookAsync(id,book);

            return Ok(newBook);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> GetBookPatch([FromRoute] int id, [FromBody] JsonPatchDocument book)
        {
            var newBook = await bookRepository.UpdateBookPatchAsync(id, book);

            return Ok(newBook);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveBookPatch([FromRoute] int id)
        {
            var removeId = await bookRepository.DeleteBookAsync(id);

            return Ok(removeId);
        }



    }
}
