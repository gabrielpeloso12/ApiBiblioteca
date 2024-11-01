using ORM;
using Microsoft.EntityFrameworkCore;

namespace Dados.Book
{
    public interface IBookDados
    {
        public Task<IList<Livros>> GetBook();

        public Task<Livros?> GetBookPorId(int id);

        public Task<IEnumerable<Livros>> GetBookTittle(string titulo);

        public void AddBook(Livros book);

        public void AddBooks(IEnumerable<Livros> book);

        public void EditBook(Livros book);

        public void DeleteBook(Livros author);
    }
}
