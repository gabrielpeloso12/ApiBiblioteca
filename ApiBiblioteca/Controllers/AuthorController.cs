using Microsoft.AspNetCore.Mvc;
using ORM;
using Services.Author;

namespace ApiBiblioteca.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly AppDbContext _contexto;
        private IAuthorServices _authorService;

        public AuthorController(AppDbContext contexto, IAuthorServices authorService)
        {
            _contexto = contexto;
            _authorService = authorService;
        }

        #region Get
        [HttpGet(Name = "GetAuthor")]
        public async Task<IEnumerable<Autor>> GetAuthor()
        {
            var author = await _authorService.GetAuthor();

            return author;
        }

        [HttpGet("Id", Name = "GetAuthorId")]
        public async Task<ActionResult<Autor>> GetAuthorId(int id)
        {
            var author = await _authorService.GetAuthorPorId(id);

            if (author == null)
            {
                return NotFound();
            }
            else
            {
                return author;
            }
        }

        [HttpGet("ByName", Name = "GetAuthorName")]
        public async Task<IEnumerable<Autor>> GetAuthorName(string nome)
        {
            var authorNome = await _authorService.GetAuthorName(nome);

            return authorNome;
                        
        }
        #endregion

        #region Post
        [HttpPost("PostAuthor", Name = "PostAuthor")]
        public ActionResult<Autor> PostAuthor(Autor author)
        {
           _authorService.AddAuthor(author);

           return CreatedAtAction(nameof(GetAuthorId), new { id = author.Id }, author);
        }

        [HttpPost("PostAuthors", Name = "PostAuthors")]
        public ActionResult<List<Autor>> PostAuthors(List<Autor> authors)
        {
            if (authors == null || authors.Count == 0)
            {
                return BadRequest("A lista de autores não pode estar vazia.");
            }

            try
            {
                _authorService.AddAuthors(authors);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
            return CreatedAtAction(nameof(GetAuthor), authors);
        }
        #endregion

        #region Put
        [HttpPut("PutAuthor/{id}")]
        public async Task<IActionResult> PutAuthor(int id, Autor author)
        {
            if (author == null)
            {
                throw new ArgumentNullException("O usuário não pode ser nulo");
            }

            if (id != author.Id)
            {
                return BadRequest("O ID do usuário não corresponde ao ID na URL");
            }

            try
            {
                _authorService.EditAuthor(author);
            }
            catch (Exception)
            {
                var existsAuthor = await _authorService.GetAuthorPorId(id);

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
        [HttpDelete("DeleteAuthor/{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _authorService.GetAuthorPorId(id);

            if (usuario == null)
            {
                return NotFound();
            }

            _authorService.DeleteAuthor(usuario);

            return NoContent();
        }
        #endregion
    }
}
