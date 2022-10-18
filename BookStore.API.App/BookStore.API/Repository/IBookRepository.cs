using BookStore.API.Data;
using BookStore.API.Modesl;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.API.Repository
{
    public interface IBookRepository
    {
        Task<List<BookModel>> GetAllBooksAsync();
        Task<BookModel> GetBookAsync(int id);
        Task<int> AddBookAsync(BookModel bookModel);
        Task<BookModel> UpdateBookAsync(int id, BookModel bookModel);
        Task<Books> UpdateBookPatchAsync(int id, JsonPatchDocument bookModel);
        Task<int> DeleteBookAsync(int id);
    }
}
