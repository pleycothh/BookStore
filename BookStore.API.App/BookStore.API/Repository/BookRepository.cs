using BookStore.API.Data;
using BookStore.API.Modesl;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context; // is context injected at startup class
        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }


        public async Task<List<BookModel>> GetAllBooksAsync()
        {
            // convert book context from database to bookmodel from app
            var records =await _context.Books.Select(x => new BookModel()
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
            }).ToListAsync();

            return records;
        }

        

        public async Task<BookModel> GetBookAsync(int id)
        {
            // convert book context from database to bookmodel from app
            var records = await _context.Books
                .Where(x => x.Id == id)
                .Select(x => new BookModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description
                })
                .FirstOrDefaultAsync();
            return records;
        }

        public async Task<int> AddBookAsync(BookModel bookModel)
        {
            var book = new Books()
            {
                Title = bookModel.Title,
                Description = bookModel.Description
            };
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();

            return book.Id;
        }

        public async Task<BookModel> UpdateBookAsync(int id, BookModel bookModel)
        {
            //    // get item from EF
            //    var book = await _context.Books.FindAsync(id);
            //
            //    if(book != null)
            //    {
            //        // EF will recored all the changes
            //        book.Title = bookModel.Title;
            //        book.Description = bookModel.Description;
            //        
            //        // if change occoured, save change method will save it.
            //        await _context.SaveChangesAsync();
            //    }

            var book = new Books()
            {
                Id = id,
                Title = bookModel.Title,
                Description = bookModel.Description
            };
            _context.Books.Update(book); // recored the modefy with update method
            await _context.SaveChangesAsync(); // <- only hit database with one call


            return bookModel;
        }


        public async Task<Books> UpdateBookPatchAsync(int id, JsonPatchDocument bookModel)
        {

                // get item from EF
                var book = await _context.Books.FindAsync(id);
            
                if(book != null)
                {
                // EF will recored all the changes
                    bookModel.ApplyTo(book);
                    // if change occoured, save change method will save it.
                    await _context.SaveChangesAsync();
                }
            //   var book = new Books()
            //   {
            //       Id = id,
            //       Title = bookModel.Title,
            //       Description = bookModel.Description
            //   };
            //   _context.Books.Update(book); // recored the modefy with update method
            //   await _context.SaveChangesAsync(); // <- only hit database with one call
            //

            return book;
        }


        public async Task<int> DeleteBookAsync(int id)
        {
            // if not have PK
         //   var book = _context.Books.Where(x => x.Id == id).FirstOrDefault();
           
            // if has PK
            var book = new Books() { Id = id };
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return id;
        }




    }
}
