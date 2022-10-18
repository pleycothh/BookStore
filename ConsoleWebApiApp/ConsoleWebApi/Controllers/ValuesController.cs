using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleWebApi.Controllers
{
    [Route("api/[controller]-[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        [Route("~/get-all")] // <- overwrite route
        [Route("[controller]-[action]")]
        public string GetAll()
        { 

            return "hello get all";
        }

        [Route("get-all-authors")]
        public string GetAllAuthors()
        {
            return "hello get all authors";
        }


        [Route("get-by-id/{id?}")]
        public string GetById(int id)
        {
            return $"hello get by {id}";
        }

        [Route("books/{id}/author/{authorId}")]
        public string GetAuthorAddressById(int id, int authorId)
        {
            return $"hello get by {id} for author {authorId}";
        }

        [Route("search")]
        public string SearchBooks(int id, string name, int authorId, int rating, int prict) // this is query string passed into URL parmas
        {
            return $"hello get by {id} for author {authorId}";
        }


    }
}
