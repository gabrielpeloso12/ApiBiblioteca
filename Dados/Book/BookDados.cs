using Microsoft.EntityFrameworkCore;
using ORM;


namespace Dados.Book
{
    public class BookDados : IBookDados
    {
        private AppDbContext _contexto;

        public BookDados(AppDbContext contexto)
        {
            _contexto = contexto;
        }

        #region Get
        public DbSet<Livros> GetBook()
        {
            return _contexto.Livros;
        }
        #endregion


        #region Post
        public void AddBook(Livros book)
        {
            _contexto.Add(book);
            _contexto.SaveChanges();
        }

        public void AddBooks(IEnumerable<Livros> books)
        {
            _contexto.Livros.AddRange(books);
            _contexto.SaveChanges();
        }
        #endregion

        #region Put
        public void EditBook(Livros book)
        {
            var bookForUpdate = GetBook().Find(book.Id);

            if (bookForUpdate != null)
            {
                _contexto.Entry(bookForUpdate).CurrentValues.SetValues(book);
                _contexto.SaveChanges();
            }
            else
            {
                throw new Exception();
            }
        }
        #endregion

        #region Delete
        public void DeleteBook(Livros author)
        {
            var bookForDelete = GetBook().Find(author.Id);

            if (bookForDelete != null)
            {
                _contexto.Remove(bookForDelete);
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
