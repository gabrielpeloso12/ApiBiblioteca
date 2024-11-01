using Microsoft.EntityFrameworkCore;
using ORM;

namespace Dados.Author
{
    public class AuthorDados : IAuthorDados
    {
        private AppDbContext _contexto;

        public AuthorDados(AppDbContext contexto)
        {
            _contexto = contexto;
        }

        #region Get
        public DbSet<Autor> GetAuthor()
        {
            return _contexto.Autor;
        }
        #endregion

        #region Post
        public void AddAuthor(Autor author)
        {
            _contexto.Add(author);
            _contexto.SaveChanges();
        }

        public void AddAuthors(IEnumerable<Autor> author)
        {
            _contexto.Autor.AddRange(author);
            _contexto.SaveChanges();
        }
        #endregion

        #region Put
        public void EditAddAuthor(Autor author)
        {
            var authorForUpdate = GetAuthor().Find(author.Id);

            if (authorForUpdate != null)
            {
                _contexto.Entry(authorForUpdate).CurrentValues.SetValues(author);
                _contexto.SaveChanges();
            }
            else
            {
                throw new Exception();
            }

        }
        #endregion

        #region Delete
        public void DeleteAddAuthor(Autor author)
        {
            var authorForDelete = GetAuthor().Find(author.Id);

            if (authorForDelete != null)
            {
                _contexto.Remove(authorForDelete);
                _contexto.SaveChanges();
            }
            else
            {
                throw new Exception();
            }
        }
        #endregion

    }
}
