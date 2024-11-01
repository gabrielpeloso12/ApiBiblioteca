using Dados.Author;
using Microsoft.EntityFrameworkCore;
using ORM;
using System;

namespace Services.Author
{
    public class AuthorServices : IAuthorServices
    {
        private IAuthorDados _authorDAO;

        public AuthorServices(IAuthorDados usuarioDAO)
        {
            _authorDAO = usuarioDAO;
        }

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

        public void AddAuthor(Autor author)
        {
            _authorDAO.AddAuthor(author);
        }

        public void AddAuthor(IEnumerable<Autor> author)
        {
            _authorDAO.AddAuthors(author);
        }

        public void EditAuthor(Autor author)
        {
            _authorDAO.EditAddAuthor(author);
        }

        public void DeleteAuthor(Autor author)
        {
            _authorDAO.DeleteAddAuthor(author);
        }
    }
}
