using ORM;
using Microsoft.EntityFrameworkCore;

namespace Dados.Book
{
    public interface IBookDados
    {
        public DbSet<Livros> GetBook();

        public void AddBook(Livros book);

        public void AddBooks(IEnumerable<Livros> books);

        public void EditBook(Livros book);

        public void DeleteBook(Livros author);
    }
}
