using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ORM;
using Services.Book;

namespace ApiBiblioteca.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly AppDbContext _contexto;
        private IBookServices _bookService;

        public BookController(AppDbContext contexto, IBookServices bookService)
        {
            _contexto = contexto;
            _bookService = bookService;
        }

        #region Get
        [HttpGet(Name = "GetBook")]
        public async Task<IEnumerable<Livros>> GetBook()
        {
            var book = await _bookService.GetBook();

            return book;
        }

        [HttpGet("Id", Name = "GetBookId")]
        public async Task<ActionResult<Livros>> GetBookId(int id)
        {
            var author = await _bookService.GetBookPorId(id);

            if (author == null)
            {
                return NotFound();
            }
            else
            {
                return author;
            }
        }

        [HttpGet("ByTittle", Name = "GetBookTittle")]
        public async Task<IEnumerable<Livros>> GetBookTittle(string tittle)
        {
            var bookNome = await _bookService.GetBookTittle(tittle);

            return bookNome;

        }
        #endregion

        #region Post
        [HttpPost("PostBook", Name = "PostBook")]
        public async Task<ActionResult<Livros>> PostAuthor(Livros book, int idAuthor)
        {
            var autorExists = await _contexto.Autor.AnyAsync(a => a.Id == idAuthor);
            if (!autorExists)
            {
                throw new ArgumentException("O autor especificado não existe.");
            }

            _bookService.AddBook(book);

            return CreatedAtAction(nameof(GetBookId), new { id = book.Id }, book);
        }

        [HttpPost("PostBooks", Name = "PostBooks")]
        public async Task<ActionResult<List<Livros>>> PostAuthors(List<Livros> books)
        {
            if (books == null || books.Count == 0)
            {
                return BadRequest("A lista de autores não pode estar vazia.");
            }

            var autorIds = books.Select(b => b.Autor).Distinct().ToList();
            var autoresExistentes = await _contexto.Autor
                .Where(a => autorIds.Contains(a.Id))
                .Select(a => a.Id)
                .ToListAsync();

            if (autoresExistentes.Count != autorIds.Count)
            {
                return BadRequest("Um ou mais autores não existem.");
            }


            try
            {
                _bookService.AddBooks(books);
          
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetBook), books);
        }
        #endregion

        #region Put
        [HttpPut("PutBook/{id}")]
        public async Task<IActionResult> PutBook(int id, int idAutor, Livros book)
        {
            if (book == null)
            {
                throw new ArgumentNullException("O usuário não pode ser nulo");
            }

            if (id != book.Id)
            {
                return BadRequest("O ID do usuário não corresponde ao ID na URL");
            }



            try
            {
                var autorExists = await _contexto.Autor.AnyAsync(a => a.Id == idAutor);
                if (!autorExists)
                {
                    throw new ArgumentException("O autor especificado não existe.");
                }
                else
                { 
                    _bookService.EditBook(book);
                }
            }
            catch (Exception)
            {
                var existsAuthor = await _bookService.GetBookPorId(id);

                if (existsAuthor == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        #endregion

        #region Delete
        [HttpDelete("DeleteBook/{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var book = await _bookService.GetBookPorId(id);

            if (book == null)
            {
                return NotFound();
            }

            _bookService.DeleteBook(book);

            return NoContent();
        }
        #endregion
    }
}
