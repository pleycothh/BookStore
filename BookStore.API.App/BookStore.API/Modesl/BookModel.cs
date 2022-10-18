using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace BookStore.API.Modesl
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
