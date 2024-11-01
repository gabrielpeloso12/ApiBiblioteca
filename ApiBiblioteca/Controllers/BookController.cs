using Microsoft.AspNetCore.Mvc;
using ORM;
using Services.Book;

namespace ApiBiblioteca.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController
    {
        private readonly AppDbContext _contexto;
        private IBookServices _bookService;

        public BookController(AppDbContext contexto, IBookServices bookService)
        {
            _contexto = contexto;
            _bookService = bookService;
        }

        [HttpGet("GetBook", Name = "GetBook")]
        [HttpPost("PostBook", Name = "PostBook")]
        [HttpPut("PutBook/{Id}")]
        [HttpDelete("DeleteBook{Id}")]
    }
}
