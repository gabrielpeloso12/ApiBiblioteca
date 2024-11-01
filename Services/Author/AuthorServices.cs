using Dados.Author;
using Microsoft.EntityFrameworkCore;
using ORM;


namespace Services.Author
{
    public class AuthorServices : IAuthorServices
    {
        private IAuthorDados _authorDAO;

        public AuthorServices(IAuthorDados authorDAO)
        {
            _authorDAO = authorDAO;
        }

        #region Get
        public async Task<IList<Autor>> GetAuthor()
        {
            return await _authorDAO.GetAuthor().ToListAsync();
        }

        public async Task<Autor?> GetAuthorPorId(int id)
        {
            return await _authorDAO.GetAuthor().FindAsync(id);
        }

        public async Task<IEnumerable<Autor>> GetAuthorName(string nome)
        {
            return await _authorDAO.GetAuthor().Where(u => u.Nome == nome).ToListAsync();
        }
        #endregion

        #region Post
        public void AddAuthor(Autor author)
        {
            _authorDAO.AddAuthor(author);
        }

        public void AddAuthors(IEnumerable<Autor> author)
        {
            _authorDAO.AddAuthors(author);
        }
        #endregion

        #region Edit
        public void EditAuthor(Autor author)
        {
            _authorDAO.EditAddAuthor(author);
        }
        #endregion

        #region Delete
        public void DeleteAuthor(Autor author)
        {
            _authorDAO.DeleteAddAuthor(author);
        }
        #endregion
    }
}
