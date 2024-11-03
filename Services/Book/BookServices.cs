using Microsoft.EntityFrameworkCore;
using ORM;
using Dados.Book;


namespace Services.Book
{
    public class BookServices : IBookServices
    {
        private IBookDados _bookDAO;
        private AppDbContext _contexto;

        public BookServices(IBookDados bookDAO, AppDbContext contexto)
        {
            _bookDAO = bookDAO;
            _contexto = contexto;
        }

        #region Get
        public async Task<IList<Livros>> GetBook()
        {
            return await _bookDAO.GetBook().ToListAsync();
        }

        public async Task<Livros?> GetBookPorId(int id)
        {
            return await _bookDAO.GetBook().FindAsync(id);
        }

        public async Task<IEnumerable<Livros>> GetBookTittle(string tittle)
        {
            return await _bookDAO.GetBook().Where(u => u.Titulo == tittle).ToListAsync();
        }
        #endregion

        #region Post
        public void AddBook(Livros book)
        {
            _bookDAO.AddBook(book);
        }

        public void AddBooks(IEnumerable<Livros> books)
        {
            _bookDAO.AddBooks(books);
        }
        #endregion

        #region Put
        public void EditBook(Livros book)
        {
            _bookDAO.EditBook(book);
        }
        #endregion

        #region Delete
        public void DeleteBook(Livros book)
        {
            _bookDAO.DeleteBook(book);
        }
        #endregion
    }
}
