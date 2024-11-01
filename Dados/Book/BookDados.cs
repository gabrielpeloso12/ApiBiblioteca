using ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Task<IList<Livros>> GetBook()
        {

        }

        public Task<Livros?> GetBookPorId(int id)
        {

        }

        public Task<IEnumerable<Livros>> GetBookTittle(string titulo)
        {

        }
        #endregion


        #region Post
        public void AddBook(Livros book)
        {

        }

        public void AddBooks(IEnumerable<Livros> book)
        {

        }
        #endregion

        #region Put
        public void EditBook(Livros book)
        {

        }
        #endregion

        #region Delete
        public void DeleteBook(Livros author)
        {

        }
        #endregion
    }
}
